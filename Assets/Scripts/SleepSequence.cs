using UnityEngine;

public class SleepSequence : MonoBehaviour
{
    [SerializeField] private GameObject personaje;
    [SerializeField] private GameObject selectionCanvas;
    [SerializeField] private AudioClip audioInicial;
    [SerializeField] private AudioClip audioFinal;

    private AudioSource audioSource;
    private Animator animator;

    private bool reproduciendoAudioInicial = false;
    private bool reproduciendoAudioFinal = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = personaje.GetComponent<Animator>();

        personaje.SetActive(true);
        selectionCanvas.SetActive(false);

        audioSource.clip = audioInicial;
        audioSource.Play();

        if (animator != null)
        {
            animator.enabled = true;
        }

        reproduciendoAudioInicial = true;
    }

    private void Update()
    {
        if (reproduciendoAudioInicial && !audioSource.isPlaying)
        {
            reproduciendoAudioInicial = false;

            if (animator != null)
            {
                animator.enabled = false;
            }

            personaje.SetActive(false);
            selectionCanvas.SetActive(true);
        }

        if (reproduciendoAudioFinal && !audioSource.isPlaying)
        {
            reproduciendoAudioFinal = false;

            if (animator != null)
            {
                animator.enabled = false;
            }

            personaje.SetActive(false);
        }
    }

    public void ActivarAudioFinal()
    {
        selectionCanvas.SetActive(false);

        personaje.SetActive(true);

        if (animator != null)
        {
            animator.enabled = true;
        }

        audioSource.clip = audioFinal;
        audioSource.Play();

        reproduciendoAudioFinal = true;
    }
}