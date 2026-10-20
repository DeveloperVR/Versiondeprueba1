using UnityEngine;
using UnityEngine.Video;
using UnityEngine.XR.Interaction.Toolkit;

public class TapeteVideo : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private GameObject iconoTapete;
    [SerializeField] private GameObject kai;
    [SerializeField] private Transform puntoKai;
    [SerializeField] private AudioClip audio2;
    [SerializeField] private Transform puntoKai2;
    [SerializeField] private AudioClip audio3;
    [SerializeField] private BloqueoInteraccionSala3 bloqueoInteraccion;

    private TeleportationArea teleportationArea;
    private AudioSource kaiAudioSource;

    private void Awake()
    {
        teleportationArea = GetComponent<TeleportationArea>();

        if (kai != null)
            kaiAudioSource = kai.GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        if (teleportationArea != null)
            teleportationArea.selectExited.AddListener(OnTeleportationCompleted);

        if (videoPlayer != null)
            videoPlayer.loopPointReached += OnVideoFinished;
    }

    private void OnDisable()
    {
        if (teleportationArea != null)
            teleportationArea.selectExited.RemoveListener(OnTeleportationCompleted);

        if (videoPlayer != null)
            videoPlayer.loopPointReached -= OnVideoFinished;
    }

    private void OnTeleportationCompleted(SelectExitEventArgs args)
    {
        if (bloqueoInteraccion != null)
            bloqueoInteraccion.Bloquear();

        if (iconoTapete != null)
            iconoTapete.SetActive(false);

        if (videoPlayer != null)
        {
            videoPlayer.gameObject.SetActive(true);
            videoPlayer.Play();
        }
    }

    private void OnVideoFinished(VideoPlayer vp)
    {
        if (videoPlayer != null)
        {
            videoPlayer.Stop();
            videoPlayer.gameObject.SetActive(false);
        }

        if (kai == null)
            return;

        if (puntoKai2 != null && audio3 != null)
        {
            kai.transform.position = puntoKai2.position;
            kai.transform.rotation = Quaternion.Euler(0f, -291.917f, 0f);
            kai.SetActive(true);

            if (kaiAudioSource != null)
            {
                kaiAudioSource.clip = audio3;
                kaiAudioSource.Play();
            }
        }
        else if (puntoKai != null && audio2 != null)
        {
            kai.transform.position = puntoKai.position;
            kai.transform.rotation = Quaternion.Euler(0f, -137.463f, 0f);
            kai.SetActive(true);

            if (kaiAudioSource != null)
            {
                kaiAudioSource.clip = audio2;
                kaiAudioSource.Play();
            }
        }
    }
}