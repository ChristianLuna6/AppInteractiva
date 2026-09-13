using UnityEngine;
using UnityEngine.SceneManagement;

public class NavegacionLibro : MonoBehaviour
{
    public void SiguientePagina()
    {
        int escenaActual = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(escenaActual + 1);
    }

    public void PaginaAnterior()
    {
        int escenaActual = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(escenaActual - 1);
    }
}