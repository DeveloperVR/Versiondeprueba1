
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorToHub : MonoBehaviour
{
    public void GoToHub()
    {
        PlayerPrefs.SetInt("OrigenHub", -1);
        PlayerPrefs.Save();

        SceneManager.LoadScene("HUB");
    }
}

