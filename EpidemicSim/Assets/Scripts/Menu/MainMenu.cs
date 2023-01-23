using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject OptionsMenu;
    bool enabledOption = true;
    private void Start()
    {
        OptionsMenu.SetActive(true);
    }

    public void RunSim()
    {
        SceneManager.LoadScene("workscene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ToggleOptions()
    {
        if(enabledOption) 
        {
            enabledOption = false;
            OptionsMenu.SetActive(false);
        }
        else
        {
            enabledOption = true;
            OptionsMenu.SetActive(true);
        }
    }
}
