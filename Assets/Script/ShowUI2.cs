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
        if (other.CompareTag("Player")) // 確保只有玩家觸發
        {
            Canva.SetActive(true);
        }
    }

    // 當玩家離開觸發區域時調用
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // 確保只有玩家觸發
        {
            Canva.SetActive(false);
        }
    }
}
