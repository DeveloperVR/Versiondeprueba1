
using UnityEngine;
using UnityEngine.Video;

public class MindfulnessSequence : MonoBehaviour
{
    [SerializeField] private GameObject personaje;
    [SerializeField] private GameObject videoQuad;
    [SerializeField] private VideoPlayer videoPlayer;
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

        videoQuad.SetActive(false);
        personaje.SetActive(true);

        audioSource.clip = audioInicial;
        audioSource.Play();

        if (animator != null)
        {
            animator.enabled = true;
        }

        reproduciendoAudioInicial = true;

        videoPlayer.loopPointReached += VideoTerminado;
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

            videoQuad.SetActive(true);
            videoPlayer.Play();
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

    private void VideoTerminado(VideoPlayer vp)
    {
        videoQuad.SetActive(false);

        personaje.SetActive(true);

        audioSource.clip = audioFinal;
        audioSource.Play();

        if (animator != null)
        {
            animator.enabled = true;
        }

        reproduciendoAudioFinal = true;
    }

    private void OnDestroy()
    {
        if (videoPlayer != null)
        {
            videoPlayer.loopPointReached -= VideoTerminado;
        }
    }
}
