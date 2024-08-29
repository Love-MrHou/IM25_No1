using UnityEngine;
using UnityEngine.SceneManagement; // 引入場景管理

public class SceneChangerButton : MonoBehaviour
{
    // 設置要加載的場景名稱
    public string sceneName;
    public GameObject ChangePoint;

    void Start()
    {
        ChangePoint.SetActive(false);
    }

    // 當按下按鈕時調用此方法
    public void ChangeSceneButton()
    {
        // 檢查是否激活
        if (ChangePoint.activeSelf)
        {
            // 加載指定的場景
            SceneManager.LoadScene(sceneName);
        }
    }
}
