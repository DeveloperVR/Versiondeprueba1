using UnityEngine;

public class ConsultorioManager : MonoBehaviour
{
    public AudioSource audioIsa;
    public AudioClip audioDespedida;
    public GameObject menuButton;
    public GameObject menuPanel;

    private bool bienvenidaTerminada = false;
    private bool despedidaReproducida = false;

    private void Start()
    {
        menuButton.SetActive(false);
        menuPanel.SetActive(false);
    }

    private void Update()
    {
        // Cuando termina la bienvenida, aparece el botón del menú
        if (!bienvenidaTerminada && !audioIsa.isPlaying && audioIsa.clip != null)
        {
            bienvenidaTerminada = true;
            menuButton.SetActive(true);
        }
    }

    public void CerrarMenu()
    {
        menuPanel.SetActive(false);
        menuButton.SetActive(false);

        if (!despedidaReproducida)
        {
            audioIsa.clip = audioDespedida;
            audioIsa.Play();
            despedidaReproducida = true;
        }
    }
}