using UnityEngine;
using UnityEngine.EventSystems;

public class EnsureSingleEventSystem : MonoBehaviour
{
    private void Awake()
    {
        // 查找場景中的所有 Event System 物件
        EventSystem[] eventSystems = FindObjectsOfType<EventSystem>();

        // 如果有多於一個 Event System，刪除多餘的
        if (eventSystems.Length > 1)
        {
            for (int i = 1; i < eventSystems.Length; i++)
            {
                Destroy(eventSystems[i].gameObject);
            }
        }
        else if (eventSystems.Length == 0)
        {
            // 如果沒有 Event System，創建一個新的
            GameObject newEventSystem = new GameObject("EventSystem", typeof(EventSystem), typeof(StandaloneInputModule));
        }
    }
}
