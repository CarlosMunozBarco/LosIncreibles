using UnityEngine;

public class GameManager : MonoBehaviour
{

    private bool isPaused;
    public bool cardIsBeingHolded = false;


    // creamos la instancia del GameManager solo de lectura y modificación privada
    public static GameManager Instance {get; private set;}

    void Awake()
    {
        // inializacion del gameManager (Singleton)
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        Enemy.OnEnemyDie += FinishGame;
    }

    private void OnDisable()
    {
        Enemy.OnEnemyDie -= FinishGame;
    }

    void Start()
    {
        // iniciamos en falso
        isPaused = false;
        // activamos el tiempo de juego a 1 = no esta pausado
        Time.timeScale = 1f;
        
    }

    public void FinishGame(Enemy enemy)
    {
        if(enemy.isBoss)
        {
            EndGame();
        }
    }

    /// <summary>
    /// Metodo que pausa o despausa el juego
    /// </summary>
    public void StopGame()
    {
        // alterna el valor -> si es true pasa a falso, si es falso se vuelve true
        isPaused = !isPaused;
        // La escala de tiempo será 0 si esta pausado y 1 si no lo esta
        // Variables ternarias -> cambiar el valor de una variable en base a una condicion
        // variable = condicion ? valor si se cumple : valor si no se cumple
        //Time.timeScale = isPaused ? 0f : 1f;
    }

    public void PauseInput()
    {
        StopGame();
        // muestra la interfaz de pausa
        UIManager.Instance.TogglePauseUI(!isPaused);
    }
    public void PlayerDeath()
    {
        UIManager.Instance.ActivateDefeatUI();
        UIManager.Instance.gameUIObject.SetActive(false);
        StopGame();
    }

    /// <summary>
    /// Metodo que ejecutamos al terminar el juego (Victoria)
    /// </summary>
    public void EndGame()
    {
        // activmaos la interfaz de victoria
        UIManager.Instance.ActivateVictoryUI();
        UIManager.Instance.gameUIObject.SetActive(false);
        // pausamos el juego
        StopGame();
    }
}
