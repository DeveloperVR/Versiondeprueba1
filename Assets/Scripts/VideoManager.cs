using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public GameObject videoPanel;
    public GameObject menuPanel;

    public VideoClip[] videos;

    void Start()
    {
        videoPlayer.loopPointReached += EndVideo;
    }

    public void PlayVideo(int index)
    {
        videoPanel.SetActive(true);
        menuPanel.SetActive(false);

        videoPlayer.clip = videos[index];
        videoPlayer.Play();
    }

    public void CloseVideo()
    {
        videoPlayer.Stop();
        videoPanel.SetActive(false);
        menuPanel.SetActive(true);
    }

    void EndVideo(VideoPlayer vp)
    {
        CloseVideo();
    }
}