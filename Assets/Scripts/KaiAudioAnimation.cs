
using UnityEngine;
using UnityEngine.SceneManagement;

public class KaiAudioAnimation : MonoBehaviour
{
    [SerializeField] private AudioClip audioDespedida;

    private AudioSource audioSource;
    private Animator animator;

    private bool esHub;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();

        esHub = SceneManager.GetActiveScene().name == "HUB";

        // Si estamos en el Prehub, mantener el comportamiento original
        if (!esHub)
        {
            return;
        }

        int origenHub = PlayerPrefs.GetInt("OrigenHub", -2);

        // Viene del Prehub: audio de bienvenida
        if (origenHub == -1)
        {
            if (audioSource != null)
            {
                audioSource.Play();
            }

            return;
        }

        // Viene de Sala 5: audio de despedida
        if (origenHub == 4)
        {
            if (audioSource != null && audioDespedida != null)
            {
                audioSource.clip = audioDespedida;
                audioSource.Play();
            }

            return;
        }

        // Viene de Sala 1-4: no reproducir nada
        if (audioSource != null)
        {
            audioSource.Stop();
        }

        if (animator != null)
        {
            animator.enabled = false;
        }
    }

    private void Update()
    {
        if (audioSource != null && animator != null)
        {
            if (!audioSource.isPlaying && audioSource.clip != null)
            {
                animator.enabled = false;
                enabled = false;
            }
        }
    }
}

