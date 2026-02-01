using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShowThings : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public List<GameObject> thingsToShow;

    public void OnPointerEnter(PointerEventData eventData)
    {
        foreach (var thing in thingsToShow)
        {
            thing.SetActive(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        foreach (var thing in thingsToShow)
        {
            thing.SetActive(false);
        }
    }
}
