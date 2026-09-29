using UnityEngine;

public class CanvasDespuesAudioKai : MonoBehaviour
{
    [SerializeField] private GameObject canvas;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (canvas != null)
        {
            canvas.SetActive(false);
        }
    }

    private void Update()
    {
        if (audioSource != null && audioSource.clip != null && !audioSource.isPlaying)
        {
            canvas.SetActive(true);
            enabled = false;
        }
    }
}