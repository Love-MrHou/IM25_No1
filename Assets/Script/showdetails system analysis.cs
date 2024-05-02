using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShowDetailsSystemAnalysis : MonoBehaviour
{
    public Sprite[] sprites;
    public Image imageDisplay;

    private int currentIndex = 0;
    private int previousIndex = -1; //上一張圖片的索引值

    void Start()
    {
        // Display the first sprite
        ShowSprite(currentIndex);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (previousIndex != -1)
        {
            HideSprite(previousIndex); //隱藏上一張圖片
        }

        currentIndex = (currentIndex + 1) ; //下一張圖片的index

        ShowSprite(currentIndex);
        if (currentIndex == sprites.Length) // 顯示完所有圖片切換場景
        {
            SceneManager.LoadScene("Education Training");
        }
    }

    void ShowSprite(int index)
    {
        // Display the sprite at the given index
        imageDisplay.sprite = sprites[index]; //顯示下一張圖片
        imageDisplay.enabled = true;

        // Update the previous index
        previousIndex = index; //儲存現在圖片的index 下次點擊時隱藏

    }

    void HideSprite(int index)
    {
        // Hide the sprite at the given index
        imageDisplay.enabled = false;
    }
}