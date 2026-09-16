using UnityEngine;

public class KaiSequence : MonoBehaviour
{
[SerializeField] private GameObject iconoTapete1;

private AudioSource audioSource;
private bool audioComenzo = false;

void Start()
{
    audioSource = GetComponent<AudioSource>();

    if (iconoTapete1 != null)
    {
        iconoTapete1.SetActive(false);
    }
}

void Update()
{
    if (audioSource == null)
        return;

    if (audioSource.isPlaying)
    {
        audioComenzo = true;
    }

    if (audioComenzo && !audioSource.isPlaying)
    {
        if (iconoTapete1 != null)
        {
            iconoTapete1.SetActive(true);
        }

        gameObject.SetActive(false);
    }
}

}