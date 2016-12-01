using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ChangeScene : MonoBehaviour {

    public int sceneId;
	void Start ()
    {
        SceneManager.LoadScene(sceneId);
	}
	
}
