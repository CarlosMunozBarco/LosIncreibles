using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "ThornCard", menuName = "Cards/ThornCard")]
public class ThornCard : Card
{
    public int thornsStack = 5;
    public override void PlayCard()
    {
        if(CombatManager.Instance.player != null)
        {
            if(CombatManager.Instance.player.GetComponent<Thorns>() != null)
            {
                CombatManager.Instance.player.GetComponent<Thorns>().thornsStack += thornsStack;
            }
            else
            {
                CombatManager.Instance.player.AddComponent<Thorns>();
                CombatManager.Instance.player.GetComponent<Thorns>().thornsStack = thornsStack;
            }
        }
        else
        {
            Debug.Log("CombatManager bugeado, no hay enemigo");
        }

    }
}
