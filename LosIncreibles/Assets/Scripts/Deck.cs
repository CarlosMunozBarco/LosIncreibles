using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Deck : MonoBehaviour
{
    public List<CardUI> cards = new List<CardUI>();
    public CardUI cardUI;
    public int cardsPerTurn = 8;

    private HorizontalLayoutGroup hlg;

    private void OnEnable()
    {
        CardUI.OnCardPlayed += RemoveCard;
        TurnManager.OnTurnChanged += TurnChanged;
    }

    private void OnDisable()
    {
        CardUI.OnCardPlayed -= RemoveCard;
        TurnManager.OnTurnChanged -= TurnChanged;

    }

    private void Awake()
    {
        hlg = GetComponent<HorizontalLayoutGroup>();
        //hlg.enabled = false;
    }

    public void RemoveCard(CardUI card)
    {
        cards.Remove(card);
    }

    private void TurnChanged(Turn turn)
    {
        if (turn == Turn.Player)
        {
            DrawCards();
        }
    }

    public void DrawCards()
    {
        //hlg.enabled = true;
        for(int i = cards.Count; i < cardsPerTurn; i++)
        {
            Card card = CardsManager.Instance.GetRandomCard();
            CardUI cardUIaux = Instantiate(cardUI, transform);
            cardUIaux.Initialialize(card);
            cards.Add(cardUIaux);
        }
        //hlg.enabled = true;
    }
}
