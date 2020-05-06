using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCubeController : MonoBehaviour
{
    public int id;

    public float damage = 50f;

    private void Start()
    {
        GameEvents.current.onDeathcubeTriggerEnter += OnDeath;
    }

   
    private void OnDeath(int id)
    {
        if (id == this.id)
        {           
            PlayerHealth player = transform.GetComponent<PlayerHealth>();
            if (player != null)
            {
                player.TakeDamage(damage);
            }
        }
    }

    private void OnDestroy()
    {
        GameEvents.current.onDeathcubeTriggerEnter -= OnDeath;
    
    }
}

