using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueController : MonoBehaviour //Can fit 305 Characters
{
    //Variables -------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //GameObject Vars
    public GameObject textBox;
    public GameObject npcSprite;
    private GameObject Player;
    private GameObject audioController;
        //TextMeshPro Vars
    public TMP_Text nameSpace;
    public TMP_Text dialogue;
        //String Var(s)
    public string[] textArray; //Set up in the Unity Inspector. This will be the dialogue the NPC/Player will say.
        //Integer Vars
    public int[] npcSpriteManager; //In the inspector this is how we will change out images based on each dialogue.
    private int npcSpriteNum;
    private int amount;
    private int i = 1;
        //Bool Vars
    private bool speech = false;
    private bool next = false;
    public bool coolDown = false;
        //Float Vars
    private float coolDownTimer = 0;
    private float coolDownMaxTimer = 1; //How long we want the cooldown timer to run for
        //CharacterDetails Var
    public CharacterDetails npc;

    //Start and Update Functions

    private void Start()
    {
        Player = GameObject.Find("Player"); //Get our player
        audioController = GameObject.Find("AudioController"); // Get the audio controller
    }

    public void Update() 
    {
//The Dialogue Code ------------------------------------------------------------------------------------------------------------------------------------------------------------------
        amount = textArray.Length -1; //Set our varible amount to be equal to the number of strings in our array 

        if(speech && !coolDown)
        {
            if(!next && !coolDown)
            {
                //Set our text objects for the name and the dialogue
                dialogue.text = textArray[i]; //Set our array to the value of i (by default it is 1 because 0 is the name)
                audioController.GetComponent<AudioController>().Play("Interact"); //Play sound as we interact with the dialogue
                next = true; //Prevents this code from constantly being reran until spacebar is hit
                if(npc != null)
                {
                    nameSpace.text = npc.npcName;
                    npcSpriteNum = npcSpriteManager[i];
                    npcSprite.GetComponent<Image>().sprite = npc.npcSprites[npcSpriteNum];

                } else
                {
                    nameSpace.text = textArray[0]; //Name should always be the first in our array (If there isn't a npc Scriptable Object)
                }
            }


            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (i <= amount) //Only run if we have enough dialogue
                {
                    i++;
                    next = false; //Rerun our code to check for the dialogue text since the value of i increased
                }
                if(i > amount) //If we don't have enough dialogue end the speech
                {
                    coolDown = true; //Start a cooldown so we cannot spam the speech
                    speech = false;
                    next = true;
                    Debug.Log("Ending dialogue");
                    audioController.GetComponent<AudioController>().Play("MenuSelect");
                    Player.GetComponent<PlayerController>().canInteract = true;
                    Player.GetComponent<PlayerController>().canMove = true;
                    textBox.SetActive(false);

                    if (npc != null) { npcSprite.SetActive(false); }
                }
            }

        }

        if(coolDown) //Cooldown timer
        {
            if(coolDownTimer < coolDownMaxTimer)
            {
                coolDownTimer += 1 * Time.deltaTime;
            } else
            {
                coolDownTimer = 0;
                coolDown = false;
                next = false;
                if(npc != null)
                {
                    i = 0;
                } else
                {
                    i = 1;
                }
            }
        }


    }

    public void StartTalking() //Call from the Unity Inpector to start the dialogue
    {
        speech = true;
        Player.GetComponent<PlayerController>().canInteract = false;
        Player.GetComponent<PlayerController>().canMove = false;
        textBox.SetActive(true);

        if(npc != null) 
        {
            npcSprite.SetActive(true);
            i = 0;
        }
    }



}
