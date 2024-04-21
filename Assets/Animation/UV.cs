using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UV : MonoBehaviour
{
    private CharacterController _character;
    private Animator _animator;
    private Vector3 _targetPosition = new Vector3(-4.42f, 0, 0); // �ؼЦ�m
    private Quaternion _targetRotation = Quaternion.Euler(0, 85, 0); // �ؼ���V
    private float _movementSpeed = 2.0f; // ���ʳt��

    // Start is called before the first frame update
    void Start()
    {
        _character = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = _targetPosition - transform.position; // �p���ؼЦ�m����V�V�q

        if (dir.magnitude > 0.1f) // �ˬd�O�_��F�ؼЦ�m
        {
            dir.y = 0; // �T�Oy�b��V������

            transform.rotation = Quaternion.RotateTowards(transform.rotation, _targetRotation, Time.deltaTime * 100); // �v����V�ؼ���V

            _animator.SetBool("isRun", true); // �]�w�ʵe���]�B

            _character.Move(transform.forward * _movementSpeed * Time.deltaTime); // ���ʨ���
        }
        else
        {
            _animator.SetBool("isRun", false); // �]�w�ʵe������
        }
    }
}
