using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private CharacterController _character;
    private Animator _animator;
    private bool hasMoved = false;
    private Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        _character = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();

        // �N�H���]�m�b���w��m�M����
        transform.position = new Vector3(-26.64f, -1.66f, -22.23f);
        transform.rotation = Quaternion.Euler(0, 100, 0);

        // �]�w�ؼЦ�m
        targetPosition = new Vector3(-4.21f, -1.66f, -22.23f);

        // �b�}�l�ɶ}�l����
        StartCoroutine(MoveCharacter(targetPosition));
    }

    // Update is called once per frame
    void Update()
    {
        // �p�G�٨S���ʡA�N�}�l����
        if (!hasMoved)
        {
            // �аO�w�g���ʡA�קK�A�����榹�϶�
            hasMoved = true;
        }
    }

    IEnumerator MoveCharacter(Vector3 targetPosition)
    {
        // �аO�w�g���ʡA�קK�A�����榹�϶�
        hasMoved = true;

        // �p�Ⲿ�ʪ��Z��
        float distance = Vector3.Distance(transform.position, targetPosition);
        // ���񨫸��ʵe
        _animator.SetBool("isRun", true);

        // ���ʪ��ɶ�
        float moveTime = distance / 20f;

        // ���ʨ�ؼЦ�m
        while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            Debug.Log("test");
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, 20 * Time.deltaTime);
            yield return null;
        }

        // ������ʵe
        _animator.SetBool("isRun", false);
    }
}
