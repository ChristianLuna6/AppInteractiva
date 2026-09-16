using UnityEngine;
using UnityEngine.EventSystems;

public class ArrastrarUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;
    private Vector2 posicionInicial;
    private bool colocado = false;

    public RectTransform zonaCorrecta;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
    }

    void Start()
    {
        posicionInicial = rectTransform.anchoredPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (colocado)
            return;
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
        }
        else
        {
            rectTransform.anchoredPosition = posicionInicial;
        }
    }
}