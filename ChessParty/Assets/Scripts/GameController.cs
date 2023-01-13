using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    ///Variables
        //Game Objects
    public GameObject chessPiece;
    public GameObject timer;
    private GameObject[,] positions = new GameObject[8,8];
    public GameObject[] playerBlack = new GameObject[16];
    public GameObject[] playerWhite = new GameObject[16];
    private GameObject playerWhitePassantPawn;
    private GameObject playerBlackPassantPawn;
        //Check for whose turn and if it is check
    private bool isWhitesTurn = true;
    private bool isCheckWhite = false;
    private bool isCheckBlack = false;
    private bool isCheckMate = false;
        //Integer and Floats
    private float[] adjustSpawn = { 1.22f, -4.275f }; //Adjusts the spawn to fit our cortinate system
    private int blackPoints = 0;
    private int whitePoints = 0;

    void Start()
    {
        ///Create the pieces on Start() using our Create function, arrays, and a forloop

            //Set the variables to create the pieces with the proper cordinates
        playerWhite = new GameObject[] //Sets the creation of white's pieces to this array
        {
            Create("WhiteRook", 0, 0), Create("WhiteKnight", 1, 0), Create("WhiteBishop", 2, 0), Create("WhiteQueen", 3, 0), Create("WhiteKing", 4, 0), Create("WhiteBishop", 5, 0),
            Create("WhiteKnight",6,0), Create("WhiteRook", 7, 0), Create("WhitePawn", 0, 1), Create("WhitePawn", 1, 1), Create("WhitePawn", 2, 1), Create("WhitePawn", 3, 1),
            Create("WhitePawn", 4, 1), Create("WhitePawn", 5, 1), Create("WhitePawn", 6, 1), Create("WhitePawn", 7, 1)
        };

        playerBlack = new GameObject[] //Sets the creation of black's pieces to this array
{
            Create("BlackRook", 0, 7), Create("BlackKnight", 1, 7), Create("BlackBishop", 2, 7), Create("BlackQueen", 3, 7), Create("BlackKing", 4, 7), Create("BlackBishop", 5, 7),
            Create("BlackKnight",6,7), Create("BlackRook", 7, 7), Create("BlackPawn", 0, 6), Create("BlackPawn", 1, 6), Create("BlackPawn", 2, 6), Create("BlackPawn", 3, 6),
            Create("BlackPawn", 4, 6), Create("BlackPawn", 5, 6), Create("BlackPawn", 6, 6), Create("BlackPawn", 7, 6)
        };

        //Using our array, actually initiate all of our create functions using a forloop. (Activating our playerWhite and playerBlack variables)

        for(int i = 0; i < playerWhite.Length; i++)
        {
            SetPosition(playerBlack[i]);
            SetPosition(playerWhite[i]);
        }

        playerBlack[0].GetComponent<ChessPieceController>().SetRookLocation("Right");
        playerWhite[0].GetComponent<ChessPieceController>().SetRookLocation("Left");
        playerBlack[7].GetComponent<ChessPieceController>().SetRookLocation("Left");
        playerWhite[7].GetComponent<ChessPieceController>().SetRookLocation("Right");

        StartTurnTimer("White");
    }

   public GameObject Create(string pieceName, int x, int y) //This create function allows us to use our array from earlier to assign attributes to our pieces, like name and position
    {
        GameObject cp = Instantiate(chessPiece, new Vector3(0, 0, -1), Quaternion.identity);
        ChessPieceController chessPieceController = cp.GetComponent<ChessPieceController>();
        chessPieceController.name = pieceName;
        chessPieceController.SetXBoard(x);
        chessPieceController.SetYBoard(y);
        chessPieceController.adjustSpawn[0] = adjustSpawn[0];
        chessPieceController.adjustSpawn[1] = adjustSpawn[1];
        chessPieceController.Activate();
        return cp;
    }

    public void SetPosition(GameObject cp) //Updates our position variable with all of the piece's positions
    {
        ChessPieceController chessPieceController = cp.GetComponent<ChessPieceController>();
        positions[chessPieceController.GetXBoard(), chessPieceController.GetYBoard()] = cp;
    }

    public void SetPositionEmpty(int x, int y)
    {
        positions[x, y] = null;
    }
    public GameObject GetPosition(int x, int y)
    {
        return positions[x, y];
    }

    public bool PositionOnBoard(int x, int y)
    {
        if(x < 0 || y < 0 || x >= positions.GetLength(0) || y >= positions.GetLength(0))
        {
            return false;
        } else
        {
            return true;
        }
    }

    public void ChangePlayerPoints(int pointValue, bool isBlack)
    {
        if(isBlack)
        {
            blackPoints -= pointValue;
            whitePoints += pointValue;

        } else
        {
            blackPoints += pointValue;
            whitePoints -= pointValue;
        }

        print("White Points: " + whitePoints + ". Black Points: " + blackPoints);
    }

    public void ChangePlayerTurn(string player)
    {
        if(player == "White")
        {
            isWhitesTurn = true;
            StartTurnTimer(player);
        } else if(player == "Black")
        {
            isWhitesTurn = false;
            StartTurnTimer(player);
        }
    }
    public string GetCurrentPlayersTurn()
    {
        if (isWhitesTurn)
        {
            return "White";
        } else
        {
            return "Black";
        }
    }

    public void ChangeCheck(string player, bool isChecked)
    {
        if(player == "White")
        {
            isCheckWhite = isChecked;
        } else if(player == "Black")
        {
            isCheckBlack = isChecked;   
        } else
        {
            Debug.Log("Something is wrong with the checking process.");
        }
    }

    public string CheckCheck()
    {
        if(isCheckWhite)
        {
            return "WhiteCheck";
        } else if(isCheckBlack)
        {
            return "BlackCheck";
        } else
        {
            return null;
        }
    }

    public bool IsCheckMate()
    {
        return isCheckMate;
    }


    public GameObject GetRook(string player, string position)
    {
        if(player == "White")
        {

            if(position == "Left")
            {
                return playerWhite[0];

            } else
            {
                return playerWhite[7];
            }

        }else if(player == "Black")
        {
            if(position == "Left")
            {
                return playerBlack[7];
            } else
            {
                return playerBlack[0];
            }

        } else
        {
            return null;
        }
    }

    public GameObject GetPositions(int x1,int y1)
    {
        return positions[x1,y1];
    }

    public void SetPassantPawn(GameObject pawn, bool isWhite)
    {
        if(isWhite)
        {
            playerWhitePassantPawn = pawn;
        } else
        {
            playerBlackPassantPawn = pawn;
        }
    }

    public GameObject CheckPassantPawn(bool isWhite)
    {
        if(isWhite)
        {

            return playerWhitePassantPawn;

        } else if(!isWhite)
        {

            return playerBlackPassantPawn;

        } else
        {
            Debug.Log("Something went wrong while trying to find the passant pawn");
            return null;
        }
    }

    public void ResetPassantPawn()
    {
        if(playerWhitePassantPawn != null)
        {
            playerWhitePassantPawn = null;
        }

        if(playerBlackPassantPawn != null)
        {
            playerBlackPassantPawn = null;
        }
    }

    public void StartTurnTimer(string player)
    {
        if(player == "White")
        {
            CreateTimer("White's Turn Timer");

        } else
        {
            CreateTimer("Black's Turn Timer");
        }
    }

    public GameObject CreateTimer(string nam)
    {
        GameObject theTimer = Instantiate(timer, new Vector3(0, 0, -1), Quaternion.identity);
        TurnTimer turnTimer = theTimer.GetComponent<TurnTimer>();

        turnTimer.name = nam;
        turnTimer.isWhitesTurn = isWhitesTurn;
        turnTimer.StartTimer(1f);


        return theTimer;
    }
}
