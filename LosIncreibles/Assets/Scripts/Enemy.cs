using System;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour, Turnable
{
    public static event Action<Turnable> OnTurnEnd;

    private bool isMyTurn = false;
    private bool hasActed = false;

    private void Update()
    {
        if(isMyTurn && !hasActed)
        {
            Debug.Log("Considerate atacado");
            hasActed = true;
            StartCoroutine(FinishTurn());
        }
    }

    private IEnumerator FinishTurn()
    {
        yield return new WaitForSeconds(3f); // Simulate thinking time
        EndTurn();
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
}
