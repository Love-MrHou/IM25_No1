using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowInformation : MonoBehaviour
{
    public Button footbook;//footbook���s
    public Button instragrum; //instragrum���s
    public Button xwitter;// xwitter���s
    public Canvas footbook_C; //footbook��canva
    public Canvas instragrum_C; //instragrum��canva
    public Canvas xwitter_C; //xwitter��canva
    void Start()
    {
        footbook_C.gameObject.SetActive(false); //�}�l�ɧ�Ҧ��Ϥ�����
        instragrum_C.gameObject.SetActive(false);
        xwitter_C.gameObject.SetActive(false);
        footbook.onClick.AddListener(OnFootbookClick); //�b�C�@�ӫ��s�W�[�W�@�Ӻ�ť��
        instragrum.onClick.AddListener(OninstragrumClick);
        xwitter.onClick.AddListener(OnxwitterClick);
    }
    void OnFootbookClick()�@//�b���s���U�ɧ��L��canva����
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
