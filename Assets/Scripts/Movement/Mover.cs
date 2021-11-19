using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/*
Allows a point and click for movement mechanic
@author Magen Hocker 
*/
namespace RPG.Movement {
public class Mover : MonoBehaviour
{
    Ray lastRay; // The most recent Ray where clicked

    void LateUpdate()
    {
        UpdateAnimator();
    }

    public void MoveTo(Vector3 destination)
    {
        GetComponent<NavMeshAgent>().destination = destination;
    }

    // Change the speed so that the controller knows whether to plat the idle, walk, or run animation
    private void UpdateAnimator() {
        // Get Global Velocity from NavMesh Agent
        Vector3 velocity = GetComponent<NavMeshAgent>().velocity;

        // Transforms a Global into Local 
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);
        
        // The spatial speed relaitonal to forward  
        float speed = localVelocity.z;

        GetComponent<Animator>().SetFloat("forwardSpeed", speed);
    }
}

}
