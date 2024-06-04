using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class CharacterBehavior : MonoBehaviour
{
    private NavMeshAgent agent; // NavMesh�N�z�A�Ω󱱨�NPC������
    private Animator animator; // Animator�ե�A�Ω󱱨�ʵe
    private string currentState; // ��e�ʵe���A

    // �ϥΪT�|�Ӻ޲z���⪬�A
    private enum CharacterState { Idle, Walking, Talking }
    private CharacterState currentCharacterState; // ��e���⪬�A

    // ���A�X�ʪ��欰�Ѽ�
    public float idleMinTime = 5f;
    public float idleMaxTime = 8f;
    public float talkingMinTime = 5f;
    public float talkingMaxTime = 15f;
    public float roamRadius = 10f;
    public float collisionCooldown = 15f;

    private float cooldownTimer; // �N�o�p�ɾ�
    private GameObject currentTalkingPartner; // ��e��ܹ�H

    // Animation States
    const string ANIM_WALK = "Walking";
    const string ANIM_IDLE = "Breathing Idle";
    const string ANIM_TALK = "Talking";

    void Start()
    {
        // �ۥD�ɯ�: ��l��NavMeshAgent
        agent = GetComponent<NavMeshAgent>();

        // �ʵe���A�޲z: ��l��Animator
        animator = GetComponent<Animator>();

        // ���A�X�ʪ��欰: �]�m��l���A��Idle
        SetState(CharacterState.Idle);

        // �Ұʪ��A�޲z��{
        StartCoroutine(StateManager());
    }

    IEnumerator StateManager()
    {
        while (true)
        {
            switch (currentCharacterState)
            {
                case CharacterState.Idle:
                    // ���A�X�ʪ��欰: Idle���A�B�z
                    yield return new WaitForSeconds(Random.Range(idleMinTime, idleMaxTime));
                    if (currentCharacterState == CharacterState.Idle) // �T�O���A�S���Q��L�ƥ����
                        SetState(CharacterState.Walking);
                    break;
                case CharacterState.Walking:
                    // ���A�X�ʪ��欰: Walking���A�B�z
                    SetNewDestination();
                    yield return new WaitUntil(() => agent.remainingDistance <= agent.stoppingDistance && !agent.pathPending);
                    Debug.Log("��F���w�a�I ����IDLE");
                    //animator.CrossFade(ANIM_IDLE, 0.3f, 0);  // 0.25�����ƹL���Idle�ʵe
                    SetState(CharacterState.Idle);
                    break;
                case CharacterState.Talking:
                    if (currentTalkingPartner != null)
                    {
                        // �����V���
                        transform.LookAt(new Vector3(currentTalkingPartner.transform.position.x, transform.position.y, currentTalkingPartner.transform.position.z));
                        yield return new WaitForSeconds(0.2f);  // ������V����

                        // �]�m�ʵe
                        ChangeAnimationState(ANIM_TALK);

                        // ���ݹ�ܮɶ�
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
        // ���~�B�z: ��s�N�o�p�ɾ�
        if (cooldownTimer > 0)
            cooldownTimer -= Time.deltaTime;
    }

    void LateUpdate()
    {
        // ���~�B�z: �T�O��m�P�B
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
                // �ʵe���A�޲z: ������Idle�ʵe
                ChangeAnimationState(ANIM_IDLE);
                agent.isStopped = true;
                agent.velocity = Vector3.zero;
                agent.ResetPath();
                break;
            case CharacterState.Walking:
                // �ʵe���A�޲z: ������Walking�ʵe
                ChangeAnimationState(ANIM_WALK);
                agent.isStopped = false;
                break;
            case CharacterState.Talking: // �ק�SetState��k�A���\�~�������]�m���A
                ChangeAnimationState(ANIM_TALK);
                agent.isStopped = true;
                agent.velocity = Vector3.zero;
                agent.ResetPath();
                break;
        }
    }


    void ChangeAnimationState(string newState)
    {
        // �ʵe���A�޲z: ��s��e�ʵe���A
        if (currentState == newState) return;
        animator.CrossFade(newState, 0.3f, 0);  // 0.3�����ƹL��
        currentState = newState;
    }
    void SetCooldown()
    {
        cooldownTimer = collisionCooldown;
    }

    void SetNewDestination()
    {
        // �H���ؼп��: �]�m�s���ؼ��I
        Vector3 newDestination = GetBestRandomPoint(transform.position, roamRadius);
        agent.SetDestination(newDestination);
    }

    Vector3 GetBestRandomPoint(Vector3 origin, float distance, int attempts = 5)
    {
        // �H���ؼп��: �h����������̨Υؼ��I
        NavMeshHit bestHit = new NavMeshHit();
        float bestDistance = 0;
        for (int i = 0; i < attempts; i++)
        {
            Vector3 randomDirection = Random.insideUnitSphere * distance + origin;
            if (NavMesh.SamplePosition(randomDirection, out NavMeshHit hit, distance, NavMesh.AllAreas))
            {
                float hitDistance = Vector3.Distance(hit.position, origin);
                // ��ܶZ�����I�̻����I�A�T�O���a����t
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
        // �����V���
        transform.LookAt(new Vector3(partner.transform.position.x, transform.position.y, partner.transform.position.z));

        // ���ݤ@�p�q�ɶ������⧹����V
        yield return new WaitForSeconds(0.2f);

        // �M��]�m Talking ���A�M�ʵe
        SetState(CharacterState.Talking);
        Debug.Log("�ʵe : Talking");

        // �}�l��ܭp��
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
            // �ШD���}�l���
            otherCharacter.RequestStartTalking(gameObject);

            // �p�G���P�N�]�q�L�ˬd�䪬�A�ܤơ^�A�ڭ̤]�}�l���
            if (otherCharacter.currentCharacterState == CharacterState.Talking)
            {
                RequestStartTalking(other.gameObject);
            }
            else
            {
                Debug.Log("���ڵ�");
            }

            // �ШD��譱�V�ڭ̡]�Ӥ��O�����ާ@�^
            //otherCharacter.FaceTowards(transform);
            Debug.Log("����OnTrigger"); 
        }
    }

    void OnTriggerExit(Collider other)
    {
        // �椬�t��: �B�zNPC���������}�ƥ�
        if (other.gameObject == currentTalkingPartner)
        {
            currentTalkingPartner = null;
            SetState(CharacterState.Idle);
            Debug.Log("�h�X���");
        }
    }



    // ����StateManager����Talking���A�B�z�A�����浹StartTalking�MEndTalkingAfterDelay�B�z
    IEnumerator EndTalkingAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SetState(CharacterState.Idle);
        currentTalkingPartner = null;
        SetCooldown(); // �A���]�m�H�T�O��ܫ�]���N�o
        Debug.Log("�]�w���Delay");
    }
}
