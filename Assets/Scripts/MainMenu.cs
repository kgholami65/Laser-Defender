using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Canvas optionsCanvas;
    [SerializeField] private Canvas mainMenu;

    public void QuitGame()
    {
        Application.Quit();
    }

    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Options()
    {
        mainMenu.gameObject.SetActive(false);
        optionsCanvas.gameObject.SetActive(true);
    }
}
