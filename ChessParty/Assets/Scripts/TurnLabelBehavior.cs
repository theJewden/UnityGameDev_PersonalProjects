using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TurnLabelBehavior : MonoBehaviour
{
    public bool isActive = true;
    public GameObject canvas;
    public TMP_Text turnLabel;
    public bool isWhite = true;
    public string label = "Test";
    private GameObject timerDad;



    void Start()
    {
        if (isWhite == true)
        {
            label = "White's Turn!";
        }
        else
        {
            label = "Black's Turn!";
        }
        turnLabel.text = label;
    }

    void Update()
    {
        if(timerDad != null)
        {
            if(timerDad.GetComponent<TurnTimer>().CheckIfTimerEnded())
            {
                isActive = false;
            }
        }

        if (!isActive)
        {
            Destroy(canvas);
            Destroy(turnLabel);
            Destroy(timerDad);
        }
    }

    public void SetTimerDad(GameObject dad)
    {
        timerDad = dad;
    }
}
