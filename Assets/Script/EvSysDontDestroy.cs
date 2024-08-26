using UnityEngine;
using UnityEngine.EventSystems;

public class EnsureSingleEventSystem : MonoBehaviour
{
    private void Awake()
    {
        // �d����������Ҧ� Event System ����
        EventSystem[] eventSystems = FindObjectsOfType<EventSystem>();

        // �p�G���h��@�� Event System�A�R���h�l��
        if (eventSystems.Length > 1)
        {
            for (int i = 1; i < eventSystems.Length; i++)
            {
                Destroy(eventSystems[i].gameObject);
            }
        }
        else if (eventSystems.Length == 0)
        {
            // �p�G�S�� Event System�A�Ыؤ@�ӷs��
            GameObject newEventSystem = new GameObject("EventSystem", typeof(EventSystem), typeof(StandaloneInputModule));
        }
    }
}
