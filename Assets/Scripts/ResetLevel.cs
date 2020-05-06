using UnityEngine;
using UnityEngine.SceneManagement;

/*
    Script: ResetLevel
    Author: Gareth Lockett
    Version: 1.0
    Description:    Super simple script to reload the current level when the escape key is pressed.
                    Attach this script to any game object in the scene.
*/

public class ResetLevel : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) == true) { SceneManager.LoadScene(0); }
    }
}