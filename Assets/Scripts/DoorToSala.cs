using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorToSala : MonoBehaviour
{
    public string sceneName;

    public void GoToSala()
    {
        
        SceneManager.LoadScene(sceneName);
    }
}
