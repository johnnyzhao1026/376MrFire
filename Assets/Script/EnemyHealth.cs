using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public float health = 50f;
    Animator anim;
    bool isDead = false;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public bool IsDead()
    {
        return isDead;
    }

    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnTakenDamage");
        health -= damage;

        if (health <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {   if (isDead) return; // no need to trigger Die animation if already dead
        isDead = true;
        anim.SetTrigger("Die");
        //Destroy(gameObject);
    }
}
