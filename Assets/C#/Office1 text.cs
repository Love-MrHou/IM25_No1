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
        story = new Story(inkAssets.text); //new Story �̭���json�ɪ���r�A�� Story ��l��
        return true;

    }

    public void NextDialog()
    {
        if (story == null) return;
        if (!story.canContinue && story.currentChoices.Count == 0)
        { //�p�Gstory�����~�� && �S���ﶵ�A�h�N���ܵ���
            Debug.Log("Dialog End");
            story = null;
            return;
        }
        if (story.currentChoices.Count > 0) SetChoices(); //���o�ثe��ܿﶵ�ƶq�A�p�G > 0 �h�]�w�ﶵ���s
        if (story.canContinue) diaglogText.text = story.Continue(); //�p�G�i�H�~��U�@�y��ܡA���� story.Continue()
    }

    private void SetChoices()
    { //�̷ӿﶵ�ƶq�A�]�m���s ��r �� Active
        for (int i = 0; i < story.currentChoices.Count; i++)
        {
            buttons[i].gameObject.SetActive(true);
            buttons[i].GetComponentInChildren<Text>().text = story.currentChoices[i].text;
        }
    }

    public void MakeChoice(int index)
    {
        story.ChooseChoiceIndex(index); //�ϥ� ChooseChoiceIndex ��ܷ�e�ﶵ
        for (int i = 0; i < buttons.Length; i++)
        { //��ܧ��A�N���s����
            buttons[i].gameObject.SetActive(false);
        }
        NextDialog();
    }

}
