using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardInfo", menuName = "Scriptable Objects/CardInfo")]
public class CardInfo : ScriptableObject
{
    public string cardName;
    public Sprite cardImage;
    public string cardDescription;
    public List<GameObject> thingsToShow;

}
