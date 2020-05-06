using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
 
    public float health = 50f;
    public int xpValue = 5;
    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {    
     Destroy(gameObject);
     //gameObject.GetComponent<PlayerMovement>().GainXP(xpValue);
    }

}

  
    

