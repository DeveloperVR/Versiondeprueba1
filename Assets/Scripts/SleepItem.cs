using UnityEngine;

public class SleepItem : MonoBehaviour
{
    public SleepActivityManager manager;

    public Sprite itemIcon;

    public void Selected()
    {
        manager.AddIcon(itemIcon);

        Debug.Log(gameObject.name + " seleccionado");
    }
}