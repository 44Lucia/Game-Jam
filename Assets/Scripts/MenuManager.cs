using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class MenuManager : MonoBehaviour
{
    string sceneName;
    static MenuManager instance;

    static MenuManager m_instance;

    static public MenuManager Instance
    {
        get { return m_instance; }
        private set { }
    }

    // Start is called before the first frame update
    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        sceneName = scene.name;
    }

    public void ToGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void ToOptions() 
    {
        SceneManager.LoadScene("Options");
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ToCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void ToLose()
    {
        SceneManager.LoadScene("Lose");
    }

    public void ToExit()
    {
        Application.Quit();
    }
}

