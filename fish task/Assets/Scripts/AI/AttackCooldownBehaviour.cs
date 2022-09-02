using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCooldownBehaviour : StateMachineBehaviour
{
    private AIFish _ai;
    private Animator _animator;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _ai = animator.GetComponent<AIFish>();
        _animator = animator;

        _ai.StartCoroutine(DoCooldown());

    }

    private IEnumerator DoCooldown()
    {
        yield return new WaitForSeconds(_ai.Cooldown);
        _animator.SetBool("IsCoolingDown", false);
    }
}
