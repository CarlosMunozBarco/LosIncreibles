using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Enemy : MonoBehaviour, Turnable
{
    public static event Action<Turnable> OnTurnEnd;
    public static event Action<Enemy> OnEnemyDie;
     public static event Action<Enemy> OnEnemyAttack;

    public GameObject iconsHolder;
    public List<IconImage> icons;
    private List<IconType> currentIcons;


    public float maxHP = 100f;
    public float shield = 0;
    public int damage = 15;
    public float dodgeChance = 0f;
    public bool isBoss = false;

    private float currentHP;
    private bool isMyTurn = false;
    private bool hasActed = false;

    public bool canPlayThisTurn = true;
    private bool hasDied = false;

    public Slider hpUI;
    public Slider shieldUI;

    private void Start()
    {
        currentHP = maxHP;
        currentIcons = new List<IconType>();
    }
    private void Update()
    {
        if (isMyTurn && !hasActed)
        {
            StartCoroutine(FinishTurn());

            if(canPlayThisTurn)
                AttackPlayer();

            hasActed = true;
        }
        CheckIcons();
    }

    public void CheckIcons()
    {
        if(GetComponent<Bandages>() != null)
        {
            if(!currentIcons.Contains(IconType.Bandages))
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

        if(GetComponent<Laugh>() != null)
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

    private IEnumerator FinishTurn()
    {
        yield return new WaitForSeconds(3f);
        canPlayThisTurn = true;
        EndTurn();
    }

    public void AttackPlayer()
    {
        Debug.Log("Attacking Player for " + damage + " damage.");
        CombatManager.Instance.player.TakeDamage(damage);
        OnEnemyAttack?.Invoke(this);
    }


    public void EndTurn()
    {
        isMyTurn = false;
        OnTurnEnd?.Invoke(this);

    }

    public void StartTurn()
    {
        isMyTurn = true;
        hasActed = false;
    }

    public void TakeDamage(float damage)
    {
        if (UnityEngine.Random.value < dodgeChance)
        {
            return;
        }

        float effectiveDamage = damage - shield;
        if (effectiveDamage < 0) effectiveDamage = 0;

        currentHP -= effectiveDamage;
        UpdateUI();
        if (currentHP <= 0 && !hasDied)
        {
            Die();
        }
        
    }

    private void Die()
    {
        hasDied = true;
        OnEnemyDie.Invoke(this);
        Destroy(gameObject);
    }

    public void Heal(float amount)
    {
        currentHP += amount;
        if (currentHP > maxHP)
        {
            currentHP = maxHP;
        }
        UpdateUI();
    }

    public void AddShield(float amount)
    {
        shield += amount;
        UpdateUI();
    }

    public void UpdateUI()
    {
        hpUI.value = currentHP / maxHP;

        if (shield > 0)
        {
            shieldUI.gameObject.SetActive(true);
            shieldUI.value = shield;
        }
        else
        {
            shieldUI.gameObject.SetActive(false);
        }
    }
}
