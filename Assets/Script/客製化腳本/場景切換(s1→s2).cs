using UnityEngine;
using UnityEngine.SceneManagement; // �ޤJ�����޲z

public class SceneChanger : MonoBehaviour
{
    // �]�m�n�[���������W��
    public string sceneName;
    public GameObject ChangePoint;

    void Start()
    {
        ChangePoint.SetActive(false);
    }


    // ���L����i�JĲ�o�ϰ�ɽեΦ���k
    private void OnTriggerEnter(Collider other)
    {
        //�ˬd�O�_�E���B�O�_�btrugger��
        if (ChangePoint.activeSelf)
        {
            // �ˬd�i�JĲ�o�ϰ쪺����O�_�O���a
            if (other.CompareTag("Player"))
            {
                // �[�����w������
                SceneManager.LoadScene(sceneName);
            }
        }
    }
}
