using UnityEngine;

public class MaskManager : MonoBehaviour
{
    public static MaskManager Instance;
    public Mask currentMask;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    private void Start()
    {
        EquipMask(currentMask);
    }

    public void ChangeMask(Mask newMask)
    {
        QuitMask();
        EquipMask(newMask);
    }

    private void QuitMask()
    {
        if (currentMask != null)
        {
            currentMask.RemoveMaskEffect();
            currentMask = null;
        }
    }

    public void EquipMask(Mask newMask)
    {
        currentMask = newMask;
        currentMask.ApplyMaskEffect();
    }


    public void HandleCardPlayed(CardUI card)
    {
        if(card.card.maskType != currentMask.maskInfo.maskType)
        {
            ApplyDebuff(card.card.maskType);
        }
    }

    private void ApplyDebuff(MaskType playedMaskType)
    {
        switch(playedMaskType)
        {
            case MaskType.Mystery:
                MysteryDebuff();
                break;
            case MaskType.Comedy:
                ComedyDebuff();
                break;
            case MaskType.Terror:
                TerrorDebuff();
                break;
            case MaskType.Drama:
                DramaDebuff();
                break;
            default:
                Debug.Log("No Debuff Applied.");
                break;
        }
    }

    private void ComedyDebuff()
    {
        foreach(Enemy enemy in EnemyManager.Instance.GetAllEnemies())
        {
            enemy.Heal(5);
            enemy.AddShield(5);
        }
    }

    private void TerrorDebuff()
    {
        CombatManager.Instance.player.TakeDamage(5);
    }

    private void DramaDebuff()
    {
        Player player = CombatManager.Instance.player;
        if (player.GetComponent<Drama>() == null)
        {
            Drama drama = player.gameObject.AddComponent<Drama>();
            drama.poisonStacksPerHit = 1;
            drama.damagePerStack = 1;
        }
        else
        {
            Drama drama = player.GetComponent<Drama>();
            drama.poisonStacksPerHit += 1;
        }
    }

    private void MysteryDebuff()
    {
        if(Random.value < 0.5f)
        {
            CombatManager.Instance.player.TakeDamage(5);
        }
        else
        {
            CombatManager.Instance.GetCurrentEnemy().shield += 15;
        }
    }
}
