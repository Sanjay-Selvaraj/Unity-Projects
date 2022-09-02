using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEatFoodBehaviour : StateMachineBehaviour
{
    private AIFish _ai;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateinfo, int layerindex)
    {
        _ai = animator.GetComponent<AIFish>();
        if(_ai.CurrentTarget == null)
        {
            return;
        }

        _ai.StopMove();
        _ai.transform.LookAt(_ai.CurrentTarget.transform);
        _ai.FireProjectile();

        animator.SetBool("IsCoolingDown", true);
    }

   
}
