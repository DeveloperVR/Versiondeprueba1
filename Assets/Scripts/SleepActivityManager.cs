using UnityEngine;
using UnityEngine.UI;

public class SleepActivityManager : MonoBehaviour
{
    public Transform selectedItemsPanel;
    public GameObject iconTemplate;

    public void AddIcon(Sprite icon)
    {
        GameObject newIcon = Instantiate(iconTemplate, selectedItemsPanel);

        newIcon.SetActive(true);

        Image image = newIcon.GetComponent<Image>();

        image.sprite = icon;
    }
}
