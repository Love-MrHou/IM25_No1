using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShowDetailsSystemAnalysis : MonoBehaviour
{
    public Sprite[] sprites;
    public Image imageDisplay;

    private int currentIndex = 0;
    private int previousIndex = -1; //�W�@�i�Ϥ������ޭ�

    void Start()
    {
        // Display the first sprite
        ShowSprite(currentIndex);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (previousIndex != -1)
        {
            HideSprite(previousIndex); //���äW�@�i�Ϥ�
        }

        currentIndex = (currentIndex + 1) ; //�U�@�i�Ϥ���index

        ShowSprite(currentIndex);
        if (currentIndex == sprites.Length) // ��ܧ��Ҧ��Ϥ���������
        {
            SceneManager.LoadScene("Education Training");
        }
    }

    void ShowSprite(int index)
    {
        // Display the sprite at the given index
        imageDisplay.sprite = sprites[index]; //��ܤU�@�i�Ϥ�
        imageDisplay.enabled = true;

        // Update the previous index
        previousIndex = index; //�x�s�{�b�Ϥ���index �U���I��������

    }

    void HideSprite(int index)
    {
        // Hide the sprite at the given index
        imageDisplay.enabled = false;
    }
}