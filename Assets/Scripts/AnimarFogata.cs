using UnityEngine;
using UnityEngine.UI;

public class AnimarFogata : MonoBehaviour
{
    public Sprite[] frames;
    public float velocidad = 0.1f;

    private Image imagen;
    private int frameActual = 0;
    private float tiempo = 0f;

    void Start()
    {
        imagen = GetComponent<Image>();
    }

    void Update()
    {
        tiempo += Time.deltaTime;

        if (tiempo >= velocidad)
        {
            tiempo = 0f;

            frameActual++;

            if (frameActual >= frames.Length)
            {
                frameActual = 0;
            }

            imagen.sprite = frames[frameActual];
        }
    }
}