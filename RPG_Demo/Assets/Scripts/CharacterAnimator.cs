using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterAnimator : MonoBehaviour
{
    public AnimationClip replaceableAttackAnim;
    public AnimationClip[] defaultAttackAnimSet;
    protected AnimationClip[] currentAttackAnimSet;

    const float locmationAnimationSmoothTime = .1f;

    NavMeshAgent agent;

    protected Animator animator;

    protected CharacterCombat combat;

    public AnimatorOverrideController overrideController;

    // Start is called before the first frame update
    protected virtual void Start()
    {

        agent = GetComponent<NavMeshAgent>();

        animator = GetComponentInChildren<Animator>();

        combat = GetComponentInChildren<CharacterCombat>();

        if(overrideController == null)
        {
            overrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
        }
        
        animator.runtimeAnimatorController = overrideController;
        //overrideController["Armature|Attack_Sword_02"] = 
        currentAttackAnimSet = defaultAttackAnimSet;
        combat.OnAttack += OnAttack;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        float speedPrecent = agent.velocity.magnitude / agent.speed;

        animator.SetFloat("speedPrecent",speedPrecent, locmationAnimationSmoothTime, Time.deltaTime);

        animator.SetBool("inCombat", combat.InCombat);
    }

    protected virtual void OnAttack()
    {
        animator.SetTrigger("attack");
        int attackIndex = Random.Range(0,currentAttackAnimSet.Length);
        overrideController[replaceableAttackAnim.name] = currentAttackAnimSet[attackIndex];
    }
}
