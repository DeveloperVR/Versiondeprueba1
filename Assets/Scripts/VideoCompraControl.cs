
using UnityEngine;
using UnityEngine.Video;

public class VideoCompraControl : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject videoQuad;
    [SerializeField] private AudioClip audioFinal;
    [SerializeField] private GameObject kai;

    private VideoPlayer videoPlayer;
    private AudioSource audioSource;
    private Animator kaiAnimator;

    private bool reproduciendoAudioInicial = false;

    private void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        audioSource = GetComponent<AudioSource>();

        if (kai != null)
        {
            kaiAnimator = kai.GetComponent<Animator>();
        }

        videoQuad.SetActive(false);

        videoPlayer.loopPointReached += VideoTerminado;
    }

    public void IniciarSecuencia()
    {
        if (canvas != null)
        {
            canvas.SetActive(false);
        }

        reproduciendoAudioInicial = true;

        if (kaiAnimator != null)
        {
            kaiAnimator.enabled = true;
        }

        audioSource.Play();
    }

    private void Update()
    {
        if (reproduciendoAudioInicial && !audioSource.isPlaying)
        {
            reproduciendoAudioInicial = false;

            if (kaiAnimator != null)
            {
                kaiAnimator.enabled = false;
            }

            videoQuad.SetActive(true);
            videoPlayer.Play();
        }
    }

    private void VideoTerminado(VideoPlayer vp)
    {
        videoQuad.SetActive(false);

        if (audioFinal != null)
        {
            audioSource.clip = audioFinal;

            if (kaiAnimator != null)
            {
                kaiAnimator.enabled = true;
            }

            audioSource.Play();
        }
    }

    private void OnDestroy()
    {
        if (videoPlayer != null)
        {
            videoPlayer.loopPointReached -= VideoTerminado;
        }
    }
}
