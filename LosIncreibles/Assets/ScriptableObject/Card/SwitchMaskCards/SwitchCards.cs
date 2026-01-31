using UnityEngine;

[CreateAssetMenu(fileName = "SwitchCards", menuName = "Scriptable Objects/SwitchCards")]
public class SwitchCards : Card
{
    public Mask currentMask;
    public Mask nextMask;
    public float damage = 5f;

    public override void PlayCard()
    {
        if (MaskManager.Instance.currentMask == currentMask)
        {
            MaskManager.Instance.ChangeMask(nextMask);
        }

        CombatManager.Instance.GetPlayer().Attack(damage);
    }

}
