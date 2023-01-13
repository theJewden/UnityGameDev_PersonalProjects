using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnTimer : MonoBehaviour
{
    public GameObject theTurnLabel;
    private GameObject gameController;
    private float timerTime;
    private int wholeTimerTime;
    private int compareTimeTime;
    private bool isTimerOn = false;
    private bool hasTimerFinished = false;
    public bool isWhitesTurn;



    public void Update()
    {
        if(isTimerOn)
        {
            timerTime -= (1 * Time.deltaTime);
            wholeTimerTime = (int)timerTime;

            if(wholeTimerTime != compareTimeTime)
            {
                Debug.Log(wholeTimerTime + 1);
                compareTimeTime = wholeTimerTime;
            }


            if(timerTime <= 0)
            {
                Debug.Log("Timer Finished");
                isTimerOn = false;
                hasTimerFinished = true;
            }
        }

    }

    public void StartTimer(float newTimerTime)
    {
        timerTime = newTimerTime;
        hasTimerFinished = false;
        isTimerOn = true;
        CreateTurnLabel();
        Debug.Log(name);
    }

    public bool CheckIfTimerEnded()
    {
        return hasTimerFinished;
    }


    public GameObject CreateTurnLabel()
    {

        GameObject turnLabel = Instantiate(theTurnLabel);
        TurnLabelBehavior turnLabelBehavior = turnLabel.GetComponent<TurnLabelBehavior>();

        turnLabelBehavior.isWhite = isWhitesTurn;
        turnLabelBehavior.isActive = true;
        turnLabelBehavior.SetTimerDad(gameObject);

        return turnLabel;
    }
}
