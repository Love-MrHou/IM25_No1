using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changescene : MonoBehaviour
{
    public void ChangeScene()
    {
        var player = GameObject.Find("Player");
        GameObject.Destroy(player);
        Valve.VR.SteamVR_LoadLevel.Begin("education training");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

