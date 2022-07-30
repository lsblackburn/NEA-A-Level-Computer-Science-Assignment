using UnityEngine;
using UnityEngine.UI;
// Uses UnityUI features

public class Score_Script : MonoBehaviour
{
    public Text score;
    // Allows text score to be referenced in the script
    public Text Deathscore;
    // Allows text score to be referenced in the script
    private float time = 0;
    // Sets varialbe for time public float highScore;
    // Update is called once per frame
    void Update()
    {
           scoreBoard();
           // Allows the scoreBoard method to be called in the update method
           scoreBoardDeath();
           // Allows the scoreBoardDeath method to be called in the update method
            // Both allow for the score to continuously increase over time
    }
    public void scoreBoard()
    {
         score.text = Time.deltaTime.ToString();
         // Changes the score text by time it took for engine to load previous frame
         time += Time.deltaTime;
         // Adds a "deltaTime" (=1) every time a frame is processed
         score.text = Mathf.RoundToInt(time).ToString();
         // This rounds the type float variable to a type int variable 
         // And is converted into a string to be displayed
    }
    public void scoreBoardDeath()
    {
         Deathscore.text = Time.deltaTime.ToString();
         // Changes the score text by time it took for engine to load previous frame
         time += Time.deltaTime;
         // Adds a "deltaTime" (=1) every time a frame is processed
         Deathscore.text = Mathf.RoundToInt(time).ToString();
         // This rounds the type float variable to a type int variable 
         // And is converted into a string to be displayed
    }
}
