using UnityEngine;

[CreateAssetMenu(fileName = "Mask", menuName = "Scriptable Objects/Mask")]
public abstract class Mask : ScriptableObject
{
    public MaskInfo maskInfo;

    public abstract void ApplyMaskEffect();

    public abstract void RemoveMaskEffect();

}

