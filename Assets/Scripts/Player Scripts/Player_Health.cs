using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Health : MonoBehaviour
{

	public static bool GameOver = false;
	// Sets GameOver menu as false so that it doesn't appear at the 
	// start of the game
	public int maxHealth = 0;
	// Variable to set the maximum health of my player
	public int currentHealth;
	// Variable to set the current health of my player
	public Health_Bar healthBar;
    // References the Health bar script into the player_health script
	public Animator am;
	// Reference to Animator component 
	public GameObject gameOverUI;
	// Sets GameOver object as gameOverUI variable

    // Start is called before the first frame update
    void Start()
    {
		am = GetComponent<Animator>(); 
        //Links Animator component to script
		currentHealth = maxHealth;
		// When game starts, the player starts with maximum health
		healthBar.SetMaxHealth(maxHealth);
		// Reference to my healthBar script 
		// Sets the health bar to maximum health
    }

    // Update is called once per frame
    void Update()
    {
		if(currentHealth == 0)
		{
			Death();
			// If my players health reaches 0
			// The death method will be called
		}
    }

	public void TakeDamage(int damage)
	{
		currentHealth -= damage;
        // Method used to calculate current health of my player after taking damage
		healthBar.SetHealth(currentHealth);
		// Reference to my healthBar script 
		// Alters the health bar to correspond with my players health after taking damage
		if(currentHealth > 0 )
		{
			FindObjectOfType<AudioManager>().Play("Player Hurt");
			// If my players health is above 0, then the hurt sound will play
		}
		else if(currentHealth == 0)
		{
			FindObjectOfType<AudioManager>().Play("Player Death");
			// If my players health is equal to 0, the death sound will play
		}
	}

    public void Death()
	{
		am.SetBool("IsDead", true);
		// Plays Death animation
		gameOverUI.SetActive(true);
		GameOver = true;
		// Makes the Game Over title screen appear
		GetComponent<Player_Controller_>().enabled = false;
		// Disables the Player_Controller_ script upon death
		GetComponent<Attack_Script>().enabled = false;
		// Disables the Attack_Script upon death
		Invoke("Stop", 1);
		// Used to stop the score from increasing which will give the player
		// Their final score at the end of the game
		// Invoke used to delay it by 1 second
     }

	 void Stop()
	 {
		 Time.timeScale = 0f;
		 // All functions and movements in the game will stop
	 }
}
