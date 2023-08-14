using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{

    Animator animatorController;

    const string NearPlayerParam = "NearPlayer";
    const string AttackParam = "Attack";
    const string HurtParam = "Hurt";
    const string DeathParam = "Death";

    [SerializeField]
    GameObject damageBox;

    void Awake() {
        animatorController = GetComponent<Animator>();
    }

    public void DamageOn()
    {
        if(damageBox != null)
            damageBox.SetActive(true);
    }
    public void DamageOff()
    {
        if(damageBox != null)
            damageBox.SetActive(false);
    }

    public void ChasingMode()
    {
        animatorController.SetBool(NearPlayerParam, true);
    }

    public void IdleMode()
    {
        animatorController.SetBool(NearPlayerParam, false);
    }

    public void AttackTrigger()
    {
        animatorController.SetTrigger(AttackParam);
    }
    public void HurtTrigger()
    {
        animatorController.SetTrigger(HurtParam);
    }
    public void DeathTrigger()
    {
        animatorController.SetTrigger(DeathParam);
    }

    public void ResetTriggers()
    {
        animatorController.ResetTrigger(AttackParam);
        animatorController.ResetTrigger(HurtParam);
        animatorController.ResetTrigger(DeathParam);
    }
}
