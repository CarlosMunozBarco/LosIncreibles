using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// Metodo que se ejecutara cuando presionemos el boton start
    /// </summary>
    public void OnStartButtonPressed()
    {
        // cargamos la escena del juego
        SceneManager.LoadScene("Game");
    }
    /// <summary>
    /// Metodo que se ejecutara cuando presionemos el boton Exit
    /// </summary>
    public void OnExitButtonPressed()
    {
        // condicion de ensablado
        // Todo lo que pongamos aqui dentro se ejecutara en el editor de unity 
        #if UNITY_EDITOR
        // quitamos el play del editor
        UnityEditor.EditorApplication.isPlaying = false;
        #endif

        // solo se ejecuta en la aplicacion como tal -> El ejecutable
        #if UNITY_STANDALONE
        // cerramos la aplicacion
        Application.Quit();
        #endif
    }
}
