using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUI : MonoBehaviour
{
    public Office1text office;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerEnter()
    {
        //office.transform.position = transform.position;
        office.gameObject.SetActive(true);
    }

    public void PlayeExit()
    {
        office.gameObject.SetActive(false);
    }
}
