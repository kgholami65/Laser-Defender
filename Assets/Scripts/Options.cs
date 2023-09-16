using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    [SerializeField] private Toggle mouseInput;
    [SerializeField] private Canvas mainMenuCanvas;
    private void Start()
    {
        if (PlayerPrefs.HasKey("MouseInput"))
            mouseInput.isOn = PlayerPrefs.GetInt("MouseInput") == 1;
        else
        {
            PlayerPrefs.SetInt("MouseInput", 1);
        }
    }

    public void ChangeMouseInputToggle()
    {
        bool isOn = mouseInput.isOn;
        if (isOn)
            PlayerPrefs.SetInt("MouseInput", 1);
        else 
            PlayerPrefs.SetInt("MouseInput", 0);
        PlayerPrefs.Save();
    }

    public void Back()
    {
        gameObject.SetActive(false);
        mainMenuCanvas.gameObject.SetActive(true);
    }

    
}
