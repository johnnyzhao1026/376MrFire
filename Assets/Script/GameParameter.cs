using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameParameter : MonoBehaviour
{

    [SerializeField] 
    private int timmer_SecondsToCountDown;
  /*  [SerializeField]
    private int playerHealth;*/

    public int Timmer_SecondsToCountDown { get => timmer_SecondsToCountDown; set => timmer_SecondsToCountDown = value; }
    //public int PlayerHealth { get => playerHealth; set => playerHealth = value; }

    



    private void Awake()
    {
       // Timmer_SecondsToCountDown = ;
    }


    

}
