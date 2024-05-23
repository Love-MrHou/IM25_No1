using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showUI : MonoBehaviour
{
    public Canvas canvas;
    private void Start()
    {
        canvas.enabled = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        canvas.enabled = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        canvas.enabled = false;
    }
}
