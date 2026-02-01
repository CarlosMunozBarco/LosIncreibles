using UnityEngine;

[CreateAssetMenu(fileName = "SwitchCards", menuName = "Scriptable Objects/SwitchCards")]
public class SwitchCards : Card
{
    public Mask currentMask;
    public Mask nextMask;
    public float damage = 5f;

    public override void PlayCard()
    {
        Debug.Log($"Checking condition: {MaskManager.Instance.currentMask.maskInfo.maskType} == {currentMask.maskInfo.maskType} || {currentMask.maskInfo.maskType} == {MaskType.Default}");
        if ((MaskManager.Instance.currentMask.maskInfo.maskType == currentMask.maskInfo.maskType || currentMask.maskInfo.maskType == MaskType.Default) ||
            MaskManager.Instance.currentMask.maskInfo.maskType == MaskType.Default)
        {
            Debug.Log("Switching Mask to: " + nextMask.maskInfo.maskType);
            MaskManager.Instance.ChangeMask(nextMask);
        }

        CombatManager.Instance.GetPlayer().Attack(damage);
    }

}
