using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlateController : MonoBehaviour
{
    public GameObject gameController;
    GameObject reference = null; //Reference is the piece we are moving

    //Board positions not world positions
    int matrixX;
    int matrixY;


    // false = movement, true = attacking another piece
    public bool attack = false;
    private int points = 0; 

    public void Start()
    {
        if(attack)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
        }
    }

    public void OnMouseUp()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");

        if (attack)
        {
            bool isBlack;
            GameObject chessPiece = gameController.GetComponent<GameController>().GetPosition(matrixX, matrixY); //Get the position of the piece we are attacking
            points = chessPiece.GetComponent<ChessPieceController>().points;
            isBlack = !chessPiece.GetComponent<ChessPieceController>().GetIsWhite();
            gameController.GetComponent<GameController>().ChangePlayerPoints(points, isBlack);
            Destroy(chessPiece); //Destroy the piece we are attacking
        }

        gameController.GetComponent<GameController>().SetPositionEmpty(reference.GetComponent<ChessPieceController>().GetXBoard(), reference.GetComponent<ChessPieceController>().GetYBoard()); //Gets the current position of the piece we want to move
        reference.GetComponent<ChessPieceController>().SetXBoard(matrixX); //Move that piece to the x position (Board Position, not World)
        reference.GetComponent<ChessPieceController>().SetYBoard(matrixY); //Move that piece to the y position (Board Position, not World)
        reference.GetComponent<ChessPieceController>().SetCords(); //Sets the Board postion to work with the world position

        if(reference.GetComponent<ChessPieceController>().pieceCode == 5) //If the piece that we are moving is a pawn, check if it is the first move
        {
            reference.GetComponent<ChessPieceController>().isPawnFirstMove = false;
        }


        gameController.GetComponent<GameController>().SetPosition(reference); //Keeps track of where our piece is in the code

        reference.GetComponent<ChessPieceController>().DestroyMovePlates();
    }

    public void SetCords(int x, int y) // Allows us to set the cordinates of the Moveplates
    {
        matrixX = x;
        matrixY = y;
    }

    public void SetReference(GameObject obj) //Allows us to set the reference piece we are trying to move 
    {
        reference = obj;
    }

    public GameObject GetReference() //Allows other parts of our code to reference what our reference is
    {
        return reference;
    }
}
