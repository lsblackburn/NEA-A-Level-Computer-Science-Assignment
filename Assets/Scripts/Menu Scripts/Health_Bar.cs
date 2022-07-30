using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// Allows for the creation of a variable which stores the slider component

public class Health_Bar : MonoBehaviour
{
    public Slider healthSlider;
	// Variable which holds the slider component
	// Creates a box for the Health Bar object to be placed in
	public Image fill;
	// Variable which holds the image which acts as the slider
	public void SetMaxHealth(int health)
	// Set as public to be called from the player health script
	{
		healthSlider.maxValue = health;
		healthSlider.value = health;
		// Ensures slider starts at maximum health
	}
    public void SetHealth(int health)
	{
		healthSlider.value = health;
		// Sets new value of health of adjusts the slider
		// To the correct value which corresponds to the current player health
	}
}
