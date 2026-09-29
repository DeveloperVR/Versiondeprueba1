using UnityEngine;

public class KaiAudioAnimation : MonoBehaviour
{
    private AudioSource audioSource;
    private Animator animator;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
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