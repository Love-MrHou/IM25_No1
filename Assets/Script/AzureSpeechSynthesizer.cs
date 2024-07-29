using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.CognitiveServices.Speech;
using System.Threading.Tasks;
using System.IO;

public class AzureSpeechSynthesizer : MonoBehaviour
{
    private string subscriptionKey = "84bc71ce611543798efa1d003f9ae3cd"; // 替换为您的订阅金钥
    private string region = "eastus"; // 替换为您的服务区域
    [SerializeField] private TextAsset speakTextFile; // 用于存放文本文件的变量
    private SpeechConfig speechConfig;
    private SpeechSynthesizer synthesizer;
    private TaskCompletionSource<bool> synthesisTaskCompletionSource;

    void Start()
    {
        speechConfig = SpeechConfig.FromSubscription(subscriptionKey, region);
        speechConfig.SpeechSynthesisVoiceName = "zh-CN-XiaoxiaoNeural"; // 设置语音特性，可以设置为不同的声音(重要)

        synthesizer = new SpeechSynthesizer(speechConfig);

        // 初始时不播放内容
    }

    void OnDisable()
    {
        // 停止合成操作
        synthesizer.StopSpeakingAsync().Wait();
    }

    public async void TriggerSpeech()
    {
        if (speakTextFile != null)
        {
            string text = speakTextFile.text;
            await SynthesizeSpeech(text);
        }
        else
        {
            Debug.LogError("Speak text file is not assigned.");
        }
    }

    public async Task SynthesizeSpeech(string text)
    {
        using (var result = await synthesizer.SpeakTextAsync(text))
        {
            if (result.Reason == ResultReason.SynthesizingAudioCompleted)
            {
                Debug.Log("Speech synthesis succeeded.");
            }
            else if (result.Reason == ResultReason.Canceled)
            {
                var cancellation = SpeechSynthesisCancellationDetails.FromResult(result);
                Debug.LogError($"CANCELED: Reason={cancellation.Reason}");

                if (cancellation.Reason == CancellationReason.Error)
                {
                    Debug.LogError($"CANCELED: ErrorCode={cancellation.ErrorCode}");
                    Debug.LogError($"CANCELED: ErrorDetails={cancellation.ErrorDetails}");
                }
            }
        }
    }
}
