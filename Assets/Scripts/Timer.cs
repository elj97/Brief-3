//Attach this script to a GameObject
//Create a Button (Create>UI>Button) and a Text GameObject (Create>UI>Text)
//Click on the GameObject and attach the Button and Text in the fields in the Inspector

//This script outputs the time since the last level load. It also allows you to load a new Scene by pressing the Button. When this new Scene loads, the time resets and updates.

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

public class TimeSinceLevelLoad : MonoBehaviour
{
    public UnityEvent keyPressed;
    public Button timerButton;
    public Text timerText;


    void Awake()
    {
        //Don't destroy the GameObject when loading a new Scene
        DontDestroyOnLoad(gameObject);
        //Make sure the Canvas isn't deleted so the UI stays on the Scene load
        DontDestroyOnLoad(GameObject.Find("timerCanvas"));

        if (timerButton != null)
            //Add a listener to call the LoadSceneButton function when the Button is clicked
            timerButton.onClick.AddListener(LoadSceneButton);
    }

    void Update()
    {
        //Output the time since the level loaded to the screen using this label
        timerText.text = "Time Since Loaded : " + Time.timeSinceLevelLoad;
    }

    void LoadSceneButton()
    {
        //Press this Button to load another Scene
        //Load the Scene
        SceneManager.LoadScene("b3 project");
    }
}