using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MaskInfo", menuName = "Scriptable Objects/MaskInfo")]
public class MaskInfo : ScriptableObject
{
    public MaskType maskType;
    public string maskName;
    [TextArea]public string maskDescription;

    public GameObject thingsToShow;
    public GameObject debuff;

}

public enum MaskType
{
    Mystery,
    Comedy,
    Terror,
    Drama,
    Default
}