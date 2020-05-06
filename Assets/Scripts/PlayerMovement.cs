using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public float xp = 0;	
    public float xpForNextLevel = 10;   
    public int level = 1;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    void SetXpForNextLevel()
    {
        xpForNextLevel = (10f + (level * level * 5f));
        Debug.Log("xpForNextLevel " + xpForNextLevel);
    }

    void LevelUp()
    {
        xp = 0f;
        level++;
        Debug.Log("level" + level);
        SetXpForNextLevel();
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




    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float X = Input.GetAxis("Horizontal");
        float Z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * X + transform.forward * Z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.Space) == true && Mathf.Abs(this.GetComponent<Rigidbody>().velocity.y) < 0.01f)
        {
            this.GetComponent<Rigidbody>().velocity += Vector3.up * this.jumpHeight;
        }
       // if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
       // {
       //     velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
       // }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);


        //Test the GainXp function by pressing the x button. 
        if (Input.GetKeyDown(KeyCode.X) == true) { GainXP(1); }


        //LevelUp when the appropriate conditions are met.
        if (xp >= xpForNextLevel)
        {
            LevelUp();
        }
    }
}
