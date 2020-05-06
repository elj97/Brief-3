using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 
       Player Controller that moves and turns faster as it gains XP;
	    Manages moving and rotating the player via the arrow keys.
		Up/down arrow keys to move forward and backward.
		Left/right arrow keys to rotate left and right.
*/

public class PlayerControllerThatLevelsUp : MonoBehaviour
{

    //The base move and turn speed
    public float moveSpeed = 1f;
    public float turnSpeed = 45f;
    public float jumpHeight = 5f;

    //The move and turn speed with the buffs you have from leveling up.   
    public float currentMoveSpeed;
    public float currentTurnSpeed;
    public float currentJumpHeight;


    public float xp = 0;	// Amount of XP the player has
    public float xpForNextLevel = 5;   //Xp needed to level up, the higher the level, the harder it gets. 
    public int level = 1;   // Level of the player





    private void Start()
    {
        SetXpForNextLevel();
        SetCurrentMoveSpeed();
        SetCurrentTurnSpeed();
        SetCurrentJumpHeight();
    }



    // To level up you need to collect an amount of xp;
    // This starts at 10 xp
    // Each level you gain the xp required gets higher exponentially
    // The exponential growth is slowed by scaling it by 10%

    void SetXpForNextLevel()
    {
        xpForNextLevel = (5f + (level * level * 5f));
        Debug.Log("xpForNextLevel " + xpForNextLevel);
    }



    // For each level, the player adds 10% to the move speed 
    void SetCurrentMoveSpeed()
    {
        currentMoveSpeed = this.moveSpeed + (this.moveSpeed * 0.1f * level);
        Debug.Log("currentMoveSpeed = " + currentMoveSpeed);
    }

    // For each level, the player adds 10% to the turn speed 
    void SetCurrentTurnSpeed()
    {
        currentTurnSpeed = this.turnSpeed + (this.turnSpeed * (level * 0.1f));
        Debug.Log("currentTurnSpeed = " + currentTurnSpeed);
    }

    // For each level, the player adds 10% to jump height 
    void SetCurrentJumpHeight()
    {
        currentJumpHeight = this.jumpHeight + (this.jumpHeight * (level * 0.75f));
        Debug.Log("currentTJumpHeight = " + currentJumpHeight);
    }

    void LevelUp()
    {
        xp = 0f;
        level++;
        Debug.Log("level" + level);
        SetXpForNextLevel();
        SetCurrentMoveSpeed();
        SetCurrentTurnSpeed();
        SetCurrentJumpHeight();

    }




    //a function to make the player gain the ammount of Xp the you tell it. 
    public void GainXP(int xpToGain)
    {
        xp += xpToGain;
        Debug.Log("Gained " + xpToGain + " XP, Current Xp = " + xp + ", XP needed to reach next Level = " + xpForNextLevel);
    }

    void OnTriggerEnter(Collider target)
    {
        if (target.tag == "Coin")
        {
            GainXP(5);
        }
    }


    void Update()
    {
        //Test the GainXp function by pressing the x button. 
        if (Input.GetKeyDown(KeyCode.X) == true) { GainXP(1); }


        //LevelUp when the appropriate conditions are met.
        if (xp >= xpForNextLevel)
        {
            LevelUp();
        }





        // Rotation and movement speed is modifed by the level (currentMoveSpeed) of the player and by the time between update frames (Time.deltaTime). 

        // Move player via up/down arrow keys
        if (Input.GetKey(KeyCode.UpArrow) == true) { this.transform.position += this.transform.forward * currentMoveSpeed * Time.deltaTime; }
        if (Input.GetKey(KeyCode.DownArrow) == true) { this.transform.position -= this.transform.forward * currentMoveSpeed * Time.deltaTime; }

        // Rotate player via left/right arrow keys
        // Identify this position, set the vertical axis as the axis to rotate around the set the rotation speed.
        if (Input.GetKey(KeyCode.RightArrow) == true) { this.transform.RotateAround(this.transform.position, Vector3.up, currentTurnSpeed * Time.deltaTime); }
        if (Input.GetKey(KeyCode.LeftArrow) == true) { this.transform.RotateAround(this.transform.position, Vector3.up, -currentTurnSpeed * Time.deltaTime); }
        
        // Check spacebar to trigger jump. Check if vertical velocity (velocity.y) is near to zero.
        if (Input.GetKey(KeyCode.Space) == true && Mathf.Abs (this.GetComponent<Rigidbody>().velocity.y) <0.01f)
        {
            this.GetComponent<Rigidbody>().velocity += Vector3.up * this.currentJumpHeight;
        }

        // Win
        if (level > 3)
        {
            Debug.Log("Win");
        }
    }
}