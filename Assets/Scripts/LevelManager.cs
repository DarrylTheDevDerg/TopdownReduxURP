using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private int currentLevel = 1;

    private void Start()
    {
        // Obtener el valor del PlayerPrefs "CurrentLevel"
        if (PlayerPrefs.HasKey("CurrentLevel"))
        {
            currentLevel = PlayerPrefs.GetInt("CurrentLevel");
        }

        // Realizar acciones basadas en el número del nivel
        switch (currentLevel)
        {
            case 1:
                LoadLevel1();
                break;
            case 2:
                LoadLevel2();
                break;
            case 3:
                LoadLevel3();
                break;
            case 4:
                LoadLevel4();
                break;
            case 5:
                LoadLevel5();
                break;
            // Agrega más casos según sea necesario para cada nivel
            default:
                LoadLevel0();
                break;
        }
    }

    private void LoadLevel1()
    {
        SceneManager.LoadScene("LVL1");
    }

    private void LoadLevel2()
    {
        SceneManager.LoadScene("LVL2");
        // Aquí puedes colocar el código para cargar y configurar el nivel 2
    }

    private void LoadLevel3()
    {
        SceneManager.LoadScene("LVL3");
        // Aquí puedes colocar el código para cargar y configurar el nivel 3
    }
    
    private void LoadLevel4()
    {
        SceneManager.LoadScene("LVL4");
    }

    private void LoadLevel5()
    {
        SceneManager.LoadScene("LVL5");
    }

    private void LoadLevel0()
    {
        SceneManager.LoadScene("ErrorRoom");
    }
}
