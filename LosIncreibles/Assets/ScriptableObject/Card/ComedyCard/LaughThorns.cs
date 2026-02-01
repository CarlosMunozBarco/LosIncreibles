using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "LaughThorns", menuName = "Cards/LaughThorns")]
public class LaughThorns : Card
{
    public int thornsStack = 5;
    public float damage;
    public override void PlayCard()
    {
        if(MaskManager.Instance.currentMask.maskInfo.maskType == MaskType.Comedy)
        {
            CombatManager.Instance.GetPlayer().Attack(damage + 5);        
        }else
        {
            CombatManager.Instance.GetPlayer().Attack(damage);        
        }
        if (CombatManager.Instance.GetCurrentEnemy().GetComponent<Laugh>() != null )
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
            }else
            {
                Debug.Log("CombatManager bugeado, no hay enemigo");
            }
        }
    }
}
