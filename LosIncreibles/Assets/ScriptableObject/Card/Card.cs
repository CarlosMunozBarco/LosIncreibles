using UnityEngine;

public abstract class Card : ScriptableObject
{
    public CardInfo info;

    public abstract void PlayCard();
}
