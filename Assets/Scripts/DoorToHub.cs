using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorToHub : MonoBehaviour
{
    public void GoToHub()
    {
        SceneManager.LoadScene("HUB");
    }
}
