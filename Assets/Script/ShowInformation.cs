using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowInformation : MonoBehaviour
{
    public Button footbook;//footbook按鈕
    public Button instragrum; //instragrum按鈕
    public Button xwitter;// xwitter按鈕
    public Canvas footbook_C; //footbook的canva
    public Canvas instragrum_C; //instragrum的canva
    public Canvas xwitter_C; //xwitter的canva
    void Start()
    {
        footbook_C.gameObject.SetActive(false); //開始時把所有圖片隱藏
        instragrum_C.gameObject.SetActive(false);
        xwitter_C.gameObject.SetActive(false);
        footbook.onClick.AddListener(OnFootbookClick); //在每一個按鈕上加上一個監聽器
        instragrum.onClick.AddListener(OninstragrumClick);
        xwitter.onClick.AddListener(OnxwitterClick);
    }
    void OnFootbookClick()　//在按鈕按下時把其他的canva隱藏
    {
        footbook_C.gameObject.SetActive(true);
        instragrum_C.gameObject.SetActive(false);
        xwitter_C.gameObject.SetActive(false);
    }
    void OninstragrumClick()
    {
        footbook_C.gameObject.SetActive(false);
        instragrum_C.gameObject.SetActive(true);
        xwitter_C.gameObject.SetActive(false);
    }

    void OnxwitterClick()
    {
        footbook_C.gameObject.SetActive(false);
        instragrum_C.gameObject.SetActive(false);
        xwitter_C.gameObject.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
