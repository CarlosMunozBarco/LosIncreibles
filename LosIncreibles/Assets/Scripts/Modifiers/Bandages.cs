using UnityEngine;

public class Bandages : MonoBehaviour
{
    public Player player;
    public Enemy targetEnemy;
    public int bandagesStack;

    void OnEnable()
    {
        TurnManager.OnTurnChanged += HandleTurnChanged;
    }
    void Awake()
    {
        player = GetComponent<Player>();
    }
    void OnDisable()
    {
        TurnManager.OnTurnChanged -= HandleTurnChanged;
    }

   
    public void AddBandagesStacks(int numberStack)
    {
        bandagesStack += numberStack;
    }
    private void HandleTurnChanged(Turn turn)
    {
        if(turn == Turn.Player)
        {
            CombatManager.Instance.player.Heal(5);
            bandagesStack--;

            if(bandagesStack <= 0)
            {
                Destroy(this);
            }
        }
    }

}
