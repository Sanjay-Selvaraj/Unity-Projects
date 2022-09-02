using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishpatrolGotopositionBehaviour : StateMachineBehaviour
{
    private AIFish _ai;
    private Animator _animator;
   
    public bool moveAway = false;
    public GameObject smallFish;
    public GameObject bigFish;
    public Transform target;
    float speed = 10.0f;
    const float dist = 10.0f;
    const float distf = 27.0f;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _animator = animator;
        _ai = animator.GetComponent<AIFish>();

        _ai.OnArrivedAtDestination.AddListener(OnArrivedDestination);

        smallFish = GameObject.FindGameObjectWithTag("smallFish");
        bigFish = GameObject.FindGameObjectWithTag("bigFish");
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        if ((((_ai.transform.position - bigFish.transform.position).magnitude) < dist)|| (((_ai.transform.position - bigFish.transform.position).magnitude) > distf))
        { 

            Debug.Log("big fish ");
            _ai.transform.Translate(-0.0f, -0.0f, -(speed * Time.deltaTime));

        }
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _ai.OnArrivedAtDestination.RemoveListener(OnArrivedDestination);
    }

    private void OnArrivedDestination()
    {
        _animator.SetBool("HasPatrolPosition", false);
    }
}
