using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Script: Coin
    Author: Gareth Lockett Pete Phillips
    Version: 2.0
    Description:    A simple script for a coin pickup. Make sure the coin object has a collider set to trigger.
                    The script spins/rotates the GameObject it is on.
                    When a GameObject, with a Rigidbody component, and tagged as Player enters the trigger, the player will get XP and this GameObject will be destroyed.

                    Note: This Script requires the PlayerControllerThatLevelsUp script.
*/

public class Coin : MonoBehaviour
{
    public float spinSpeed = 100f;
    public int xpValue = 1;

    void Update()
    {
        this.transform.Rotate(0f, 0f, Time.deltaTime * this.spinSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerMovement>().GainXP(xpValue);
            Destroy(this.gameObject);
        }


    }
}