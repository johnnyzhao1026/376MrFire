using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    //public Transform target;
    public float damage = 40f;

    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AttackHitEvent()
    {
        if (player == null) return;
        else
        {  
            player.GetComponent<PlayerHealth>().TakeDamage(damage);
            Debug.Log("Hit you");
        }
       
    }
}
