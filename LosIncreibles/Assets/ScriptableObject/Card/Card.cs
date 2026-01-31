using System;
using UnityEngine;

public abstract class Card : ScriptableObject
{
    public CardInfo info;
    public MaskType maskType;
    public abstract void PlayCard();
}
