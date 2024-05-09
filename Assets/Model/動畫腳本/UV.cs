using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UV : MonoBehaviour
{
    private CharacterController _character;
    private Animator _animator;
    private Vector3 _targetPosition = new Vector3(-4.42f, 0, 0); // 目標位置
    private Quaternion _targetRotation = Quaternion.Euler(0, 85, 0); // 目標轉向
    private float _movementSpeed = 2.0f; // 移動速度

    // Start is called before the first frame update
    void Start()
    {
        _character = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = _targetPosition - transform.position; // 計算到目標位置的方向向量

        if (dir.magnitude > 0.1f) // 檢查是否到達目標位置
        {
            dir.y = 0; // 確保y軸方向不移動

            transform.rotation = Quaternion.RotateTowards(transform.rotation, _targetRotation, Time.deltaTime * 100); // 逐漸轉向目標轉向

            _animator.SetBool("isRun", true); // 設定動畫為跑步

            _character.Move(transform.forward * _movementSpeed * Time.deltaTime); // 移動角色
        }
        else
        {
            _animator.SetBool("isRun", false); // 設定動畫為停止
        }
    }
}
