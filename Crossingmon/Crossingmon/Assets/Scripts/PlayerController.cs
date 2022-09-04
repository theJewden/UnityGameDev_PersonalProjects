using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variables ----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //Movement Vars
    public float speed = 5;
    private string[] getDir = {"Up", "Down", "Left", "Right"};
    private string dir;

        //Interaction Vars
    public bool canInteract = true;
    public bool canMove = true;

        //Gameobject Vars
    public GameObject interactCir;

    void Update()
    {

    //Inputs & Movement --------------------------------------------------------------------------------------------------------------------------------------------------------------
        //Input Vars (Check for their value with each frame)
    float horiInput = Input.GetAxis("Horizontal"); //Get the Horizontal input
    float vertInput = Input.GetAxis("Vertical"); //Get the Vertical Input

        //Move Player
    if((horiInput != 0 || vertInput != 0) && canMove) //If the horizontal key is pressed move player
        {
            transform.position += Vector3.right * horiInput * Time.deltaTime * speed;
            transform.position += Vector3.up * vertInput * Time.deltaTime * speed;
        }
        GetDir(); //Get the direction we are facing

        //Create An Interaction Trigger Circle
    if (Input.GetKeyDown(KeyCode.Space) && canInteract)
    {

    if (dir == getDir[0])
    {
        createInteract(Vector3.up);
    }

    if(dir == getDir[1])
    {
        createInteract(Vector3.down);
    }

    if(dir == getDir[2])
    {
        createInteract(Vector3.left);
    }

    if(dir == getDir[3])
    {
        createInteract(Vector3.right);
    }
}

    }


    //Other Voids ---------------------------------------------------------------------------------------------------------------------------------------------------------------------
    private void createInteract(Vector3 direction)
    {
        Vector3 playerPosition = gameObject.transform.position;
        Instantiate(interactCir, (playerPosition += direction), transform.rotation);
    }

    private void GetDir()
    {
        if(Input.GetKey(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) { dir = getDir[0]; }

        if(Input.GetKey(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) { dir = getDir[1]; }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) { dir = getDir[2]; }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) { dir = getDir[3]; }
    }


}
