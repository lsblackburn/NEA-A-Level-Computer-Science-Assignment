using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Script : MonoBehaviour
{
public Animator am;
// References the Animator as am
public Transform attackPoint;
// Creates a box for me to drag my Attack Point game object into it to 
// refernece my attackPoint as that game object
public LayerMask enemyLayer;
// Can set the Layer which will be referenced as the enemyLayer
public int attackDamage = 1;
// Allows my attackDamage to be modified in the editor
public float attackRange = 0.5f;
// Sets the attack range
public float attackRate = 2f;
// Allows my attack rate to be modified in the inspector
private float nextAttackTime = 0f;
// Variable for the period between where my player can use the attack command

void Start()
{
     am = GetComponent<Animator>(); 
     //Links Animator component to script
}
    // Update is called once per frame
    public void Update()
    {
    
     if(Time.time >= nextAttackTime)
     {
    if (Input.GetKeyDown(KeyCode.Mouse0))
    {
           Attack();
           // When the Input Mouse0 (Left Mouse Button) is clicked then the function "Attack" will happen
           // Attack(); links this input to the attack function

           nextAttackTime = Time.time + 1f / attackRate;
            // Creates a stall in the use of the attack method so that the attack is not spammable

           FindObjectOfType<AudioManager>().Play("Player Melee");
           // Plays the Player Melee audio
    }
     }
}
 void Attack()
    {
      am.SetTrigger("Attack");
      // When the input to the attack function is clicked, the attack animation will play

      Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
      // Detect Enemies in range of the attack
      
      foreach(Collider2D enemy in hitEnemies)
      {
           enemy.GetComponent<Enemy_Script>().TakeDamage(attackDamage);
      }
      //Registers that the enemies have been hit to damage them.
      // Links the Enemy Script to the player attack script
}
void OnDrawGizmosSelected()
{
      if(attackPoint == null)
      return;
      // If no enemy is in the attack point then nothing happens
      Gizmos.DrawWireSphere(attackPoint.position, attackRange);
       // Allows drawing on editor when object is selected which can allow me to modify the Attack range in the inspector
    }
}
