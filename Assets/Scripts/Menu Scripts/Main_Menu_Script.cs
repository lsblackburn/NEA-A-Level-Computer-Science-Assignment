using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
// Links script to scene manager

public class Main_Menu_Script : MonoBehaviour
{
    public void PlayGame()
    {
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
         // When the method is used it will load the scene which buildIdex = 1,
         // which will be my scene including my actual game.
         Time.timeScale = 1f;
         // Resumes time if the game is restarted from player death
    }
    public void ExitGame()
    {
        Debug.Log ("QUIT!");
        Application.Quit();
        // Quits the game
    }
    public void ControlsMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        // Opens the Controls Menu to present the controls for the game
    }
    public void BackMenuFunction()
   {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
       // Returns the player back to the main menu
   }
}
