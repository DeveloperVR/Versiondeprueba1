using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoManager : MonoBehaviour
{
    public GameObject videoScreen;
    public GameObject menuPanel;

    public GameObject menuButton;

    public GameObject isa;
    public GameObject atrasButton;

    public VideoPlayer videoPlayer;

    public AudioSource audioIsa;
    public AudioClip audioDespedida;

    public VideoClip farmacoterapiaVideo;
    public VideoClip psicoterapiaVideo;
    public VideoClip neuromodulacionVideo;
    public VideoClip prevalenciaVideo;

    private bool farmacoterapiaVista = false;
    private bool psicoterapiaVista = false;
    private bool neuromodulacionVista = false;
    private bool prevalenciaVista = false;

    private bool despedidaReproduciendose = false;

    private void Start()
    {
        videoPlayer.loopPointReached += VideoFinished;

        atrasButton.SetActive(false);
    }

    private void Update()
    {
        if (despedidaReproduciendose && !audioIsa.isPlaying)
        {
            despedidaReproduciendose = false;
            SceneManager.LoadScene("HUB");
        }
    }

    public void PlayFarmacoterapia()
    {
        PlayVideo(farmacoterapiaVideo);
    }

    public void PlayPsicoterapia()
    {
        PlayVideo(psicoterapiaVideo);
    }

    public void PlayNeuromodulacion()
    {
        PlayVideo(neuromodulacionVideo);
    }

    public void PlayPrevalencia()
    {
        PlayVideo(prevalenciaVideo);
    }

    void PlayVideo(VideoClip clip)
    {
        menuPanel.SetActive(false);

        videoScreen.SetActive(true);

        videoPlayer.clip = clip;

        videoPlayer.Play();
    }

    void VideoFinished(VideoPlayer vp)
    {
        videoPlayer.Stop();

        videoScreen.SetActive(false);

        MarcarVideoComoVisto(vp.clip);

        if (TodosLosVideosFueronVistos())
        {
            atrasButton.SetActive(true);
        }

        menuPanel.SetActive(true);
    }

    void MarcarVideoComoVisto(VideoClip clip)
    {
        if (clip == farmacoterapiaVideo)
        {
            farmacoterapiaVista = true;
        }
        else if (clip == psicoterapiaVideo)
        {
            psicoterapiaVista = true;
        }
        else if (clip == neuromodulacionVideo)
        {
            neuromodulacionVista = true;
        }
        else if (clip == prevalenciaVideo)
        {
            prevalenciaVista = true;
        }
    }

    bool TodosLosVideosFueronVistos()
    {
        return farmacoterapiaVista &&
               psicoterapiaVista &&
               neuromodulacionVista &&
               prevalenciaVista;
    }

    public void CloseMenu()
    {
        menuPanel.SetActive(false);
        menuButton.SetActive(false);

        isa.SetActive(true);

        audioIsa.clip = audioDespedida;
        audioIsa.Play();

        despedidaReproduciendose = true;
    }

    public void ToggleMenu()
    {
        menuPanel.SetActive(true);
        menuButton.SetActive(false);

        isa.SetActive(false);
    }
}