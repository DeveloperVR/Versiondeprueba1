using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Transform gridParent;

    public GameObject iconPrefab;

    public void AddIcon(Sprite icon)
    {
        GameObject newIcon =
            Instantiate(iconPrefab, gridParent);

        Image img = newIcon.GetComponent<Image>();

        img.sprite = icon;
    }
}