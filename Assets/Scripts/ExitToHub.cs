using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitToHub : MonoBehaviour
{
    public void GoToHub()
    {
        SceneManager.LoadScene("HUB");
    }
}
