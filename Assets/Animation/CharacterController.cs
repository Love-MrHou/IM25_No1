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

        // 將人物設置在指定位置和角度
        transform.position = new Vector3(-26.64f, -1.66f, -22.23f);
        transform.rotation = Quaternion.Euler(0, 100, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasMoved)
        {
            // 人物移動
            StartCoroutine(MoveCharacter(new Vector3(-4.21f, -1.66f, -22.23f)));

            // 角度轉向
            transform.rotation = Quaternion.Euler(0, 180, 0);

            // 標記已經移動，避免再次執行此區塊
            hasMoved = true;
        }
    }

    IEnumerator MoveCharacter(Vector3 targetPosition)
    {
        // 計算移動的距離
        float distance = Vector3.Distance(transform.position, targetPosition);
        // 播放走路動畫
        _animator.SetBool("isRun", true);

        // 移動的時間
        float moveTime = distance / 200f;

        // 移動到目標位置
        while (transform.position != targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, 200 * Time.deltaTime);
            yield return null;
        }

        // 停止走路動畫
        _animator.SetBool("isRun", false);
    }
}
