using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject menuButton;
    public GameObject menuPanel;
    public GameObject videoPanel;

    private bool isOpen = false;

    public void ToggleMenu()
    {
        isOpen = !isOpen;

        menuButton.SetActive(!isOpen);
        menuPanel.SetActive(isOpen);

        if (videoPanel != null)
            videoPanel.SetActive(!isOpen);
    }

    public void CloseMenu()
    {
        isOpen = false;

        menuPanel.SetActive(false);
        menuButton.SetActive(true);

        if (videoPanel != null)
            videoPanel.SetActive(true);
    }
}