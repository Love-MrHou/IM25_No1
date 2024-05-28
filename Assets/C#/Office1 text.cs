using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.UI;
using TMPro;

public class Office1text : MonoBehaviour
{
    public TextMeshProUGUI dialogText;
    public Button[] buttons;
    public TextAsset inkAsset;
    private Story story;

    void Start()
    {
        InitializeButtons();

        if (inkAsset == null)
        {
            Debug.LogError("Ink Asset is not assigned in the inspector.");
            return;
        }

        if (StartDialog(inkAsset))
        {
            NextDialog();
        }
    }

    private void InitializeButtons()
    {
        foreach (Button button in buttons)
        {
            button.gameObject.SetActive(false);
            button.onClick.AddListener(() => OnChoiceButtonClicked(button));
        }
    }

    private void OnChoiceButtonClicked(Button button)
    {
        int index = System.Array.IndexOf(buttons, button);
        if (index >= 0 && index < story.currentChoices.Count)
        {
            MakeChoice(index);
        }
    }

    public bool StartDialog(TextAsset inkAsset)
    {
        if (story != null) return false;
        story = new Story(inkAsset.text);
        return true;
    }

    public void NextDialog()
    {
        if (story == null) return;

        if (!story.canContinue && story.currentChoices.Count == 0)
        {
            Debug.Log("Dialog End");
            story = null;
            return;
        }

        if (story.canContinue)
        {
            dialogText.text = story.Continue();
        }

        if (story.currentChoices.Count > 0)
        {
            SetChoices();
        }
    }

    private void SetChoices()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            if (i < story.currentChoices.Count)
            {
                buttons[i].gameObject.SetActive(true);
                buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = story.currentChoices[i].text;
            }
            else
            {
                buttons[i].gameObject.SetActive(false);
            }
        }
    }

    public void MakeChoice(int index)
    {
        story.ChooseChoiceIndex(index);
        HideChoices();
        NextDialog();
    }

    private void HideChoices()
    {
        foreach (Button button in buttons)
        {
            button.gameObject.SetActive(false);
        }
    }
}
