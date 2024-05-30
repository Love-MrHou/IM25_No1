using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUI2 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Canva;
    void Start()
    {
        Canva.SetActive(false);
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // �T�O�u�����aĲ�o
        {
            Canva.SetActive(true);
        }
    }

    // ���a���}Ĳ�o�ϰ�ɽե�
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // �T�O�u�����aĲ�o
        {
            Canva.SetActive(false);
        }
    }
}
