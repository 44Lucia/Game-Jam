using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLoos : MonoBehaviour
{
    string scene_name;
    // Start is called before the first frame update
    void Start()
    {
        Scene escena = SceneManager.GetActiveScene();
        scene_name = escena.name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void toMainMenu() 
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void toGame() 
    {
        SceneManager.LoadScene("Game");
    }

    public void toTuto() 
    {
        SceneManager.LoadScene("Tutorial");
    }
}
