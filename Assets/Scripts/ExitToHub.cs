
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitToHub : MonoBehaviour
{
    public enum SalaDeOrigen
    {
        Sala1,
        Sala2,
        Sala3,
        Sala4,
        Sala5
    }

    [SerializeField] private SalaDeOrigen salaDeOrigen;

    public void GoToHub()
    {
        PlayerPrefs.SetInt("OrigenHub", (int)salaDeOrigen);
        PlayerPrefs.Save();

        SceneManager.LoadScene("HUB");
    }
}

