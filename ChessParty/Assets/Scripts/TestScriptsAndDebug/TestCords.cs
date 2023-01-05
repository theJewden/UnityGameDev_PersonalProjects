using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCords : MonoBehaviour
{
    private GameObject gameController;


    public void CheckCords()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");
        if (gameController.GetComponent<GameController>().GetPositions(0, 0) != null) Debug.Log("Cord 0,0 = " + gameController.GetComponent<GameController>().GetPositions(0,0) + "; ");
        if (gameController.GetComponent<GameController>().GetPositions(0, 1) != null) Debug.Log("Cord 0,1 = " + gameController.GetComponent<GameController>().GetPositions(0, 1) + "; ");
        if (gameController.GetComponent<GameController>().GetPositions(0, 2) != null) Debug.Log("Cord 0,2 = " + gameController.GetComponent<GameController>().GetPositions(0, 2) + "; ");
        if (gameController.GetComponent<GameController>().GetPositions(0, 3) != null) Debug.Log("Cord 0,3 = " + gameController.GetComponent<GameController>().GetPositions(0, 3) + "; ");
        if (gameController.GetComponent<GameController>().GetPositions(0, 4) != null) Debug.Log("Cord 0,4 = " + gameController.GetComponent<GameController>().GetPositions(0, 4) + "; ");
        if (gameController.GetComponent<GameController>().GetPositions(0, 5) != null) Debug.Log("Cord 0,5 = " + gameController.GetComponent<GameController>().GetPositions(0, 5) + "; ");
        if (gameController.GetComponent<GameController>().GetPositions(0, 6) != null) Debug.Log("Cord 0,6 = " + gameController.GetComponent<GameController>().GetPositions(0, 6) + "; ");
        if (gameController.GetComponent<GameController>().GetPositions(0, 7) != null) Debug.Log("Cord 0,7 = " + gameController.GetComponent<GameController>().GetPositions(0, 7) + "; ");
        if (gameController.GetComponent<GameController>().GetPositions(0, 8) != null) Debug.Log("Cord 0,8 = " + gameController.GetComponent<GameController>().GetPositions(0, 8) + "; ");

        if (gameController.GetComponent<GameController>().GetPositions(1, 0) != null) Debug.Log("Cord 1,0 = " + gameController.GetComponent<GameController>().GetPositions(1, 0) + "; ");
        if (gameController.GetComponent<GameController>().GetPositions(1, 1) != null) Debug.Log("Cord 1,1 = " + gameController.GetComponent<GameController>().GetPositions(1, 1) + "; ");
        if (gameController.GetComponent<GameController>().GetPositions(1, 2) != null) Debug.Log("Cord 1,2 = " + gameController.GetComponent<GameController>().GetPositions(1, 2) + "; ");
        if (gameController.GetComponent<GameController>().GetPositions(1, 3) != null) Debug.Log("Cord 1,3 = " + gameController.GetComponent<GameController>().GetPositions(1, 3) + "; ");
        if (gameController.GetComponent<GameController>().GetPositions(1, 4) != null) Debug.Log("Cord 1,4 = " + gameController.GetComponent<GameController>().GetPositions(1, 4) + "; ");
        if (gameController.GetComponent<GameController>().GetPositions(1, 5) != null) Debug.Log("Cord 1,5 = " + gameController.GetComponent<GameController>().GetPositions(1, 5) + "; ");
        if (gameController.GetComponent<GameController>().GetPositions(1, 6) != null) Debug.Log("Cord 1,6 = " + gameController.GetComponent<GameController>().GetPositions(1, 6) + "; ");
        if (gameController.GetComponent<GameController>().GetPositions(1, 7) != null) Debug.Log("Cord 1,7 = " + gameController.GetComponent<GameController>().GetPositions(1, 7) + "; ");
        if (gameController.GetComponent<GameController>().GetPositions(1, 8) != null) Debug.Log("Cord 1,8 = " + gameController.GetComponent<GameController>().GetPositions(1, 8) + "; ");

        if (gameController.GetComponent<GameController>().GetPositions(2, 0) != null) Debug.Log("Cord 2,0 = " + gameController.GetComponent<GameController>().GetPositions(2, 0) + "; ");
        if (gameController.GetComponent<GameController>().GetPositions(2, 1) != null) Debug.Log("Cord 2,1 = " + gameController.GetComponent<GameController>().GetPositions(2, 1) + "; ");
        if (gameController.GetComponent<GameController>().GetPositions(2, 2) != null) Debug.Log("Cord 2,2 = " + gameController.GetComponent<GameController>().GetPositions(2, 2) + "; ");
        if (gameController.GetComponent<GameController>().GetPositions(2, 3) != null) Debug.Log("Cord 2,3 = " + gameController.GetComponent<GameController>().GetPositions(2, 3) + "; ");
        if (gameController.GetComponent<GameController>().GetPositions(2, 4) != null) Debug.Log("Cord 2,4 = " + gameController.GetComponent<GameController>().GetPositions(2, 4) + "; ");
        if (gameController.GetComponent<GameController>().GetPositions(2, 5) != null) Debug.Log("Cord 2,5 = " + gameController.GetComponent<GameController>().GetPositions(2, 5) + "; ");
        if (gameController.GetComponent<GameController>().GetPositions(2, 6) != null) Debug.Log("Cord 2,6 = " + gameController.GetComponent<GameController>().GetPositions(2, 6) + "; ");
        if (gameController.GetComponent<GameController>().GetPositions(2, 7) != null) Debug.Log("Cord 2,7 = " + gameController.GetComponent<GameController>().GetPositions(2, 7) + "; ");
        if (gameController.GetComponent<GameController>().GetPositions(2, 8) != null) Debug.Log("Cord 2,8 = " + gameController.GetComponent<GameController>().GetPositions(2, 8) + "; ");

        if (gameController.GetComponent<GameController>().GetPositions(3, 0) != null) Debug.Log("Cord 3,0 = " + gameController.GetComponent<GameController>().GetPositions(3, 0) + "; ");
        if (gameController.GetComponent<GameController>().GetPositions(3, 1) != null) Debug.Log("Cord 3,1 = " + gameController.GetComponent<GameController>().GetPositions(3, 1) + "; ");
        if (gameController.GetComponent<GameController>().GetPositions(3, 2) != null) Debug.Log("Cord 3,2 = " + gameController.GetComponent<GameController>().GetPositions(3, 2) + "; ");
        if (gameController.GetComponent<GameController>().GetPositions(3, 3) != null) Debug.Log("Cord 3,3 = " + gameController.GetComponent<GameController>().GetPositions(3, 3) + "; ");
        if (gameController.GetComponent<GameController>().GetPositions(3, 4) != null) Debug.Log("Cord 3,4 = " + gameController.GetComponent<GameController>().GetPositions(3, 4) + "; ");
        if (gameController.GetComponent<GameController>().GetPositions(3, 5) != null) Debug.Log("Cord 3,5 = " + gameController.GetComponent<GameController>().GetPositions(3, 5) + "; ");
        if (gameController.GetComponent<GameController>().GetPositions(3, 6) != null) Debug.Log("Cord 3,6 = " + gameController.GetComponent<GameController>().GetPositions(3, 6) + "; ");
        if (gameController.GetComponent<GameController>().GetPositions(3, 7) != null) Debug.Log("Cord 3,7 = " + gameController.GetComponent<GameController>().GetPositions(3, 7) + "; ");
        if (gameController.GetComponent<GameController>().GetPositions(3, 8) != null) Debug.Log("Cord 3,8 = " + gameController.GetComponent<GameController>().GetPositions(3, 8) + "; ");

        if (gameController.GetComponent<GameController>().GetPositions(4, 0) != null) Debug.Log("Cord 4,0 = " + gameController.GetComponent<GameController>().GetPositions(4, 0) + "; ");
        if (gameController.GetComponent<GameController>().GetPositions(4, 1) != null) Debug.Log("Cord 4,1 = " + gameController.GetComponent<GameController>().GetPositions(4, 1) + "; ");
        if (gameController.GetComponent<GameController>().GetPositions(4, 2) != null) Debug.Log("Cord 4,2 = " + gameController.GetComponent<GameController>().GetPositions(4, 2) + "; ");
        if (gameController.GetComponent<GameController>().GetPositions(4, 3) != null) Debug.Log("Cord 4,3 = " + gameController.GetComponent<GameController>().GetPositions(4, 3) + "; ");
        if (gameController.GetComponent<GameController>().GetPositions(4, 4) != null) Debug.Log("Cord 4,4 = " + gameController.GetComponent<GameController>().GetPositions(4, 4) + "; ");
        if (gameController.GetComponent<GameController>().GetPositions(4, 5) != null) Debug.Log("Cord 4,5 = " + gameController.GetComponent<GameController>().GetPositions(4, 5) + "; ");
        if (gameController.GetComponent<GameController>().GetPositions(4, 6) != null) Debug.Log("Cord 4,6 = " + gameController.GetComponent<GameController>().GetPositions(4, 6) + "; ");
        if (gameController.GetComponent<GameController>().GetPositions(4, 7) != null) Debug.Log("Cord 4,7 = " + gameController.GetComponent<GameController>().GetPositions(4, 7) + "; ");
        if (gameController.GetComponent<GameController>().GetPositions(4, 8) != null) Debug.Log("Cord 4,8 = " + gameController.GetComponent<GameController>().GetPositions(4, 8) + "; ");

        if (gameController.GetComponent<GameController>().GetPositions(5, 0) != null) Debug.Log("Cord 5,0 = " + gameController.GetComponent<GameController>().GetPositions(5, 0) + "; ");
        if (gameController.GetComponent<GameController>().GetPositions(5, 1) != null) Debug.Log("Cord 5,1 = " + gameController.GetComponent<GameController>().GetPositions(5, 1) + "; ");
        if (gameController.GetComponent<GameController>().GetPositions(5, 2) != null) Debug.Log("Cord 5,2 = " + gameController.GetComponent<GameController>().GetPositions(5, 2) + "; ");
        if (gameController.GetComponent<GameController>().GetPositions(5, 3) != null) Debug.Log("Cord 5,3 = " + gameController.GetComponent<GameController>().GetPositions(5, 3) + "; ");
        if (gameController.GetComponent<GameController>().GetPositions(5, 4) != null) Debug.Log("Cord 5,4 = " + gameController.GetComponent<GameController>().GetPositions(5, 4) + "; ");
        if (gameController.GetComponent<GameController>().GetPositions(5, 5) != null) Debug.Log("Cord 5,5 = " + gameController.GetComponent<GameController>().GetPositions(5, 5) + "; ");
        if (gameController.GetComponent<GameController>().GetPositions(5, 6) != null) Debug.Log("Cord 5,6 = " + gameController.GetComponent<GameController>().GetPositions(5, 6) + "; ");
        if (gameController.GetComponent<GameController>().GetPositions(5, 7) != null) Debug.Log("Cord 5,7 = " + gameController.GetComponent<GameController>().GetPositions(5, 7) + "; ");
        if (gameController.GetComponent<GameController>().GetPositions(5, 8) != null) Debug.Log("Cord 5,8 = " + gameController.GetComponent<GameController>().GetPositions(5, 8) + "; ");

        if (gameController.GetComponent<GameController>().GetPositions(6, 0) != null) Debug.Log("Cord 6,0 = " + gameController.GetComponent<GameController>().GetPositions(6, 0) + "; ");
        if (gameController.GetComponent<GameController>().GetPositions(6, 1) != null) Debug.Log("Cord 6,1 = " + gameController.GetComponent<GameController>().GetPositions(6, 1) + "; ");
        if (gameController.GetComponent<GameController>().GetPositions(6, 2) != null) Debug.Log("Cord 6,2 = " + gameController.GetComponent<GameController>().GetPositions(6, 2) + "; ");
        if (gameController.GetComponent<GameController>().GetPositions(6, 3) != null) Debug.Log("Cord 6,3 = " + gameController.GetComponent<GameController>().GetPositions(6, 3) + "; ");
        if (gameController.GetComponent<GameController>().GetPositions(6, 4) != null) Debug.Log("Cord 6,4 = " + gameController.GetComponent<GameController>().GetPositions(6, 4) + "; ");
        if (gameController.GetComponent<GameController>().GetPositions(6, 5) != null) Debug.Log("Cord 6,5 = " + gameController.GetComponent<GameController>().GetPositions(6, 5) + "; ");
        if (gameController.GetComponent<GameController>().GetPositions(6, 6) != null) Debug.Log("Cord 6,6 = " + gameController.GetComponent<GameController>().GetPositions(6, 6) + "; ");
        if (gameController.GetComponent<GameController>().GetPositions(6, 7) != null) Debug.Log("Cord 6,7 = " + gameController.GetComponent<GameController>().GetPositions(6, 7) + "; ");
        if (gameController.GetComponent<GameController>().GetPositions(6, 8) != null) Debug.Log("Cord 6,8 = " + gameController.GetComponent<GameController>().GetPositions(6, 8) + "; ");

        if (gameController.GetComponent<GameController>().GetPositions(7, 0) != null) Debug.Log("Cord 7,0 = " + gameController.GetComponent<GameController>().GetPositions(7, 0) + "; ");
        if (gameController.GetComponent<GameController>().GetPositions(7, 1) != null) Debug.Log("Cord 7,1 = " + gameController.GetComponent<GameController>().GetPositions(7, 1) + "; ");
        if (gameController.GetComponent<GameController>().GetPositions(7, 2) != null) Debug.Log("Cord 7,2 = " + gameController.GetComponent<GameController>().GetPositions(7, 2) + "; ");
        if (gameController.GetComponent<GameController>().GetPositions(7, 3) != null) Debug.Log("Cord 7,3 = " + gameController.GetComponent<GameController>().GetPositions(7, 3) + "; ");
        if (gameController.GetComponent<GameController>().GetPositions(7, 4) != null) Debug.Log("Cord 7,4 = " + gameController.GetComponent<GameController>().GetPositions(7, 4) + "; ");
        if (gameController.GetComponent<GameController>().GetPositions(7, 5) != null) Debug.Log("Cord 7,5 = " + gameController.GetComponent<GameController>().GetPositions(7, 5) + "; ");
        if (gameController.GetComponent<GameController>().GetPositions(7, 6) != null) Debug.Log("Cord 7,6 = " + gameController.GetComponent<GameController>().GetPositions(7, 6) + "; ");
        if (gameController.GetComponent<GameController>().GetPositions(7, 7) != null) Debug.Log("Cord 7,7 = " + gameController.GetComponent<GameController>().GetPositions(7, 7) + "; ");
        if (gameController.GetComponent<GameController>().GetPositions(7, 8) != null) Debug.Log("Cord 7,8 = " + gameController.GetComponent<GameController>().GetPositions(7, 8) + "; ");

        if (gameController.GetComponent<GameController>().GetPositions(8, 0) != null) Debug.Log("Cord 8,0 = " + gameController.GetComponent<GameController>().GetPositions(8, 0) + "; ");
        if (gameController.GetComponent<GameController>().GetPositions(8, 1) != null) Debug.Log("Cord 8,1 = " + gameController.GetComponent<GameController>().GetPositions(8, 1) + "; ");
        if (gameController.GetComponent<GameController>().GetPositions(8, 2) != null) Debug.Log("Cord 8,2 = " + gameController.GetComponent<GameController>().GetPositions(8, 2) + "; ");
        if (gameController.GetComponent<GameController>().GetPositions(8, 3) != null) Debug.Log("Cord 8,3 = " + gameController.GetComponent<GameController>().GetPositions(8, 3) + "; ");
        if (gameController.GetComponent<GameController>().GetPositions(8, 4) != null) Debug.Log("Cord 8,4 = " + gameController.GetComponent<GameController>().GetPositions(8, 4) + "; ");
        if (gameController.GetComponent<GameController>().GetPositions(8, 5) != null) Debug.Log("Cord 8,5 = " + gameController.GetComponent<GameController>().GetPositions(8, 5) + "; ");
        if (gameController.GetComponent<GameController>().GetPositions(8, 6) != null) Debug.Log("Cord 8,6 = " + gameController.GetComponent<GameController>().GetPositions(8, 6) + "; ");
        if (gameController.GetComponent<GameController>().GetPositions(8, 7) != null) Debug.Log("Cord 8,7 = " + gameController.GetComponent<GameController>().GetPositions(8, 7) + "; ");
        if (gameController.GetComponent<GameController>().GetPositions(8, 8) != null) Debug.Log("Cord 8,8 = " + gameController.GetComponent<GameController>().GetPositions(8, 8) + "; ");
    }

}
