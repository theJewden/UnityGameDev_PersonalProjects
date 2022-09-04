using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitDestroySelf : MonoBehaviour
{
    public float seconds = 1f;


    public void TimedDestroySelf()
    {
        StartCoroutine(DestroySelf());
    }

    IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }


}
