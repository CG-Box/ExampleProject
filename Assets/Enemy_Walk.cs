using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Walk : StateMachineBehaviour
{

    public float walkSpeed = 2f;

    public float attackRange = 3f;
    Transform player;
    Rigidbody2D rb;

    EnemyFlip enemyFlip;
    EnemyControl enemyControl;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        enemyFlip = animator.GetComponent<EnemyFlip>();
        enemyControl = animator.GetComponent<EnemyControl>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemyFlip.LookAtPlayer();

        Vector2 target = new Vector2(player.position.x, rb.position.y);
        Vector2 newPosition = Vector2.MoveTowards(rb.position, target, walkSpeed * Time.fixedDeltaTime);
        rb.MovePosition(newPosition);

        if(Vector2.Distance(player.position, rb.position) <= attackRange)
        {
            enemyControl.AttackTrigger();
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemyControl.ResetTriggers();
        enemyControl.DamageOff();
    }


}
