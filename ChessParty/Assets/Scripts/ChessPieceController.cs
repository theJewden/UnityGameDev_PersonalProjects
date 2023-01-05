using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessPieceController : MonoBehaviour
{
    ///Variables
        //Game Objects
    public GameObject gameController;
    public GameObject movePlate;
        //Cordinates
    private int xBoard = -1;
    private int yBoard = -1;
    public float[] adjustSpawn = { .66f, -2.3f };
        //Piece Idenity
    private bool isWhite; //If false our piece is black
    public int pieceCode; //Relates to the string piece name so 0 is queen, 5 is pawn=5
    public int points;
    public bool isPawnFirstMove;
    public string rookLocation = "default";
    public bool isKingsFirstMove;
    public bool isRooksFirstMove;
        //Sprite Renderer
    public Sprite blackQueenS, blackKingS, blackRookS, blackKnightS, blackBishopS, blackPawnS;
    public Sprite whiteKingS, whiteQueenS, whiteRookS, whiteKnightS, whiteBishopS, whitePawnS;
        //Misc Variables
    private string turn;
    private bool isCastling;

    public void Activate()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController"); //Find the Game Controller and set it to our variable

        SetCords();

        switch (this.name)
        {
            case "BlackQueen":
                this.GetComponent<SpriteRenderer>().sprite = blackQueenS;
                isWhite = false;
                pieceCode = 0;
                points = 9;
                break;

            case "BlackKing":
                this.GetComponent<SpriteRenderer>().sprite = blackKingS;
                isWhite = false;
                isKingsFirstMove = true;
                pieceCode = 1;
                break;

            case "BlackRook":
                this.GetComponent<SpriteRenderer>().sprite = blackRookS;
                isWhite = false;
                isRooksFirstMove = true;
                pieceCode = 2;
                points = 5;
                break;

            case "BlackKnight":
                this.GetComponent<SpriteRenderer>().sprite = blackKnightS;
                isWhite = false;
                pieceCode = 3;
                points = 3;
                break;

            case "BlackBishop":
                this.GetComponent<SpriteRenderer>().sprite = blackBishopS;
                isWhite = false;
                pieceCode = 4;
                points = 3;
                break;

            case "BlackPawn":
                this.GetComponent<SpriteRenderer>().sprite = blackPawnS;
                isWhite = false;
                pieceCode = 5;
                isPawnFirstMove = true;
                points = 1;
                break;

            case "WhiteQueen":
                this.GetComponent<SpriteRenderer>().sprite = whiteQueenS;
                isWhite = true;
                pieceCode = 0;
                points = 9;
                break;

            case "WhiteKing":
                this.GetComponent<SpriteRenderer>().sprite = whiteKingS;
                isWhite = true;
                isKingsFirstMove = true;
                pieceCode = 1;
                break;

            case "WhiteRook":
                this.GetComponent<SpriteRenderer>().sprite = whiteRookS;
                isWhite = true;
                isRooksFirstMove = true;
                pieceCode = 2;
                points = 5;
                break;

            case "WhiteKnight":
                this.GetComponent<SpriteRenderer>().sprite = whiteKnightS;
                isWhite = true;
                pieceCode = 3;
                points = 3;
                break;

            case "WhiteBishop":
                this.GetComponent<SpriteRenderer>().sprite = whiteBishopS;
                isWhite = true;
                pieceCode = 4;
                points = 3;
                break;

            case "WhitePawn":
                this.GetComponent<SpriteRenderer>().sprite = whitePawnS;
                isWhite = true;
                pieceCode = 5;
                isPawnFirstMove = true;
                points = 1;
                break;
        }
    }

    public void SetCords()
    {
        float x = xBoard;
        float y = yBoard;

        x *= adjustSpawn[0];
        y *= adjustSpawn[0];

        x += adjustSpawn[1];
        y += adjustSpawn[1];

        this.transform.position = new Vector3(x, y, 0);
    }

    public int GetXBoard()
    {
        return xBoard;
    }
    public int GetYBoard()
    {
        return yBoard;
    }

    public void SetXBoard(int num)
    {
        xBoard = num;
    }

    public void SetYBoard(int num)
    {
        yBoard = num;
    }

    public void DestroyMovePlates()
    {
        GameObject[] movePlates = GameObject.FindGameObjectsWithTag("MovePlate");
        for(int i = 0; i < movePlates.Length; i++)
        {
            Destroy(movePlates[i]);
        }
    }


    public void InitMovePlates()
    {
        if (gameController.GetComponent<GameController>().GetCurrentPlayersTurn() == "White")
        {
            turn = "White";
        } else
        {
            turn = "Black";
        }
        switch (pieceCode)
        {
            case 0: //Queen
                if(isWhite && turn == "White")
                {
                    LineMovePlate(1, 0); LineMovePlate(0, 1); LineMovePlate(1, 1); LineMovePlate(-1, 0); LineMovePlate(0, -1); LineMovePlate(-1, -1); LineMovePlate(1, -1); LineMovePlate(-1, 1);
                } else if(!isWhite && turn == "Black")
                {
                    LineMovePlate(1, 0); LineMovePlate(0, 1); LineMovePlate(1, 1); LineMovePlate(-1, 0); LineMovePlate(0, -1); LineMovePlate(-1, -1); LineMovePlate(1, -1); LineMovePlate(-1, 1);
                }
                break;

            case 1: //King
                if(isWhite && turn == "White")
                {
                    SurroundMovePlate();

                    if(isKingsFirstMove)
                    {
                        if (gameController.GetComponent<GameController>().CheckCheck() != "WhiteCheck")
                        {
                            GameObject rookLeft = gameController.GetComponent<GameController>().GetRook("White", "Left");
                            GameObject rookRight = gameController.GetComponent<GameController>().GetRook("White", "Right");

                            if(rookLeft.GetComponent<ChessPieceController>().isRooksFirstMove == true)
                            {
                                CastleMovePlate("Left");
                            }

                            if(rookRight.GetComponent<ChessPieceController>().isRooksFirstMove == true)
                            {
                                CastleMovePlate("Right");
                            }
                        }
                    }

                } else if(!isWhite && turn == "Black")
                {
                    SurroundMovePlate();

                    if (isKingsFirstMove)
                    {
                        if (gameController.GetComponent<GameController>().CheckCheck() != "BlackCheck")
                        {
                            GameObject rookLeft = gameController.GetComponent<GameController>().GetRook("Black", "Left");
                            GameObject rookRight = gameController.GetComponent<GameController>().GetRook("Black", "Right");

                            if (rookLeft.GetComponent<ChessPieceController>().isRooksFirstMove == true)
                            {
                                CastleMovePlate("Left");
                            }

                            if (rookRight.GetComponent<ChessPieceController>().isRooksFirstMove == true)
                            {
                                CastleMovePlate("Right");
                            }
                        }
                    }

                }

                break;

            case 2: //Rook
                if(isWhite && turn == "White")
                {
                    LineMovePlate(0, 1);
                    LineMovePlate(0, -1);
                    LineMovePlate(-1, 0);
                    LineMovePlate(1, 0);
                } else if (!isWhite && turn == "Black")
                {
                    LineMovePlate(0, 1);
                    LineMovePlate(0, -1);
                    LineMovePlate(-1, 0);
                    LineMovePlate(1, 0);
                }
                break;

            case 3: //Knight
                if(isWhite && turn == "White")
                {
                    LMovePlate();
                } else if(!isWhite && turn == "Black")
                {
                    LMovePlate();
                }

                break;

            case 4: //Bishop
                if(isWhite && turn == "White")
                {
                    LineMovePlate(1, 1);
                    LineMovePlate(1, -1);
                    LineMovePlate(-1, 1);
                    LineMovePlate(-1, -1);

                } else if(!isWhite && turn == "Black")
                {
                    LineMovePlate(1, 1);
                    LineMovePlate(1, -1);
                    LineMovePlate(-1, 1);
                    LineMovePlate(-1, -1);
                }

                break;
            case 5: //Pawn
                if (isWhite && turn == "White")
                {

                    if(isPawnFirstMove == true)
                    {
                        PawnMovePlate(xBoard, yBoard + 2, true);
                    }
                        PawnMovePlate(xBoard, yBoard + 1, false);

                }
                if(!isWhite && turn == "Black")
                {
                    if (isPawnFirstMove == true)
                    {
                        PawnMovePlate(xBoard, yBoard - 2, true);
                    }
                        PawnMovePlate(xBoard, yBoard - 1, false);              
                }
                break;
        }
    }

    public void LineMovePlate(int xI, int yI)
    {
        GameController gc = gameController.GetComponent<GameController>();
        int x = xBoard + xI;
        int y = yBoard + yI;

        while (gc.PositionOnBoard(x,y) && gc.GetPosition(x,y) == null)
        {
            MovePlateSpawn(x,y,false); //Spawn normal plate
            x += xI;
            y += yI;
        }

        if(gc.PositionOnBoard(x,y) && gc.GetPosition(x,y).GetComponent<ChessPieceController>().isWhite != isWhite)
        {
            MovePlateSpawn(x, y, true); //Spawn attack plate
        }
    }

    public void PawnMovePlate(int x, int y, bool godPawn)
    {
        GameController gc = gameController.GetComponent<GameController>();
        if(gc.PositionOnBoard(x,y))
        {
            if(gc.GetPosition(x,y) == null)
            {
                MovePlateSpawn(x, y, false);
            }

            if(!godPawn)
            {

                if (gc.PositionOnBoard(x + 1, y) && gc.GetPosition(x + 1, y) != null && gc.GetPosition(x + 1, y).GetComponent<ChessPieceController>().isWhite != isWhite)
                {
                    MovePlateSpawn(x + 1, y, true);
                }

                if (gc.PositionOnBoard(x - 1, y) && gc.GetPosition(x - 1, y) != null && gc.GetPosition(x - 1, y).GetComponent<ChessPieceController>().isWhite != isWhite)
                {
                    MovePlateSpawn(x - 1, y, true);
                }
            }
           

        }
    }

    public void CastleMovePlate(string rookPos)
    {
        int secondCord = 0;
        if (isWhite) { secondCord = 0; }
        else { secondCord = 7; }
        GameObject reference;
        GameObject rookRightW = gameController.GetComponent<GameController>().GetRook("White", "Right");
        GameObject rookLeft = gameController.GetComponent<GameController>().GetRook("Black", "Left");
        GameObject rookRight = gameController.GetComponent<GameController>().GetRook("Black", "Right");
        isCastling = true;

        if (rookPos == "Left")
        {
            if(isWhite && gameController.GetComponent<GameController>().GetPositions(1,secondCord) == null && gameController.GetComponent<GameController>().GetPositions(2, secondCord) == null && gameController.GetComponent<GameController>().GetPositions(3, secondCord) == null)
            {
                PointMovePlate(xBoard - 2, yBoard);
                reference = gameController.GetComponent<GameController>().GetRook("White", "Left");
            }

            if (!isWhite && gameController.GetComponent<GameController>().GetPositions(5, secondCord) == null && gameController.GetComponent<GameController>().GetPositions(6, secondCord) == null)
            {
                PointMovePlate(xBoard + 2, yBoard);
                reference = gameController.GetComponent<GameController>().GetRook("Black", "Left"); //WHOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
            }

        }

        if(rookPos == "Right")
        {
            if (!isWhite && gameController.GetComponent<GameController>().GetPositions(1, secondCord) == null && gameController.GetComponent<GameController>().GetPositions(2, secondCord) == null && gameController.GetComponent<GameController>().GetPositions(3, secondCord) == null)
            {
                PointMovePlate(xBoard - 2, yBoard);
            }

            if (isWhite && gameController.GetComponent<GameController>().GetPositions(5, secondCord) == null && gameController.GetComponent<GameController>().GetPositions(6, secondCord) == null)
            {
                PointMovePlate(xBoard + 2, yBoard);
            }
        }
    }

    public void LMovePlate()
    {
        PointMovePlate(xBoard + 1, yBoard + 2);
        PointMovePlate(xBoard - 1, yBoard + 2);
        PointMovePlate(xBoard + 1, yBoard - 2);
        PointMovePlate(xBoard - 1, yBoard - 2);
        PointMovePlate(xBoard + 2, yBoard + 1);
        PointMovePlate(xBoard + 2, yBoard - 1);
        PointMovePlate(xBoard - 2, yBoard + 1);
        PointMovePlate(xBoard - 2, yBoard - 1);
    }

    public void SurroundMovePlate()
    {
        PointMovePlate(xBoard + 1, yBoard);
        PointMovePlate(xBoard - 1, yBoard);
        PointMovePlate(xBoard, yBoard + 1);
        PointMovePlate(xBoard, yBoard - 1);
        PointMovePlate(xBoard + 1, yBoard + 1);
        PointMovePlate(xBoard - 1, yBoard -1);
        PointMovePlate(xBoard - 1, yBoard + 1);
        PointMovePlate(xBoard + 1, yBoard - 1);
    }

    public void PointMovePlate(int x, int y)
    {
        GameController gc = gameController.GetComponent<GameController>();
        if(gc.PositionOnBoard(x,y))
        {
            GameObject cp = gc.GetPosition(x, y);

            if (cp == null)
            {
                MovePlateSpawn(x, y, false);
            } else
            {
                if (cp.GetComponent<ChessPieceController>().isWhite != isWhite)
                {
                    MovePlateSpawn(x, y, true);
                }
            }
        }
    } 


    public void MovePlateSpawn(int matrixX, int matrixY, bool attack)
    {
        float x = matrixX;
        float y = matrixY;

        x *= adjustSpawn[0];
        y *= adjustSpawn[0];

        x += adjustSpawn[1];
        y += adjustSpawn[1];

        GameObject mp = Instantiate(movePlate, new Vector3(x, y, -3f), Quaternion.identity);
        MovePlateController movePlateController = mp.GetComponent<MovePlateController>();
        movePlateController.attack = attack;
        movePlateController.SetReference(gameObject);
        movePlateController.SetCords(matrixX, matrixY);
    }

    private void OnMouseUp()
    {
        DestroyMovePlates();
        InitMovePlates();
    }

    public bool GetIsWhite()
    {
        return isWhite;
    }

    public void SetRookLocation(string location)
    {

            rookLocation = location;
    }

}
