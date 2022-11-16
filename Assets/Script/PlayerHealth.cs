using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    //GameParameter parameter;
    public float health;
    
    private void Awake()
    {
        //parameter = GameObject.Find("GameParameterManager").GetComponent<GameParameter>();

        health = 80f;
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Debug.Log("Player Die");
        }
    }

    public void Heal(float healAmount)
    {
        health += healAmount;
    }
}
