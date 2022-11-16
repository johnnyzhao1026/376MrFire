using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalPiece : MonoBehaviour
{
    public int crystalPieceGoal = 10;
    public int currentCrystal;

    private void Awake()
    {
        currentCrystal = 0;
    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            currentCrystal++;
            checkCrystalProgress();
        }
    }

    public void checkCrystalProgress()
    {
        if(currentCrystal >= crystalPieceGoal)
        {
            Debug.Log("You collect all crystal pieces,You Win");
            // todo
            // open a door return to your own bedroom
        }
    }
}
