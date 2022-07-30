using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonAttack : MonoBehaviour
{

#region Variables
public Animator am;
// References the Animator as am
public Transform attackPoint;
// Creates a box for me to drag my Attack Point game object into it to 
// refernece my attackPoint as that game object
public LayerMask playerLayer;
// Can set the Layer which will be referenced as the playerLayer
public int attackDamage = 1;
// Allows my attackDamage to be modified in the editor
public float attackRange = 0.5f;
// Sets the attack range
public float attackRate = 2f;
// Allows attackRate to be modified in the editor
private float nextAttackTime = 0f;
// Sets variable for attack cooldown
#endregion

void Start()
{
     am = GetComponent<Animator>(); 
     //Links Animator component to script
}
    // Update is called once per frame
    public void Update()
    {
         if(Time.time >= nextAttackTime)
         // Cooldown for next attack
        {
            Attack();
         // Enemy constantly using the attack method
         // When enemy gets close to player for the method to have an effect
         // The attack animation plays

         nextAttackTime = Time.time + 1f / attackRate;
        }
  }
 void Attack()
    {
    
      Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);
      // Detects when the player is in range of the attack

      foreach(Collider2D enemy in hitPlayer)
      {
      am.SetBool("Attack", true);
      // When the boolean is set to true then the attack animation plays
           enemy.GetComponent<Player_Health>().TakeDamage(attackDamage);
      }
      //Registers that the player has been hit to damage them.
    }
void OnDrawGizmosSelected()
{
    if(attackPoint == null)
     return;
// If the player is in the attack point then nothing happens
     Gizmos.DrawWireSphere(attackPoint.position, attackRange);
// Allows drawing on editor when object is selected which can allow me to modify the Attack range in the inspector
}
}
