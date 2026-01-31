using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header("GAME UI")]
    // TO-DO REFERENCIAS A LOS TEXTOS DE VIDA
    [SerializeField] private GameObject gameUIObject;
     [Header("Hearts")]
    [SerializeField] private TextMeshProUGUI heartsText;

    [Space(25)]
    [Header("DEFEAT UI")]
    [SerializeField] private GameObject defeatUIObject;

    [Space(25)]
    [Header("VICTORY UI")]
    [SerializeField] private GameObject victoryUIObject;
   
    [Space(25)]
    [Header("PAUSE UI")]
    [SerializeField] private GameObject pauseUIObject;
    private bool pausedGame = false;

    private static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            return instance;
        }
    }

     void Awake()
    {
        // si la instancia es nula...
        if (instance == null)
        {
            // Guardamos en la variable estatica de la instancia el propio objeto
            instance = this;
        }
        // en caso de que ya exista una instancia
        else
        {
            // destruimos el objeto
            Destroy(gameObject);
        }
    }
    void Start()
    {
        // activamos la interfaz del juego
        gameUIObject.SetActive(true);
        // desactivamos la interfaz de muerte
        defeatUIObject.SetActive(false);
        // desactivamos la interfaz de victoria
        victoryUIObject.SetActive(false);
        // desactivamos la interfaz de pausa
        pauseUIObject.SetActive(false);
    }
    void Update()
    {
        // si presionamos la tecla de pausa...
        if (InputSystem.actions["Pause"].WasPressedThisFrame())
        {
            // si esta activado, lo desactivamos y viceversa.
            TogglePauseUI(pausedGame);
            pausedGame = !pausedGame;   
        }
    }

    /// <summary>
    /// Metodo que recibe el número actual de vidas y actualiza el texto en pantalla
    /// </summary>
    /// <param name="currentHearts"></param>
    public void UpdateHeartsText(int currentHearts)
    {
        // heartsText.text = currentHearts.ToString();
    }

      /// <summary>
    /// Metodo que reinicia la escena completa del juego
    /// </summary>
    public void OnRestartButtonPressed()
    {
        // cargamos la escena del juego
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    /// <summary>
    /// Metodo que te lleva a la escena del Menu principal
    /// </summary>
    public void OnMenuButtonPressed()
    {
        SceneManager.LoadScene("MainMenu");
    }

    /// <summary>
    /// Metodo que se pulsara cuando le demos al boton continuar en la pausa
    /// </summary>
    public void OnResumeButtonPressed()
    {
        // llamamos al funcionamiento del input de pausa
        GameManager.Instance.PauseInput();
    }

    /// <summary>
    /// metodo que Activa la UI de la derrota
    /// </summary>
    public void ActivateDefeatUI()
    {
        gameUIObject.SetActive(false);
        defeatUIObject.SetActive(true);
    }
    /// <summary>
    /// metodo que activa la interfaz de victoria
    /// </summary>
    public void ActivateVictoryUI()
    {
        // desactivamos la interfaz de juego
        gameUIObject.SetActive(false);
        // activamos la interfaz de victoria
        victoryUIObject.SetActive(true);
    }
    /// <summary>
    /// metodo que activa o desactiva el menu de pausa segun el parametro
    /// </summary>
    /// <param name="isActive"></param>
    public void TogglePauseUI(bool isActive)
    {
        // activamos o desactivamos el menu de pausa
        pauseUIObject.SetActive(isActive);
        // activamos o desactivamos el menu de juego
        gameUIObject.SetActive(!isActive);
    }


}
