using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private CharacterController _character;
    private Animator _animator;
    private bool hasMoved = false;
    // Start is called before the first frame update
    void Start()
    {
        _character = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();

        // �N�H���]�m�b���w��m�M����
        transform.position = new Vector3(-26.64f, -1.66f, -22.23f);
        transform.rotation = Quaternion.Euler(0, 100, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasMoved)
        {
            // �H������
            StartCoroutine(MoveCharacter(new Vector3(-4.21f, -1.66f, -22.23f)));

            // ������V
            transform.rotation = Quaternion.Euler(0, 180, 0);

            // �аO�w�g���ʡA�קK�A�����榹�϶�
            hasMoved = true;
        }
    }

    IEnumerator MoveCharacter(Vector3 targetPosition)
    {
        // �p�Ⲿ�ʪ��Z��
        float distance = Vector3.Distance(transform.position, targetPosition);
        // ���񨫸��ʵe
        _animator.SetBool("isRun", true);

        // ���ʪ��ɶ�
        float moveTime = distance / 200f;

        // ���ʨ�ؼЦ�m
        while (transform.position != targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, 200 * Time.deltaTime);
            yield return null;
        }

        // ������ʵe
        _animator.SetBool("isRun", false);
    }
}
