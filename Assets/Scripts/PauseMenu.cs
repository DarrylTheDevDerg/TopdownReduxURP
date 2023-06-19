using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu; // referencia al panel de pausa

    private void Update()
    {
        // si se presiona la tecla Esc, se activa/desactiva el menú de pausa
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenu.activeSelf)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f; // se pausa el tiempo en el juego
        pauseMenu.SetActive(true); // se activa el panel de pausa
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f; // se reanuda el tiempo en el juego
        pauseMenu.SetActive(false); // se desactiva el panel de pausa
    }

    public void QuitGame()
    {
        Application.Quit(); // se sale del juego
    }

    public void LoadScene(string sceneName)
    {
        Time.timeScale = 1f; // se reanuda el tiempo en el juego
        SceneManager.LoadScene(sceneName); // carga la escena especificada por nombre
    }

    public void ReloadScene()
    {
    Time.timeScale = 1f; // se reanuda el tiempo en el juego
    Scene currentScene = SceneManager.GetActiveScene();
    SceneManager.LoadScene(currentScene.buildIndex);
    }
}