using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour, Turnable
{
    public static event Action OnPlayerAttack;
    public static event Action<Turnable> OnTurnEnd;

    public GameObject iconsHolder;
    public List<IconImage> icons;
    private List<IconType> currentIcons;

    private bool isMyTurn = true;

    public float maxHP = 100f;
    private float shield = 0;
    private float currentHP;

    private float dodgeChance = 0f;
    private Animator animator;

    private float nextAttackDamage = 0;

    private void Start()
    {
        currentHP = maxHP;
        UIManager.Instance.UpdateHealthUI(currentHP, maxHP);
        UIManager.Instance.UpdateShieldUI(shield, maxHP);
        currentIcons = new List<IconType>();
        animator = GetComponent<Animator>();
    }


    private void Update()
    {
        if(isMyTurn)
        {
            if (InputSystem.actions["Jump"].triggered)
            {
                EndTurn();
            }
        }

        CheckIcons();
    }

    public void UpdateShield(float amount)
    {
        shield += amount;
        if (shield < 0) shield = 0;
        if(shield > maxHP) shield = maxHP;

        UIManager.Instance.UpdateShieldUI(shield, maxHP);
    }

    public void CheckIcons()
    {
        if (GetComponent<Bandages>() != null)
        {
            if (!currentIcons.Contains(IconType.Bandages))
            {
                currentIcons.Add(IconType.Bandages);
                IconImage icon = icons.Find((IconImage i) => i.type == IconType.Bandages);
                Instantiate(icon.gameObject, iconsHolder.transform);
            }
        }
        else
        {
            currentIcons.Remove(IconType.Bandages);
        }

        if (GetComponent<Laugh>() != null)
        {
            if (!currentIcons.Contains(IconType.Laugh))
            {
                currentIcons.Add(IconType.Laugh);
                IconImage icon = icons.Find((IconImage i) => i.type == IconType.Laugh);
                Instantiate(icon.gameObject, iconsHolder.transform);
            }
        }
        else
        {
            currentIcons.Remove(IconType.Laugh);
        }

        if (GetComponent<Poison>() != null)
        {
            Debug.Log("Enemy has Poison");
            if (!currentIcons.Contains(IconType.Poison))
            {
                currentIcons.Add(IconType.Poison);
                IconImage icon = icons.Find((IconImage i) => i.type == IconType.Poison);
                Instantiate(icon.gameObject, iconsHolder.transform);
            }
        }
        else
        {
            currentIcons.Remove(IconType.Poison);
        }

        if (GetComponent<Thorns>() != null)
        {
            if (!currentIcons.Contains(IconType.Thorns))
            {
                currentIcons.Add(IconType.Thorns);
                IconImage icon = icons.Find((IconImage i) => i.type == IconType.Thorns);
                Instantiate(icon.gameObject, iconsHolder.transform);
            }
        }
        else
        {
            currentIcons.Remove(IconType.Thorns);
        }

    }

    public void UpdateDodge(float amount)
    {
        dodgeChance += amount;
        if (dodgeChance < 0) dodgeChance = 0;
        if (dodgeChance > 1) dodgeChance = 1;
    }

    

    public void EndTurn()
    {
        isMyTurn = false;
        OnTurnEnd?.Invoke(this);
    }

    public void StartTurn()
    {
        isMyTurn = true;
    }

    public void Attack(float damage)
    {
        animator.SetTrigger("Attack");
        SoundsManager.Instance.PlaySFX(SFXType.Attack);
        nextAttackDamage = damage;
    }

    public void DealDamage()
    {
        CombatManager.Instance.GetCurrentEnemy().TakeDamage(nextAttackDamage);
        OnPlayerAttack?.Invoke();
    }

    public void TakeDamage(float damage)
    {
        if(UnityEngine.Random.value < dodgeChance)
        {
            Debug.Log("Player dodged the attack!");
            return;
        }

        float effectiveDamage = damage - shield;
        shield -= damage;
        if(shield < 0) shield = 0;
        if (effectiveDamage < 0) effectiveDamage = 0;


        currentHP -= effectiveDamage;
        UIManager.Instance.UpdateHealthUI(currentHP, maxHP);
        UIManager.Instance.UpdateShieldUI(shield, maxHP);
        if (currentHP <= 0)
        {
            GameManager.Instance.PlayerDeath();
        }
    }

    public void TakeTrueDamage(float damage)
    {
        currentHP -= damage;
        if (currentHP <= 0)
        {
            GameManager.Instance.PlayerDeath();
        }
        UIManager.Instance.UpdateHealthUI(currentHP, maxHP);
    }


    public void Heal(float amount)
    {
        currentHP += amount;
        if (currentHP > maxHP)
        {
            currentHP = maxHP;
        }
        UIManager.Instance.UpdateHealthUI(currentHP, maxHP);
    }
}
