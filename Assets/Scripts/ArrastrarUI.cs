using UnityEngine;
using UnityEngine.EventSystems;

public class ArrastrarUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;
    private Vector2 posicionInicial;
    private bool colocado = false;
    private Animator animator;

    public RectTransform zonaCorrecta;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        posicionInicial = rectTransform.anchoredPosition;

        // Si tiene Animator, empieza quieto
        if (animator != null)
        {
            animator.SetBool("isWalking", false);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (colocado)
            return;

        // Si tiene Animator, empieza a caminar
        if (animator != null)
        {
            animator.SetBool("isWalking", true);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (colocado)
            return;

        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (colocado)
            return;

        if (RectTransformUtility.RectangleContainsScreenPoint(
            zonaCorrecta,
            eventData.position,
            canvas.worldCamera))
        {
            rectTransform.position = zonaCorrecta.position;
            colocado = true;

            // Llegó a su casilla → deja de caminar
            if (animator != null)
            {
                animator.SetBool("isWalking", false);
            }
        }
        else
        {
            rectTransform.anchoredPosition = posicionInicial;

            // Lo soltó fuera → deja de caminar
            if (animator != null)
            {
                animator.SetBool("isWalking", false);
            }
        }
    }
}
