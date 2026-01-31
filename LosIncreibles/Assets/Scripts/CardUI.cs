using System;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    public static event Action<CardUI> OnCardPlayed;
    public TMP_Text cardNameText;
    public TMP_Text cardDescriptionText;
    public Image sprite;

    public Card card;
    public float cardHeightIncrease = 400f;
    public float YPositionToUseCard = 1000f;
    private Vector3 originalPosition;

    private bool followMouse = false;

    private Vector3 dragOffsetWorld;
    private Camera uiCamera;

    public void Initialialize(Card card)
    {
        this.card = card;
        cardNameText.text = card.info.cardName;
        cardDescriptionText.text = card.info.cardDescription;
        sprite.sprite = card.info.cardImage;
    }

    private void Start()
    {
        uiCamera = Camera.main;
    }

    private void Update()
    {
        if (followMouse)
        {
            var mouseWorld = Input.mousePosition;

            var screenPoint = uiCamera != null ? uiCamera.WorldToScreenPoint(transform.position) : new Vector3(0f, 0f, 0f);
            mouseWorld.z = screenPoint.z;

            var targetWorld = (uiCamera != null ? uiCamera.ScreenToWorldPoint(mouseWorld) : transform.position) + dragOffsetWorld;
            transform.position = targetWorld;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        GameManager.Instance.cardIsBeingHolded = true;
        followMouse = true;

        if (uiCamera == null)
            uiCamera = Camera.main;

        Vector3 mouseWorld = eventData.position;
        var screenPoint = uiCamera != null ? uiCamera.WorldToScreenPoint(transform.position) : new Vector3(0f, 0f, 0f);
        mouseWorld.z = screenPoint.z;

        var pointerWorld = uiCamera != null ? uiCamera.ScreenToWorldPoint(mouseWorld) : transform.position;
        dragOffsetWorld = transform.position - pointerWorld;

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        GameManager.Instance.cardIsBeingHolded = false;
        if (transform.localPosition.y >= YPositionToUseCard)
        {
            PlayCard();
            return;
        }
        followMouse = false;
        transform.localPosition = originalPosition;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(!GameManager.Instance.cardIsBeingHolded)
            HighlightCard();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if(!GameManager.Instance.cardIsBeingHolded)
            UnhighlightCard();
    }

    public void HighlightCard()
    {
        originalPosition = transform.localPosition;
        transform.localScale = Vector3.one * 1.2f;
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + cardHeightIncrease, transform.localPosition.z);
        
    }

    public void UnhighlightCard()
    {
        transform.localScale = Vector3.one * 0.6f;
        transform.localPosition = originalPosition;
        originalPosition = transform.localPosition;

    }

    public void PlayCard()
    {
        card.PlayCard();
        Destroy(gameObject);
    }
}