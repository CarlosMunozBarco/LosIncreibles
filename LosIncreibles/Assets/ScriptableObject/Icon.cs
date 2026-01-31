using UnityEngine;

public class Icon : ScriptableObject
{
    public IconType iconType;
    public GameObject iconPrefab;
}

public enum IconType
{
    Poison,
    Bandages, 
    Laugh,
    Thorns
}
