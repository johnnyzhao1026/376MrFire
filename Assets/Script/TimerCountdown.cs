using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TimerCountdown : MonoBehaviour
{
    GameParameter parameter;
    private GameObject timmerCanvas;
    public TMP_Text text_Timer;
    int secondsLeft;
    private bool isCountdown;


    private void Awake()
    {
        parameter = GameObject.Find("GameParameterManager").GetComponent<GameParameter>();
        secondsLeft = parameter.Timmer_SecondsToCountDown;
        isCountdown = false;
        timmerCanvas = transform.root.gameObject;
    }
    // Update is called once per frame
    void Update()
    {
        //if(//trigger timer)
        if(!isCountdown && secondsLeft > 0)
        {
            StartCoroutine(TimerStart());
        }

        if (secondsLeft <= 0)
        {
            timmerCanvas.SetActive(false);
        }
    }

    IEnumerator TimerStart()
    {
        isCountdown = true;
        yield return new WaitForSeconds(1);
        secondsLeft--;

        // display form
        if(secondsLeft < 10)
        {
            text_Timer.text = "00:0" + secondsLeft;
        }
        else
        {
            text_Timer.text = "00:" + secondsLeft;
        }
        isCountdown = false;
    }



}
