using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class StoryboardProgression : MonoBehaviour {

    [SerializeField]string[] answers;
    [SerializeField]Scene[] scenes;         //Need to find a way to assign values in the inspector

    Rect rect;

    void Start()
    {
        rect = new Rect(0 + 10, Screen.height - 100, Screen.width, Screen.height);
    }

    //Creates text which is entered in the inspector and displayed on the bottom left of the screen. Needs a minimum of 2 answers.
    void OnGUI()
    {
        GUI.Label(new Rect(rect.x, rect.y - 60, rect.width, rect.height), "Pick one answer:");      //Need to make this editable in the inspector as well
        GUI.Label(new Rect(rect.x, rect.y - 40, rect.width, rect.height), "\n1. " + answers[0]);
        GUI.Label(new Rect(rect.x, rect.y - 20, rect.width, rect.height),"\n2. " + answers[1]);
        if (answers.Length > 2)
            GUI.Label(rect,"\n3. " + answers[2]);
    }

    //If the player presses a key from 1 to 3 the scene will change
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            SceneManager.LoadScene(scenes[0].name);
        else if (Input.GetKeyDown(KeyCode.Alpha2) && scenes[1] != null)
            SceneManager.LoadScene(scenes[1].name);
        else if (Input.GetKeyDown(KeyCode.Alpha3) && scenes[2] != null)
            SceneManager.LoadScene(scenes[2].name);
    }
}