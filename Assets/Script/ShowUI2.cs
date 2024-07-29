﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUI2 : MonoBehaviour
{
    public GameObject Canva;
    private AzureSpeechSynthesizer speechSynthesizer;

    void Start()
    {
        Canva.SetActive(false);
        speechSynthesizer = Canva.GetComponent<AzureSpeechSynthesizer>();
        if (speechSynthesizer == null)
        {
            Debug.LogError("AzureSpeechSynthesizer component is not attached to the Canva object.");
        }
        else
        {
            speechSynthesizer.enabled = false; // 初始时禁用
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // 确保只有玩家触发
        {
            Canva.SetActive(true);
            if (speechSynthesizer != null)
            {
                speechSynthesizer.enabled = true; // 启用脚本
                speechSynthesizer.TriggerSpeech(); // 开始语音播放
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // 确保只有玩家触发
        {
            Canva.SetActive(false);
            if (speechSynthesizer != null)
            {
                speechSynthesizer.enabled = false; // 禁用脚本
            }
        }
    }
}
