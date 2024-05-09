using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stand_animation : MonoBehaviour
{
    private CharacterController _character;
    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _character = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
        _animator.SetBool("isStandIdle", true);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
