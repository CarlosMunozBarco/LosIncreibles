using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class CardsManager : MonoBehaviour
{
    public static CardsManager Instance;

    public List<Card> availableCards;
    public List<Card> playerDeck;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        playerDeck = new List<Card>(availableCards);
    }

    public Card GetRandomCard()
    {
        if (playerDeck.Count == 0)
        {
            playerDeck = new List<Card>(availableCards);
        }
        int randomIndex = Random.Range(0, playerDeck.Count);
        return playerDeck[randomIndex];
    }
}
