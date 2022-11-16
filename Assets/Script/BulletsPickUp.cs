using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsPickUp : MonoBehaviour
{
    public AmmoType ammoType;
    public int ammoAmount;

    private void Start()
    {
        ammoAmount = Random.Range(1, 3);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            FindObjectOfType<Ammo>().IncreaseCurrentAmmo(ammoType, ammoAmount);
        }
    }
}
