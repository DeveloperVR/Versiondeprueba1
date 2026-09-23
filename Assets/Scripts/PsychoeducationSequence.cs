using UnityEngine;

public class PsychoeducationSequence : MonoBehaviour
{
[SerializeField] private GameObject kai;
[SerializeField] private GameObject isa;
[SerializeField] private GameObject menuButtonAnchor;


private AudioSource kaiAudio;
private bool kaiAudioComenzo = false;

private void Start()
{
    kaiAudio = kai.GetComponent<AudioSource>();

    isa.SetActive(false);
    menuButtonAnchor.SetActive(false);
}

private void Update()
{
    if (kaiAudio == null)
        return;

    if (kaiAudio.isPlaying)
    {
        kaiAudioComenzo = true;
    }

    if (kaiAudioComenzo && !kaiAudio.isPlaying)
    {
        kai.SetActive(false);

        isa.SetActive(true);

        AudioSource isaAudio = isa.GetComponent<AudioSource>();

        if (isaAudio != null)
        {
            isaAudio.Play();
        }

        StartCoroutine(EsperarFinalIsa(isaAudio));

        enabled = false;
    }
}

private System.Collections.IEnumerator EsperarFinalIsa(AudioSource isaAudio)
{
    if (isaAudio == null)
        yield break;

    while (isaAudio.isPlaying)
    {
        yield return null;
    }

    isa.SetActive(false);
    menuButtonAnchor.SetActive(true);
}


}
