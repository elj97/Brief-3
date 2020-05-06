using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyInputEvents : MonoBehaviour
{
    //Events
    public UnityEvent keyPressed;

    // Properties
    public KeyCode key = KeyCode.Delete;

    // Methods
    private void Update()
    {
        if(Input.GetKeyDown(this.key) == true)
        {
            if(this.keyPressed != null) { this.keyPressed.Invoke(); }
        }
    }
}
