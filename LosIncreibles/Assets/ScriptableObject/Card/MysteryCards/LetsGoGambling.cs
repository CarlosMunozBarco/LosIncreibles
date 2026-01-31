using UnityEngine;

[CreateAssetMenu(fileName = "LetsGoGambling", menuName = "Cards/LetsGoGambling")]
public class LetsGoGambling : Card
{
    public override void PlayCard()
    {
        Player player = CombatManager.Instance.player;
        if (player.GetComponent<Mystery>() != null)
        {
            player.GetComponent<Mystery>().AddNumberOfIntents();
        }
    }
}
