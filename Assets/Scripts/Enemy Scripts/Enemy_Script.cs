using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Script : MonoBehaviour
{
public GameObject spawn;
// Holds the variable for the spawner where an enemy will respawn from
public GameObject enemy;
// Holds the variable for the enemy which will transform back to
// the enemy spawner upon death
public int maxHealth = 1;
// Allows enemy health to be set & modified in my inspector 
public Animator am;
// References the Animator as am
public int currentHealth;
// Declares what the current health of the enemy is

    // Start is called before the first frame update
    void Start()
    {
	  	 FindObjectOfType<AudioManager>().Play("Demon Wings");
         // Plays Audio of my Demon Enemy flapping its wings
        
         currentHealth = maxHealth;
         // Enemy spawns in with maximum health
    }

public void TakeDamage(int damage)
{
    currentHealth -= damage;
    // When the enemy is attacked, the current health of the enemy will
    // Be substracted by the damage
    if(currentHealth <= 0)
    {
        Death();
        // When the health of the enemy reaches zero the death method will be called
    }
}

void Death()
{
    am.SetBool("IsDead", true);
    // Death Animation
    GetComponent<Collider2D>().enabled = false;
    // Despawns enemy
    FindObjectOfType<AudioManager>().Play("Demon Death");
    // Plays Audio for my Demon enemy dying
    Respawn();
}

void Respawn()
{
    enemy.transform.position = spawn.transform.position;
    // Transforms the enemy back to the location where the enemy spawner is
    am.SetBool("Respawn", true);
    // Reverts the animation from the death aniamtion to the idle animation
    // Death Animation
    currentHealth = maxHealth;
    // Reverts the health of my enemy back to its maximum health
    GetComponent<Collider2D>().enabled = true;
    // Re-enables my Colliders so that it can be hit
}
}
