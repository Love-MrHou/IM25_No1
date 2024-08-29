using UnityEngine;
using UnityEngine.SceneManagement; // �ޤJ�����޲z

public class SceneChangerButton : MonoBehaviour
{
    // �]�m�n�[���������W��
    public string sceneName;
    public GameObject ChangePoint;

    void Start()
    {
        ChangePoint.SetActive(false);
    }

    // ����U���s�ɽեΦ���k
    public void ChangeSceneButton()
    {
        // �ˬd�O�_�E��
        if (ChangePoint.activeSelf)
        {
            // �[�����w������
            SceneManager.LoadScene(sceneName);
        }
    }
}
