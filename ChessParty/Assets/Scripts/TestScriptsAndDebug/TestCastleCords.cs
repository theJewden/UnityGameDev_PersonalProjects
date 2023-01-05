using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCastleCords : MonoBehaviour
{
    public bool isWhite = true;
    public string[] positions = new[] {"Left" , "Right"};
    public int positionsChoiceIndex = 0;
    private GameObject gameController;

    public void CheckCastleCords()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");
        string position = positions[positionsChoiceIndex];

        if(isWhite)
        {
            if(position == "Left")
            {
                Debug.Log("Cord 1,0 = " + gameController.GetComponent<GameController>().GetPositions(1, 0) + "; ");
                Debug.Log("Cord 2,0 = " + gameController.GetComponent<GameController>().GetPositions(2, 0) + "; ");
                Debug.Log("Cord 3,0 = " + gameController.GetComponent<GameController>().GetPositions(3, 0)+ "; ");
            } else
            {
                Debug.Log("Cord 6,0 = " + gameController.GetComponent<GameController>().GetPositions(5, 0) + "; ");
                Debug.Log("Cord 5,0 = " + gameController.GetComponent<GameController>().GetPositions(6, 0) + "; ");
            }


        } else
        {

            if(position == "Left")
            {
                Debug.Log("Cord 6,7 = " + gameController.GetComponent<GameController>().GetPositions(5, 7) + "; ");
                Debug.Log("Cord 5,7 = " + gameController.GetComponent<GameController>().GetPositions(6, 7) + "; ");
            } else
            {
                Debug.Log("Cord 1,7 = " + gameController.GetComponent<GameController>().GetPositions(1, 7) + "; ");
                Debug.Log("Cord 2,7 = " + gameController.GetComponent<GameController>().GetPositions(2, 7) + "; ");
                Debug.Log("Cord 3,7 = " + gameController.GetComponent<GameController>().GetPositions(3, 7) + "; ");
            }


        }

    }
}
