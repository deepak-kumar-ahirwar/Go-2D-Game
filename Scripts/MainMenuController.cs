using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // Start is called before the first frame update
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void playGame()
    {
        SceneManager.LoadScene("LevelOne");
    }
    public void exitGame()
    {
        Application.Quit();
    }
    public void About()
    {
        SceneManager.LoadScene("About");
    }
    public void back()
    {
        SceneManager.LoadScene("menu");
    }
}

