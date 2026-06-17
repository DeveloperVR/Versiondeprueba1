using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    public GameObject videoScreen;
    public GameObject menuPanel;

    public GameObject menuButton;

    public VideoPlayer videoPlayer;


    public VideoClip farmacoterapiaVideo;
    public VideoClip psicoterapiaVideo;
    public VideoClip neuromodulacionVideo;
    public VideoClip prevalenciaVideo;


    private void Start()
    {
        videoPlayer.loopPointReached += VideoFinished;
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

        menuPanel.SetActive(true);
    }



    public void CloseMenu()
{
    menuPanel.SetActive(false);
    menuButton.SetActive(true);
}

   public void ToggleMenu()
{
    menuPanel.SetActive(true);
    menuButton.SetActive(false);
}
}