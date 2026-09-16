using UnityEngine;
using UnityEngine.Video;
using UnityEngine.XR.Interaction.Toolkit;

public class TapeteVideo : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer;

    private TeleportationArea teleportationArea;

    private void Awake()
    {
        teleportationArea = GetComponent<TeleportationArea>();
    }

    private void OnEnable()
    {
        if (teleportationArea != null)
        {
            teleportationArea.selectExited.AddListener(OnTeleportationCompleted);
        }
    }

    private void OnDisable()
    {
        if (teleportationArea != null)
        {
            teleportationArea.selectExited.RemoveListener(OnTeleportationCompleted);
        }
    }

    private void OnTeleportationCompleted(SelectExitEventArgs args)
    {
        if (videoPlayer != null)
        {
            videoPlayer.gameObject.SetActive(true);
            videoPlayer.Play();
        }
    }
}