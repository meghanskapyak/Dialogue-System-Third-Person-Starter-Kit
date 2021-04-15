﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcIdleStateMachineBehaviour : StateMachineBehaviour
{
    private int randomAnimationValueAnimParam = Animator.StringToHash("RandomAnimationValue");
    private float timeBetweenIdleAnimationChangeRolls;
    private float elapsedTime = 0;
    private Npc npc;

    private int GetAnimationChangeRoll()
    {
        const int minRoll = 1, maxRoll = 11;
        return Random.Range(minRoll, maxRoll);
    }
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (npc == null)
        {
            npc = animator.GetComponentInChildren<Npc>();
            timeBetweenIdleAnimationChangeRolls = 
                Random.Range(npc.MinTimeBetweenIdleAnimationChangeRolls, npc.MaxTimeBetweenIdleAnimationChangeRolls);
        }

        elapsedTime = 0;
        animator.SetInteger(randomAnimationValueAnimParam, 0);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= timeBetweenIdleAnimationChangeRolls)
        {
            animator.SetInteger(randomAnimationValueAnimParam, GetAnimationChangeRoll());
            elapsedTime = 0;
        }
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
