using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class CharacterBehavior : MonoBehaviour
{
    private NavMeshAgent agent; // NavMesh代理，用於控制NPC的移動
    private Animator animator; // Animator組件，用於控制動畫
    private string currentState; // 當前動畫狀態

    // 使用枚舉來管理角色狀態
    private enum CharacterState { Idle, Walking, Talking }
    private CharacterState currentCharacterState; // 當前角色狀態

    // 狀態驅動的行為參數
    public float idleMinTime = 5f;
    public float idleMaxTime = 8f;
    public float talkingMinTime = 5f;
    public float talkingMaxTime = 15f;
    public float roamRadius = 10f;
    public float collisionCooldown = 15f;

    private float cooldownTimer; // 冷卻計時器
    private GameObject currentTalkingPartner; // 當前對話對象

    // Animation States
    const string ANIM_WALK = "Walking";
    const string ANIM_IDLE = "Breathing Idle";
    const string ANIM_TALK = "Talking";

    void Start()
    {
        // 自主導航: 初始化NavMeshAgent
        agent = GetComponent<NavMeshAgent>();

        // 動畫狀態管理: 初始化Animator
        animator = GetComponent<Animator>();

        // 狀態驅動的行為: 設置初始狀態為Idle
        SetState(CharacterState.Idle);

        // 啟動狀態管理協程
        StartCoroutine(StateManager());
    }

    IEnumerator StateManager()
    {
        while (true)
        {
            switch (currentCharacterState)
            {
                case CharacterState.Idle:
                    // 狀態驅動的行為: Idle狀態處理
                    yield return new WaitForSeconds(Random.Range(idleMinTime, idleMaxTime));
                    if (currentCharacterState == CharacterState.Idle) // 確保狀態沒有被其他事件改變
                        SetState(CharacterState.Walking);
                    break;
                case CharacterState.Walking:
                    // 狀態驅動的行為: Walking狀態處理
                    SetNewDestination();
                    yield return new WaitUntil(() => agent.remainingDistance <= agent.stoppingDistance && !agent.pathPending);
                    Debug.Log("到達指定地點 切換IDLE");
                    //animator.CrossFade(ANIM_IDLE, 0.3f, 0);  // 0.25秒內平滑過渡到Idle動畫
                    SetState(CharacterState.Idle);
                    break;
                case CharacterState.Talking:
                    if (currentTalkingPartner != null)
                    {
                        // 先面向對方
                        transform.LookAt(new Vector3(currentTalkingPartner.transform.position.x, transform.position.y, currentTalkingPartner.transform.position.z));
                        yield return new WaitForSeconds(0.2f);  // 等待轉向完成

                        // 設置動畫
                        ChangeAnimationState(ANIM_TALK);

                        // 等待對話時間
                        yield return new WaitForSeconds(Random.Range(talkingMinTime, talkingMaxTime));

                        SetState(CharacterState.Idle);
                        cooldownTimer = collisionCooldown;
                    }
                    else
                    {
                        SetState(CharacterState.Idle);
                    }
                    break;
            }
        }
    }

    void Update()
    {
        // 錯誤處理: 更新冷卻計時器
        if (cooldownTimer > 0)
            cooldownTimer -= Time.deltaTime;
    }

    void LateUpdate()
    {
        // 錯誤處理: 確保位置同步
        if (currentCharacterState == CharacterState.Idle || currentCharacterState == CharacterState.Talking)
        {
            transform.position = agent.transform.position;
        }
    }

    void SetState(CharacterState newState)
    {
        currentCharacterState = newState;
        switch (newState)
        {
            case CharacterState.Idle:
                // 動畫狀態管理: 切換到Idle動畫
                ChangeAnimationState(ANIM_IDLE);
                agent.isStopped = true;
                agent.velocity = Vector3.zero;
                agent.ResetPath();
                break;
            case CharacterState.Walking:
                // 動畫狀態管理: 切換到Walking動畫
                ChangeAnimationState(ANIM_WALK);
                agent.isStopped = false;
                break;
            case CharacterState.Talking: // 修改SetState方法，允許外部直接設置狀態
                ChangeAnimationState(ANIM_TALK);
                agent.isStopped = true;
                agent.velocity = Vector3.zero;
                agent.ResetPath();
                break;
        }
    }


    void ChangeAnimationState(string newState)
    {
        // 動畫狀態管理: 更新當前動畫狀態
        if (currentState == newState) return;
        animator.CrossFade(newState, 0.3f, 0);  // 0.3秒內平滑過渡
        currentState = newState;
    }
    void SetCooldown()
    {
        cooldownTimer = collisionCooldown;
    }

    void SetNewDestination()
    {
        // 隨機目標選擇: 設置新的目標點
        Vector3 newDestination = GetBestRandomPoint(transform.position, roamRadius);
        agent.SetDestination(newDestination);
    }

    Vector3 GetBestRandomPoint(Vector3 origin, float distance, int attempts = 5)
    {
        // 隨機目標選擇: 多次嘗試獲取最佳目標點
        NavMeshHit bestHit = new NavMeshHit();
        float bestDistance = 0;
        for (int i = 0; i < attempts; i++)
        {
            Vector3 randomDirection = Random.insideUnitSphere * distance + origin;
            if (NavMesh.SamplePosition(randomDirection, out NavMeshHit hit, distance, NavMesh.AllAreas))
            {
                float hitDistance = Vector3.Distance(hit.position, origin);
                // 選擇距離原點最遠的點，確保不靠近邊緣
                if (hitDistance > bestDistance)
                {
                    bestHit = hit;
                    bestDistance = hitDistance;
                }
            }
        }
        return bestHit.position;
    }
    public void RequestStartTalking(GameObject partner)
    {
        if (currentCharacterState != CharacterState.Talking)
        {
            currentTalkingPartner = partner;
            StartCoroutine(StartTalkingCoroutine(partner));
        }
    }

    private IEnumerator StartTalkingCoroutine(GameObject partner)
    {
        // 先面向對方
        transform.LookAt(new Vector3(partner.transform.position.x, transform.position.y, partner.transform.position.z));

        // 等待一小段時間讓角色完成轉向
        yield return new WaitForSeconds(0.2f);

        // 然後設置 Talking 狀態和動畫
        SetState(CharacterState.Talking);
        Debug.Log("動畫 : Talking");

        // 開始對話計時
        float talkDuration = Random.Range(talkingMinTime, talkingMaxTime);
        StartCoroutine(EndTalkingAfterDelay(talkDuration));
    }

    public bool CanTalk()
    {
        return currentCharacterState != CharacterState.Talking && cooldownTimer <= 0;
    }

    public void FaceTowards(Transform target)
    {
        transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
    }


    void OnTriggerEnter(Collider other)
    {
        CharacterBehavior otherCharacter = other.GetComponent<CharacterBehavior>();
        if (otherCharacter != null && CanTalk() && otherCharacter.CanTalk())
        {
            // 請求對方開始對話
            otherCharacter.RequestStartTalking(gameObject);

            // 如果對方同意（通過檢查其狀態變化），我們也開始對話
            if (otherCharacter.currentCharacterState == CharacterState.Talking)
            {
                RequestStartTalking(other.gameObject);
            }
            else
            {
                Debug.Log("對方拒絕");
            }

            // 請求對方面向我們（而不是直接操作）
            //otherCharacter.FaceTowards(transform);
            Debug.Log("結束OnTrigger"); 
        }
    }

    void OnTriggerExit(Collider other)
    {
        // 交互系統: 處理NPC之間的離開事件
        if (other.gameObject == currentTalkingPartner)
        {
            currentTalkingPartner = null;
            SetState(CharacterState.Idle);
            Debug.Log("退出聊天");
        }
    }



    // 移除StateManager中的Talking狀態處理，全部交給StartTalking和EndTalkingAfterDelay處理
    IEnumerator EndTalkingAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SetState(CharacterState.Idle);
        currentTalkingPartner = null;
        SetCooldown(); // 再次設置以確保對話後也有冷卻
        Debug.Log("設定對話Delay");
    }
}
