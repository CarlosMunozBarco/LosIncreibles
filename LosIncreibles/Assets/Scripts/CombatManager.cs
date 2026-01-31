using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public static CombatManager Instance;

    private Player player;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    public Player GetPlayer()
    {
        return player;
    }
}
