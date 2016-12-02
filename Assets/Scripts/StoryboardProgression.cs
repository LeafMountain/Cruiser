using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class StoryboardProgression : MonoBehaviour {

    [SerializeField]string[] answers;
    [SerializeField]Object[] scenes;
    public int[] sceneIDs;

    Rect rect;
    GUIStyle gStyle = new GUIStyle();

    void Awake()
    {
        rect = new Rect(0 + 10, Screen.height - 100, Screen.width, Screen.height);

        /*
        sceneIDs = new int[scenes.Length];
        for (int i = 0; i < scenes.Length; i++)
            sceneIDs[i] = SceneManager.GetSceneByName(scenes[i].name).buildIndex;*/
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
        {
            SceneManager.LoadScene(sceneIDs[0]);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && sceneIDs[1] != 0)
            SceneManager.LoadScene(sceneIDs[1]);
        else if (Input.GetKeyDown(KeyCode.Alpha3) && sceneIDs[2] != 0)
            SceneManager.LoadScene(sceneIDs[2]);
        else if (Input.GetKeyDown(KeyCode.Alpha4) && sceneIDs[3] != 0)
            SceneManager.LoadScene(sceneIDs[3]);
        else if (Input.GetKeyDown(KeyCode.Alpha5) && sceneIDs[4] != 0)
            SceneManager.LoadScene(sceneIDs[4]);
    }
}