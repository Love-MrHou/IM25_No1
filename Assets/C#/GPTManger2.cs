using UnityEngine;
using UnityEngine.UI;
using OpenAI_API;
using OpenAI_API.Chat;
using System.Collections.Generic;
using OpenAI_API.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using System.Threading.Tasks;
using System;
using CandyCoded.env;
public class GPTManager2 : MonoBehaviour
{
    public Text gptOutputText;
    public Text text; 
    public AudioSource audioSource; 

    private OpenAIAPI api;
    private SpeechSynthesizer synthesizer;
    private bool isSpeaking = false;

    void Start()
    {
        // 讀取OpenAI API密鑰
        if (env.TryParseEnvironmentVariable("OPENAIAPI", out string openAiApiKey))
        {
            api = new OpenAIAPI(openAiApiKey);
        }
        else
        {
            Debug.LogError("Failed to read OpenAI API key from environment variables.");
            return;
        }
        // 設置Json序列化設置
        var settings = new JsonSerializerSettings
        {
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            },
            NullValueHandling = NullValueHandling.Ignore
        };

        JsonConvert.DefaultSettings = () => settings;

        // 讀取Azure API密鑰和區域
        if (env.TryParseEnvironmentVariable("AZUREAPI", out string azureApiKey) && env.TryParseEnvironmentVariable("AZURE", out string azureRegion))
        {
            var config = SpeechConfig.FromSubscription(azureApiKey, azureRegion);
            config.SpeechSynthesisLanguage = "zh-TW";
            config.SpeechSynthesisVoiceName = "zh-CN-XiaochenNeural";
            var audioConfig = AudioConfig.FromDefaultSpeakerOutput();
            synthesizer = new SpeechSynthesizer(config, audioConfig);
        }
        else
        {
            Debug.LogError("Failed to read Azure API key or region from environment variables.");
            return;
        }
    }

    public async void ProcessInputFromText()
    {
        if (isSpeaking) return;
        isSpeaking = true;

        string characterIntroduction = "他只會說繁體中文，她活力充沛且外向，每次說話不會超過30個字，會可能減短說的話。擁有超過十五年的工作經驗，是一名系統分析師，她對於系統分析的每個細節都了如指掌，並且能夠以清晰易懂的方式解釋技術概念。不論是面對初學者還是專業玩家的疑問，她都能夠提供深入且具有洞察力的回答。不僅在技術上精通，還擁有無比的熱情與承諾，始終致力於提供最佳的解決方案。";

        string userInput = text.text;

        if (string.IsNullOrEmpty(userInput))
        {
            Debug.LogError("User input is empty.");
            isSpeaking = false;
            return;
        }

        List<ChatMessage> messages = new List<ChatMessage>
        {
            new ChatMessage(ChatMessageRole.System, characterIntroduction),
            new ChatMessage(ChatMessageRole.User, userInput)
        };

        // 處理API調用的邏輯
        // 這裡您需要使用api來處理OpenAI的請求，並使用synthesizer來處理Azure的語音合成

        isSpeaking = false;


        try
        {
            var chatResult = await api.Chat.CreateChatCompletionAsync(new ChatRequest()
            {
                Model = Model.ChatGPTTurbo,
                Temperature = 0.9,
                MaxTokens = 100,
                Messages = messages
            });

            if (chatResult != null && chatResult.Choices != null && chatResult.Choices.Count > 0)
            {
                string gptResponse = chatResult.Choices[0].Message.Content;

                if (gptOutputText != null)
                {
                    gptOutputText.text = gptResponse;
                    await TextToSpeech(gptResponse);
                }
                else
                {
                    Debug.LogError("gptOutputText property is null! Assign a UI Text element to it.");
                }
            }
            else
            {
                Debug.LogError("Failed to get valid response from GPT.");
            }
        }
        catch (Exception ex)
        {
            Debug.LogError($"Error during OpenAI API call: {ex.Message}");
        }

        isSpeaking = false;
    }

    private async Task TextToSpeech(string text)
    {
        try
        {
            var result = await synthesizer.SpeakTextAsync(text);

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

                audioSource.clip = audioClip;
                audioSource.Play();

                Debug.Log("Speech synthesis succeeded!");
            }
            else if (result.Reason == ResultReason.Canceled)
            {
                var cancellation = SpeechSynthesisCancellationDetails.FromResult(result);
                Debug.LogError($"Speech synthesis canceled: {cancellation.ErrorDetails}");
            }
        }
        catch (Exception ex)
        {
            Debug.LogError($"Error during speech synthesis: {ex.Message}");
        }
        finally
        {
            isSpeaking = false;
        }
    }
    private void OnDestroy()
    {
        synthesizer.Dispose();
    }

    public void OnButtonClick()
    {
        ProcessInputFromText();
    }
}