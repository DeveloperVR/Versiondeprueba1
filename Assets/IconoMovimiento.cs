using UnityEngine;

public class IconoMovimiento : MonoBehaviour
{
[SerializeField] private float amplitud = 0.1f;
[SerializeField] private float velocidad = 7f;


private Vector3 posicionInicial;

private void Start()
{
    posicionInicial = transform.localPosition;
}

private void Update()
{
    float movimiento = Mathf.Sin(Time.time * velocidad) * amplitud;

    transform.localPosition = posicionInicial + new Vector3(0f, movimiento, 0f);
}


}
