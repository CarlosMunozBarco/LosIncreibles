using UnityEngine;

public class Laugh : MonoBehaviour
{
    private Enemy currentEnemy;

    private void Awake()
    {
        currentEnemy = GetComponent<Enemy>();
    }

    public void TriggerLaugh(Enemy enemy)
    {
        if(enemy == currentEnemy)
        {
            enemy.canPlayThisTurn = false;
            Destroy(this);
        }
        
    }
}
