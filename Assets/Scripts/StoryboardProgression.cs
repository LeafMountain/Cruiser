using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class StoryboardProgression : MonoBehaviour {

    [SerializeField]string[] answers;
    [SerializeField]Object[] scenes;

    Rect rect;
    GUIStyle gStyle = new GUIStyle();
    //public Color fontColor;

    void Awake()
    {
        rect = new Rect(0 + 10, Screen.height - 100, Screen.width, Screen.height);

    }

    void Start()
    {
        gStyle.fontSize = 30;
    }

    //Creates text which is entered in the inspector and displayed on the bottom left of the screen. Needs a minimum of 2 answers.
    void OnGUI()
    {
        GUI.Label(new Rect(rect.x, rect.y - 120, rect.width, rect.height), "\n1. " + answers[0], gStyle);
        if (answers.Length > 1)
            GUI.Label(new Rect(rect.x, rect.y - 90, rect.width, rect.height),"\n2. " + answers[1], gStyle);
        if (answers.Length > 2)
            GUI.Label(new Rect(rect.x, rect.y - 60, rect.width, rect.height), "\n3. " + answers[2], gStyle);
        if (answers.Length > 3)
            GUI.Label(new Rect(rect.x, rect.y - 30, rect.width, rect.height), "\n4. " + answers[3], gStyle);
        if (answers.Length > 4)
            GUI.Label(new Rect(rect.x, rect.y, rect.width, rect.height), "\n5. " + answers[4], gStyle);
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
        else if (Input.GetKeyDown(KeyCode.Alpha4) && scenes[3] != null)
            SceneManager.LoadScene(scenes[3].name);
        else if (Input.GetKeyDown(KeyCode.Alpha5) && scenes[4] != null)
            SceneManager.LoadScene(scenes[4].name);
    }
}