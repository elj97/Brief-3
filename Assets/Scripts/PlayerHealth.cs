using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int id;

    public float health = 100f;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
        else
        {
            Debug.Log("Remaining Health" + health);
        }
    }

    void Die()
    {
        SceneManager.LoadScene("b3 project");
    }

}
