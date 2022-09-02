using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class movebehaviour : StateMachineBehaviour
{
    public GameObject gameObject;
    public bool moveAway = false;
    public GameObject smallFish;
    public GameObject bigFish;
    public Transform target;
    float speed = 10.0f;
    const float dist = 1.1f;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        smallFish = GameObject.FindGameObjectWithTag("smallFish");
        bigFish = GameObject.FindGameObjectWithTag("bigFish");
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (((gameObject.transform.position - bigFish.transform.position).magnitude) < dist)
        {

            Debug.Log("big fish ");
            gameObject.transform.Translate(-0.0f, -1.0f, -(speed * Time.deltaTime));

        }


        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        //{
        //    
        //}

        // OnStateMove is called right after Animator.OnAnimatorMove()
        //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        //{
        //    // Implement code that processes and affects root motion
        //}

        // OnStateIK is called right after Animator.OnAnimatorIK()
        //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        //{
        //    // Implement code that sets up animation IK (inverse kinematics)
        //}
    }
}
