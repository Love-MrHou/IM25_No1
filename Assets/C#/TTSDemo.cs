using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using UnityEngine;
using UnityEngine.UI;

public class TTSDemo : MonoBehaviour
{
    public Text inputField;
    public Button speakButton;
    public AudioSource audioSource;

    private string message;
    private SpeechSynthesizer synthesizer;
    private bool isSpeaking = false; 

    void Start()
    {
        if (inputField == null)
        {
            message = "inputField property is null! Assign a UI InputField element to it.";
            UnityEngine.Debug.LogError(message);
        }
        else if (speakButton == null)
        {
            message = "speakButton property is null! Assign a UI Button to it.";
            UnityEngine.Debug.LogError(message);
        }
        else if (audioSource == null)
        {
            message = "audioSource property is null! Assign an AudioSource element to it.";
            UnityEngine.Debug.LogError(message);
        }
        else
        {
            // Initialize SpeechSynthesizer once
            var config = SpeechConfig.FromSubscription("155998f0555f47ae9ad78430ef6491aa", "eastus");
            config.SpeechSynthesisLanguage = "zh-TW";
            config.SpeechSynthesisVoiceName = "zh-CN-XiaoyouNeural";
            var audioConfig = AudioConfig.FromDefaultSpeakerOutput();
            synthesizer = new SpeechSynthesizer(config, audioConfig);

            // Register button click listener
            speakButton.onClick.AddListener(ButtonClick);
        }
    }

    public async void ButtonClick()
    {
        if (isSpeaking) return; 
        isSpeaking = true;

        Debug.Log("¶}©l");

        // Check if synthesizer is initialized
        if (synthesizer == null)
        {
            Debug.LogError("Speech synthesizer is not initialized!");
            isSpeaking = false;
            return;
        }

        var result = await synthesizer.SpeakTextAsync(inputField.text);

        if (result.Reason == ResultReason.SynthesizingAudioCompleted)
        {
            var sampleCount = result.AudioData.Length / 2;
            var audioData = new float[sampleCount];
            for (var i = 0; i < sampleCount; ++i)
            {
                audioData[i] = (short)(result.AudioData[i * 2 + 1] << 8 | result.AudioData[i * 2]) / 32768.0F;
            }

            var audioClip = AudioClip.Create("SynthesizedAudio", sampleCount, 1, 16000, false);
            audioClip.SetData(audioData, 0);

            // Play the audio clip
            audioSource.clip = audioClip;
            audioSource.Play();

            Debug.Log("Speech synthesis succeeded!");
        }
        else if (result.Reason == ResultReason.Canceled)
        {
            var cancellation = SpeechSynthesisCancellationDetails.FromResult(result);
            Debug.LogError($"Speech synthesis canceled: {cancellation.ErrorDetails}");
        }

        isSpeaking = false;
    }

    private void OnDestroy()
    {
        // Dispose the synthesizer properly when the object is destroyed
        synthesizer.Dispose();
    }
}