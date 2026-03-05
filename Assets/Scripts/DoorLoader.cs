using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorLoader : MonoBehaviour
{
    public string sceneToLoad;
    public int salaID;

    public void LoadScene()
    {
        SceneEntryData.salaID = salaID;
        SceneManager.LoadScene(sceneToLoad);
    }
}
