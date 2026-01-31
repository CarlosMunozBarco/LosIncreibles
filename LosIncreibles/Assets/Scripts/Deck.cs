using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Deck : MonoBehaviour
{
    public List<CardUI> cards = new List<CardUI>();
    public CardUI cardUI;
    public int cardsPerTurn = 8;

    public int cardsRemainingToPlay = 4;

    private HorizontalLayoutGroup hlg;

    private void OnEnable()
    {
        CardUI.OnCardPlayed += RemoveCard;
        TurnManager.OnTurnChanged += TurnChanged;
        hlg = GetComponent<HorizontalLayoutGroup>();

    }

    private void OnDisable()
    {
        CardUI.OnCardPlayed -= RemoveCard;
        TurnManager.OnTurnChanged -= TurnChanged;

    }

    public void RemoveCard(CardUI card)
    {
        cardsRemainingToPlay--;
        UIManager.Instance.UpdateCardsRemainingText(cardsRemainingToPlay);
        cards.Remove(card);
    }

    private void TurnChanged(Turn turn)
    {
        if (turn == Turn.Player)
        {
            cardsRemainingToPlay = 3;
            UIManager.Instance.UpdateCardsRemainingText(cardsRemainingToPlay);
            DrawCards();
        }
    }

    public async void DrawCards()
    {
        hlg.enabled = true;
        for(int i = cards.Count; i < cardsPerTurn; i++)
        {
            Card card = CardsManager.Instance.GetRandomCard();
            CardUI cardUIaux = Instantiate(cardUI, transform);
            cardUIaux.Initialialize(card);
            cards.Add(cardUIaux);
        }

        await Task.Delay(250);
        hlg.enabled = false;
    }
}
