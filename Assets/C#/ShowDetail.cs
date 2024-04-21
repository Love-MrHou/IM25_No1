using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShowDetail : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

    public Image image2;
    void Start()
    {
        image2.enabled = false;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene("MainScreen");
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        image2.enabled = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image2.enabled = false;
    }
}