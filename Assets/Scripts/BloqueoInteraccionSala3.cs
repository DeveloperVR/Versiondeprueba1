using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BloqueoInteraccionSala3 : MonoBehaviour
{
    [SerializeField] private XRRayInteractor controlIzquierdo;
    [SerializeField] private XRRayInteractor controlDerecho;

    public void Bloquear()
    {
        if (controlIzquierdo != null)
            controlIzquierdo.enabled = false;

        if (controlDerecho != null)
            controlDerecho.enabled = false;
    }

    public void Desbloquear()
    {
        if (controlIzquierdo != null)
            controlIzquierdo.enabled = true;

        if (controlDerecho != null)
            controlDerecho.enabled = true;
    }
}