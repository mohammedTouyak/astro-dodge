using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIButtonFeedback : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    private Vector3 originalScale;

    [SerializeField] private float hoverScale = 1.1f;
    [SerializeField] private float pressedScale = 0.95f;

    [Header("Text")]
    [SerializeField] private TextMeshProUGUI label;

    [SerializeField] private Color normalColor  = new Color32(10, 15, 42, 255);   // #0A0F2A
    [SerializeField] private Color hoverColor   = new Color32(0, 31, 20, 255);    // #001F14
    [SerializeField] private Color pressedColor = new Color32(0, 18, 13, 255);    // #00120D

    private void Start()
    {
        originalScale = transform.localScale;
        if (label != null)
        {
            label.color = normalColor;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale = originalScale * hoverScale;
        if (label != null)
        {
            label.color = hoverColor;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = originalScale;

        if (label != null)
        {
            label.color = normalColor;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        transform.localScale = originalScale * pressedScale;

        if (label != null)
        {
            label.color = pressedColor;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.localScale = originalScale * hoverScale;

        if (label != null)
        {
            label.color = hoverColor;
        }
    }
}