using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.UI;

public class Office1text : MonoBehaviour
{

    public Text diaglogText;
    public Button[] buttons;
    public TextAsset _inkAssets;
    Story story = null;
    // Start is called before the first frame update
    void Start()
    {
        StartDialog(_inkAssets);
        NextDialog();
        SetChoices();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public bool StartDialog(TextAsset inkAssets)
    {
        if (story != null) return false;
        story = new Story(inkAssets.text); //new Story 裡面放json檔的文字，讓 Story 初始化
        return true;

    }

    public void NextDialog()
    {
        if (story == null) return;
        if (!story.canContinue && story.currentChoices.Count == 0)
        { //如果story不能繼續 && 沒有選項，則代表對話結束
            Debug.Log("Dialog End");
            story = null;
            return;
        }
        if (story.currentChoices.Count > 0) SetChoices(); //取得目前對話選項數量，如果 > 0 則設定選項按鈕
        if (story.canContinue) diaglogText.text = story.Continue(); //如果可以繼續下一句對話，執行 story.Continue()
    }

    private void SetChoices()
    { //依照選項數量，設置按鈕 文字 及 Active
        for (int i = 0; i < story.currentChoices.Count; i++)
        {
            buttons[i].gameObject.SetActive(true);
            buttons[i].GetComponentInChildren<Text>().text = story.currentChoices[i].text;
        }
    }

    public void MakeChoice(int index)
    {
        story.ChooseChoiceIndex(index); //使用 ChooseChoiceIndex 選擇當前選項
        for (int i = 0; i < buttons.Length; i++)
        { //選擇完，將按鈕隱藏
            buttons[i].gameObject.SetActive(false);
        }
        NextDialog();
    }

}
