using JetBrains.Annotations;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("GAME UI")]
    // TO-DO REFERENCIAS A LOS TEXTOS DE VIDA
    [SerializeField] private GameObject gameUIObject;
     [Header("Hearts")]
    [SerializeField] private Slider playerHealth;
    [SerializeField] private Slider playerShield;
    [SerializeField] private TextMeshProUGUI cardsText;

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

    [Header("MASKS")]
    public TMP_Text currentMask;
    public GameObject thingsToShow;

    [Header("TURN")]
    public TMP_Text turnText;

    [Header("Mask")]
    public List<MaskToImage> maskToImages;
    public Image maskImage;

    private static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            return instance;
        }
    }

    private void OnEnable()
    {
        MaskManager.OnMaskUpdated += UpdateMaskImage;
    }

    private void OnDisable()
    {
        MaskManager.OnMaskUpdated -= UpdateMaskImage;
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

        UpdateMaskImage(MaskManager.Instance.currentMask.maskInfo.maskType);
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

    public Sprite GetMaskImage(MaskType maskType)
    {
        MaskToImage maskToImage = maskToImages.Find(m => m.maskType == maskType);
        return maskToImage.maskSprite;
    }

    private void UpdateMaskImage(MaskType newMask)
    {
        MaskToImage maskToImage = maskToImages.Find(m => m.maskType == newMask);
        if (maskToImage.maskSprite != null)
        {
            maskImage.sprite = maskToImage.maskSprite;
            maskImage.CrossFadeAlpha(1f, 0f, false);
            Debug.Log("Mascara cambiada a: " + newMask.ToString() + " Image alpha: " + maskImage.color.a);
        }
        else
        {
            maskImage.CrossFadeAlpha(0f, 0f, false);
        }

        for(int i = 0; i < thingsToShow.transform.childCount; i++)
        {
            Destroy(thingsToShow.transform.GetChild(i).gameObject);
        }

        GameObject thingToShow = MaskManager.Instance.currentMask.maskInfo.thingsToShow;
        Instantiate(thingToShow, thingsToShow.transform);

        UpdateMaskUI();
    }

    /// <summary>
    /// Metodo que recibe el número actual de cartas restantes y actualiza el texto en pantalla
    /// </summary>
    /// <param name="cardsRemaining"></param>

    public void UpdateCardsRemainingText(int cardsRemaining)
    {
        cardsText.text = $"{cardsRemaining.ToString()} / 4";
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
    /// Metodo en el cual vamos a pasar de turno 
    /// </summary>
    public void OnTurnButtonPressed()
    {
        if (TurnManager.Instance.currentTurn == Turn.Player)
        {
            CombatManager.Instance.player.EndTurn();     
        }
    }
    /// <summary>
    /// Metodo que recibe el número actual de vidas y actualiza el texto en pantalla
    /// </summary>
    /// <param name="currentHealth"></param>
    public void UpdateHealthUI(float currentHealth, float maxHealth)
    {
        playerHealth.value = currentHealth / maxHealth;
    }

    public void UpdateShieldUI(float currentShield, float maxShield)
    {
        playerShield.value = currentShield / maxShield;
    }

    public void UpdateCardsRemainigText(int cardsRemaining)
    {
        cardsText.text = $"{cardsRemaining.ToString()} / 3";
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
        // TO_DO añadimos block screen para evitar interacciones con la ui

    }

    public void UpdateMaskUI()
    {
        currentMask.text = MaskManager.Instance.currentMask.maskInfo.maskName;
    }

    public void UpdateTurnUI(string turnName)
    {
        turnText.text = turnName;
    }
}

[System.Serializable]
public struct MaskToImage
{
    public MaskType maskType;
    public Sprite maskSprite;
}
