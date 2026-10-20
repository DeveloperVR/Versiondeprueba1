
using UnityEngine;

public class KaiSequence : MonoBehaviour
{
    [SerializeField] private GameObject iconoTapete1;
    [SerializeField] private GameObject iconoTapete2;
    [SerializeField] private AudioClip audio2;
    [SerializeField] private AudioClip audio3;
    [SerializeField] private BloqueoInteraccionSala3 bloqueoInteraccion;

    private AudioSource audioSource;
    private bool audioComenzo = false;
    private bool audioProcesado = false;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        audioComenzo = false;
        audioProcesado = false;
    }

    private void Start()
    {
        if (iconoTapete1 != null)
            iconoTapete1.SetActive(false);

        if (iconoTapete2 != null)
            iconoTapete2.SetActive(false);

        if (audioSource != null && audioSource.isPlaying)
        {
            audioComenzo = true;

            if (bloqueoInteraccion != null)
                bloqueoInteraccion.Bloquear();
        }
    }

    private void Update()
    {
        if (audioSource == null || audioProcesado)
            return;

        if (audioSource.isPlaying)
        {
            audioComenzo = true;

            if (bloqueoInteraccion != null)
                bloqueoInteraccion.Bloquear();

            return;
        }

        if (!audioComenzo)
            return;

        audioProcesado = true;
        audioComenzo = false;

        if (bloqueoInteraccion != null)
            bloqueoInteraccion.Desbloquear();

        if (audioSource.clip == audio3)
        {
            gameObject.SetActive(false);
        }
        else if (audioSource.clip == audio2)
        {
            if (iconoTapete2 != null)
                iconoTapete2.SetActive(true);

            gameObject.SetActive(false);
        }
        else
        {
            if (iconoTapete1 != null)
                iconoTapete1.SetActive(true);

            gameObject.SetActive(false);
        }
    }
}
