using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SleepActivityManager : MonoBehaviour
{
    public Transform selectedItemsPanel;
    public GameObject iconTemplate;

    public SleepItem[] objetosCorrectos;

    public TMP_Text feedbackText;

    public void AddIcon(Sprite icon)
    {
        GameObject newIcon = Instantiate(iconTemplate, selectedItemsPanel);

        newIcon.SetActive(true);

        Image image = newIcon.GetComponent<Image>();

        image.sprite = icon;
    }

    public void CheckAnswers()
    {
        int faltantes = 0;

        foreach (SleepItem item in objetosCorrectos)
        {
            if (!item.fueSeleccionado)
            {
                faltantes++;
            }
        }

        if (faltantes == 0)
        {
            feedbackText.text = "¡Excelente!\nIdentificaste todos los objetos.";
        }
        else
        {
            feedbackText.text = "Buen intento.\nAún te faltan "
                                + faltantes
                                + " objetos por identificar.";
        }
    }
}