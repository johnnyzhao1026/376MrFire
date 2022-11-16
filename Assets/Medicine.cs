using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medicine : MonoBehaviour
{

    public float healAmount = 5f;
    public GameObject player;

    private void Start()
    {
     }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(player.GetComponent<PlayerHealth>().health < 100 
                && player.GetComponent<PlayerHealth>().health > 0)
            {
                player.GetComponent<PlayerHealth>().health += healAmount;
            }

            Destroy(gameObject,0.5f);
        }
    }
}
