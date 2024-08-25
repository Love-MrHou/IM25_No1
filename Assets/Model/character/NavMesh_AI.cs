using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public partial class NavMesh_AI : MonoBehaviour
{
   
    private Animator animator; // Animator�ե�A�Ω󱱨�ʵe
    private string currentState; // ��e�ʵe���A

    // �ϥΪT�|�Ӻ޲z���⪬�A
    public enum CharacterState { Idle, Walking, Talking }
    internal CharacterState currentCharacterState; // ��e���⪬�A

    // ���A�X�ʪ��欰�Ѽ�
    public float idleMinTime = 5f;
    public float idleMaxTime = 8f;
    public float talkingMinTime = 5f;
    public float talkingMaxTime = 15f;
    public float roamRadius = 10f;
    public float collisionCooldown = 15f;

    private float cooldownTimer; // �N�o�p�ɾ�

    // Animation States
    const string ANIM_WALK = "Walking";
    const string ANIM_IDLE = "Breathing Idle";
    const string ANIM_TALK = "Talking";

    void Start()
    {
        //Time.timeScale = 3;
        // �ۥD�ɯ�: ��l��NavMeshAgent
        agent = GetComponent<NavMeshAgent>();

        // �ʵe���A�޲z: ��l��Animator
        animator = GetComponent<Animator>();

        // ���A�X�ʪ��欰: �]�m��l���A��Idle
        SetState(CharacterState.Idle);

        // �Ұʪ��A�޲z��{
        StartCoroutine(StateManager());
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
        NavMesh_AI otherCharacter = other.GetComponent<NavMesh_AI>();
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
}
