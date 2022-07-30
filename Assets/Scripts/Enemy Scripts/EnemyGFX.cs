using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
// Link to Pathfinding asset

public class EnemyGFX : MonoBehaviour
{
    public AIPath aiPath;
    // References AIPath script into this script

    // Update is called once per frame
    void Update()
    {
        if(aiPath.desiredVelocity.x >= 0.01f)
        {
             transform.localRotation = Quaternion.Euler(0, 180, 0);
             // Flips sprite of enemy when target is behind it
        }

        else if (aiPath.desiredVelocity.x <= 0.01f)
         {
             transform.localRotation = Quaternion.Euler(0, 0, 0);
             // Flips sprite of enemy when target is in front of it
         }
    }
}
