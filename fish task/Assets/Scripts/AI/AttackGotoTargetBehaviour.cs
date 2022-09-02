using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackGotoTargetBehaviour : StateMachineBehaviour
{
    private AIFish _ai;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _ai = animator.GetComponent<AIFish>();

        Target target = TargetManager.Instance.GetClosestTarget(_ai.transform.position);

        if(target != null)
        {
            _ai.CurrentTarget = target;
            _ai.MoveTo(target.transform.position);
        }
        else
        {
            _ai.TurnOffAttackMode();
        }
    }

    
}
