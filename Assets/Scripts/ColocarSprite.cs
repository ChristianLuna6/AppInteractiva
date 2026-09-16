using UnityEngine;

public class ColocarSprite : MonoBehaviour
{
    public string juegoCorrecto;
    public Transform zonaCorrecta;

    private Vector3 posicionInicial;

    void Start()
    {
        posicionInicial = transform.position;
    }

    void OnMouseUp()
    {
        if (zonaCorrecta == null)
            return;

        float distancia = Vector2.Distance(transform.position, zonaCorrecta.position);

        if (distancia < 1.5f)
        {
            transform.position = zonaCorrecta.position;
        }
        else
        {
            transform.position = posicionInicial;
        }
    }
}