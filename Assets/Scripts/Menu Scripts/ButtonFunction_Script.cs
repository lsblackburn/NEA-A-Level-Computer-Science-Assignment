using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// Uses Unity UI functions
using UnityEngine.SceneManagement;
// Links script to scene manager


public class ButtonFunction_Script : MonoBehaviour
{
    public static bool GamePaused = false;
    // Sets the boolean to tell if the game is paused or not
    // Sets default GamePaused = false so that the game isn't paused
    // From the beginning of the game
    public GameObject pauseMenuUI;
    // Makes a box in the script available for the pauseMenu to be
    // Dragged into, so that when the input is pressed to pause
    // That GameObject is used

#region PauseMenu
    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Escape))
      // Sets the input to the Esc key to pause the game
      {
          if(GamePaused)
          {
              Resume();
              // Binds button to resume game
          }
          else
          {
              Pause();
              // Binds button to pause game
          }
      }
    }
     public void Resume()
     {
        pauseMenuUI.SetActive(false);
         Time.timeScale = 1f;
         GamePaused = false;
         // When the resume button is pressed the game time will continue
         // And the gamebecomes playable again
		FindObjectOfType<AudioManager>().Play("Button");
        // Plays the button sound effect upon button being pressed
        AudioListener.volume = 1;
        // Volume is turned on
     } 
     void Pause()
     {
         pauseMenuUI.SetActive(true);
         Time.timeScale = 0f;
         GamePaused = true;
         // When the Esc button is pressed and the game is paused 
         // Then the game will freeze and movement will stop
         // Which then brings up the UI text
         FindObjectOfType<AudioManager>().Play("Button");
         // Plays the button sound effect upon button being pressed
         AudioListener.volume = 0;
         // Volume is turned off
     }
     public void Quit()
     // Button for opening game settings menu
     {
          Application.Quit();
          // Quits the game
          Debug.Log("Quit");
          FindObjectOfType<AudioManager>().Play("Button");
          // Plays the button sound effect upon button being pressed
     }
     public void UnmuteAudio()
     {
         AudioListener.volume = 1;
         // Unmutes audio
     }
#endregion

#region GameOver
     public void Restart()
    {
          SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
          // Returns the player back to the main menu
    }
#endregion

}
