using UnityEngine;

public class SleepItem : MonoBehaviour
{
    public SleepActivityManager manager;

    public Sprite itemIcon;


    public bool fueSeleccionado = false;


    public void Selected()
    {
        if (fueSeleccionado)
            return;


        fueSeleccionado = true;


        manager.AddIcon(itemIcon);

        Debug.Log(gameObject.name + " seleccionado");
    }
}