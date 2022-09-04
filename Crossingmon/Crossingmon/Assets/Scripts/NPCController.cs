using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NPCController : MonoBehaviour
{
    public UnityEvent onTriggerEvent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Interact")
        {
            if(GetComponent<DialogueController>().coolDown == false)
            {
                onTriggerEvent.Invoke();
            } else
            {
                return;
            }
        }
    }
}
