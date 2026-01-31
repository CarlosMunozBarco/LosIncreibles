using UnityEngine;

[CreateAssetMenu(fileName = "FearMask", menuName = "Masks/FearMask")]
public class FearMask : Mask
{
    public float dodgeChance = 0.2f;
    public override void ApplyMaskEffect()
    {
        Player player = CombatManager.Instance.player;
        player.UpdateDodge(dodgeChance);

        if (player.GetComponent<Fear>() == null)
        {
            player.gameObject.AddComponent<Fear>();
        }

    }

    public override void RemoveMaskEffect()
    {
        Player player = CombatManager.Instance.player;
        player.UpdateDodge(-dodgeChance);
        Fear fearComponent = player.GetComponent<Fear>();
        if (fearComponent != null)
        {
            Destroy(fearComponent);
        }
    }
}
