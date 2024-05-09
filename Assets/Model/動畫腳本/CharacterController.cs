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

        // 將人物設置在指定位置和角度
        transform.position = new Vector3(-26.64f, -1.66f, -22.23f);
        transform.rotation = Quaternion.Euler(0, 100, 0);

        // 設定目標位置
        targetPosition = new Vector3(-4.21f, -1.66f, -22.23f);

        // 在開始時開始移動
        StartCoroutine(MoveCharacter(targetPosition));
    }

    // Update is called once per frame
    void Update()
    {
        // 如果還沒移動，就開始移動
        if (!hasMoved)
        {
            // 標記已經移動，避免再次執行此區塊
            hasMoved = true;
        }
    }

    IEnumerator MoveCharacter(Vector3 targetPosition)
    {
        // 標記已經移動，避免再次執行此區塊
        hasMoved = true;

        // 計算移動的距離
        float distance = Vector3.Distance(transform.position, targetPosition);
        // 播放走路動畫
        _animator.SetBool("isRun", true);

        // 移動的時間
        float moveTime = distance / 20f;

        // 移動到目標位置
        while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            Debug.Log("test");
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, 20 * Time.deltaTime);
            yield return null;
        }

        // 停止走路動畫
        _animator.SetBool("isRun", false);
    }
}
