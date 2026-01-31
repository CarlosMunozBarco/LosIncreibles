using UnityEngine;

[CreateAssetMenu(fileName = "DramaMask", menuName = "Masks/DramaMask")]
public class DramaMask : Mask
{
    public int poisonStacksPerHit = 2;
    public float damagePerStack = 1f;

    public override void ApplyMaskEffect()
    {
        Player player = CombatManager.Instance.player;
        if(player.GetComponent<Drama>() == null)
        {
            Drama drama = player.gameObject.AddComponent<Drama>();
            drama.poisonStacksPerHit = poisonStacksPerHit;
            drama.damagePerStack = damagePerStack;
        }
    }

    public override void RemoveMaskEffect()
    {
        Player player = CombatManager.Instance.player;
        Drama drama = player.GetComponent<Drama>();
        if (drama != null)
        {
            Destroy(drama);
        }
    }
}
