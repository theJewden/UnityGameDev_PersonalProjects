using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private int tempAmountOfDouJumps = 0;
    public float speed = 5;
    public float jumpSpeed = 5;
    public float doubleJumpSpeed = 5;
    private float hMovement = 0;
    private bool isMidAir = true;
    private bool isDoubleJump = false;
    private bool isJustJump = false;
    private Rigidbody2D player;

    private void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        hMovement = Input.GetAxis("Horizontal");

        if (hMovement != 0)
        {
            transform.position += Vector3.right * (hMovement * Time.deltaTime * speed);
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isMidAir)
        {
            player.velocity = new Vector2(player.velocity.x, jumpSpeed);
            isJustJump = true;
        }


        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJustJump = false;
        }

        if (isMidAir && !isDoubleJump && !isJustJump && Input.GetKeyDown(KeyCode.Space))
        {
            player.velocity = new Vector2(player.velocity.x, doubleJumpSpeed);
            isDoubleJump = true;
            tempAmountOfDouJumps++;
            Debug.Log("You Double Jumped! (" + tempAmountOfDouJumps + ")");
        }

        transform.localRotation = Quaternion.identity;

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Solid")
        {
            isMidAir = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Solid")
        {
            isMidAir = true;
            isDoubleJump = false;
        }
    }


}
