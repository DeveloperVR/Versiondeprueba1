using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject menuButton;
    public GameObject menuPanel;
    public GameObject videoPanel;

    public void OpenMenu()
    {
        menuButton.SetActive(false);

        menuPanel.SetActive(true);
        videoPanel.SetActive(false);
    }

    public void CloseMenu()
    {
        menuPanel.SetActive(false);

        menuButton.SetActive(true);
    }
}