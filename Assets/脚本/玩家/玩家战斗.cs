using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 玩家战斗 : MonoBehaviour
{
    public Transform attackPoint;  
    public LayerMask enemyLayer;
    public Animator anim;
    public float cooldown = 2;
    private float timer;

    private void Update()
    {
        if(timer > 0)
            timer -= Time.deltaTime;
    }
    public void Attack()
    {
        if (timer <= 0)
            anim.SetBool("isAttacking", true);
        timer = cooldown;
    }
    public void DealDamage()
    {
        
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.position, 数值管理器.Instance.weaponRange, enemyLayer);
        if (enemies.Length > 0)
        {
            enemies[0].GetComponent<怪物生命>().ChangeHealth(-数值管理器.Instance.damage);
            enemies[0].GetComponent<怪物击退>().Knockback(transform, 数值管理器.Instance.knockbackForce, 
                数值管理器.Instance.knockbackTime, 数值管理器.Instance.stunTime);
        }
    }
    public void FinishAttacking()
    {
        anim.SetBool("isAttacking", false);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, 数值管理器.Instance.weaponRange);
    }
}
