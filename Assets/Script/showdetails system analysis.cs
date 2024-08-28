using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShowDetailsSystemAnalysis : MonoBehaviour
{
    public Sprite[] sprites; //�̧���ܪ��Ϥ�
    public Image imageDisplay; //�n��ܪ�image����m
    public Button nextButton; //�����Ϥ������s
    public Canvas currentCanvas; //��ܹϤ���canva
    public Canvas additionalCanvas; //��ܤT��ui��canva

    private int currentIndex = 0; //�Ψ���ܥثe�Ϥ�
    private int previousIndex = -1; //�Ψ����äW�@�i�Ϥ�

    void Start()
    {
        ShowSprite(currentIndex);
        nextButton.onClick.AddListener(OnButtonClick);
        additionalCanvas.gameObject.SetActive(false);
    }

    void OnButtonClick()
    {
        if (previousIndex != -1)
        {
            HideSprite(previousIndex); //���äW�@�i�Ϥ�
        }

        currentIndex++; //��ܪ��Ϥ����ޭ�+1

        if (currentIndex < sprites.Length) //�p�G�٦��Ϥ��n���
        {
            ShowSprite(currentIndex); //��ܲ{�b���Ϥ�
        }
        else
        {
            additionalCanvas.gameObject.SetActive(true); // ����ܪ���n�骺canva���
            currentCanvas.gameObject.SetActive(false); // ����ܹϤ���canva����
        }
    }

    void ShowSprite(int index)
    {
        imageDisplay.sprite = sprites[index]; //��ܲ{�b���Ϥ�
        imageDisplay.enabled = true; // enable = true
        previousIndex = index; // ��e�@�ӹϤ������ޭȳ]���ثe�Ϥ������� �ΨӤU�@�i�Ϥ���ܮ�����
    }

    void HideSprite(int index)
    {
        imageDisplay.enabled = false;
    }
}