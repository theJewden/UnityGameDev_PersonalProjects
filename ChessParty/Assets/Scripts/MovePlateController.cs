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
    public bool isHidden = false;
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
            ///When a piece attacks another piece

            bool isBlack;
            GameObject chessPiece = gameController.GetComponent<GameController>().GetPosition(matrixX, matrixY); //Get the position of the piece we are attacking
            points = chessPiece.GetComponent<ChessPieceController>().points; //Grabs the points of the current piece being attacked
            isBlack = !chessPiece.GetComponent<ChessPieceController>().GetIsWhite(); //Tells us the color of the piece
            gameController.GetComponent<GameController>().ChangePlayerPoints(points, isBlack); //Using the points of the other piece adjust the points based on the color of the piece and the worth of the points
            Destroy(chessPiece); //Destroy the piece we are attacking
        }

        /// When a piece is moving or attacking (Do this after moving or attacking)

        gameController.GetComponent<GameController>().SetPositionEmpty(reference.GetComponent<ChessPieceController>().GetXBoard(), reference.GetComponent<ChessPieceController>().GetYBoard()); //Gets the current position of the piece we want to move
        reference.GetComponent<ChessPieceController>().SetXBoard(matrixX); //Move that piece to the x position (Board Position, not World)
        reference.GetComponent<ChessPieceController>().SetYBoard(matrixY); //Move that piece to the y position (Board Position, not World)
        reference.GetComponent<ChessPieceController>().SetCords(); //Sets the Board postion to work with the world position

        if(reference.GetComponent<ChessPieceController>().pieceCode == 5) //If the piece that we are moving is a pawn, check if it is the first move
        {
            reference.GetComponent<ChessPieceController>().isPawnFirstMove = false;
        }

        if (reference.GetComponent<ChessPieceController>().pieceCode == 2) //If this piece is a rook, check if it is the first move
        {
            reference.GetComponent<ChessPieceController>().isRooksFirstMove = false;
        }

        if (gameController.GetComponent<GameController>().GetCurrentPlayersTurn() == "White") //Check for the current player's turn then switch the turn after moving
        {
            gameController.GetComponent<GameController>().ChangePlayerTurn("Black");
        } else
        {
            gameController.GetComponent<GameController>().ChangePlayerTurn("White");
        }

        gameController.GetComponent<GameController>().SetPosition(reference); //Keeps track of where our piece is in our chess grid

        reference.GetComponent<ChessPieceController>().DestroyMovePlates();


        if (reference.GetComponent<ChessPieceController>().pieceCode == 1) //If this piece is a king, check if it is the first move
        {
            reference.GetComponent<ChessPieceController>().isKingsFirstMove = false;
            if (reference.GetComponent<ChessPieceController>().CheckHasCastled() == false)
            {
                reference.GetComponent<ChessPieceController>().SetHasCastled(true);
                MoveRook(reference);
            }
        }
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

    public void MoveRook(GameObject reference) // Checks if the King is currently castling, if so move the rook with the king.
    {
            //Find the rooks
        GameObject rookLeftWhite = gameController.GetComponent<GameController>().playerWhite[0];
        GameObject rookRightWhite = gameController.GetComponent<GameController>().playerWhite[7];
        GameObject rookLeftBlack = gameController.GetComponent<GameController>().playerBlack[7];
        GameObject rookRightBlack = gameController.GetComponent<GameController>().playerBlack[0];

        if (reference.GetComponent<ChessPieceController>().pieceCode == 1)
        {
            bool isWhite = reference.GetComponent<ChessPieceController>().GetIsWhite();
            if (isWhite)
            {
                if(gameController.GetComponent<GameController>().GetPositions(2, 0) == reference)
                {
                    MoveRookCords(rookLeftWhite, 3,0);
                }

                if (gameController.GetComponent<GameController>().GetPositions(6, 0) == reference)
                {
                    MoveRookCords(rookRightWhite, 5, 0);
                }

            } else
            {
                if(!isWhite)
                {
                    if (gameController.GetComponent<GameController>().GetPositions(2, 7) == reference)
                    {
                        MoveRookCords(rookRightBlack, 3, 7);
                    }

                    if (gameController.GetComponent<GameController>().GetPositions(6, 7) == reference)
                    {
                        MoveRookCords(rookLeftBlack, 5, 7);
                    }
                }
            }

        }
    }

    public void MoveRookCords(GameObject reference, int xCord, int yCord) //Updates our rook's position
    {
        reference.GetComponent<ChessPieceController>().SetXBoard(xCord); //Move that piece to the x position (Board Position, not World)
        reference.GetComponent<ChessPieceController>().SetYBoard(yCord); //Move that piece to the y position (Board Position, not World)
        reference.GetComponent<ChessPieceController>().SetCords(); //Sets the Board postion to work with the world position
        gameController.GetComponent<GameController>().SetPosition(reference);
    }


}
