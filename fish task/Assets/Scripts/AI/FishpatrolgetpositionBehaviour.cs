using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FishpatrolgetpositionBehaviour : StateMachineBehaviour
{
    private AIFish _ai;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _ai = animator.GetComponent<AIFish>();
        _ai.MoveTo(GenerateRandomPosition(_ai.transform.position, 15));

        animator.SetBool("HasPatrolPosition", true);
    }

    private static Vector3 GenerateRandomPosition(Vector3 origin, float range)
    {
        Vector3 randomDirection = Random.insideUnitSphere * range;
        randomDirection += origin;

        NavMeshHit navHit;
        NavMesh.SamplePosition(randomDirection, out navHit, range, NavMesh.AllAreas);
        return navHit.position;
    }
}
