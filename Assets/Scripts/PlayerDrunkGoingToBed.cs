using UnityEngine;
using System.Collections;

public class PlayerDrunkGoingToBed : MonoBehaviour {

    Collider col;
    Camera cam;
    FadeScreen fade;
    public Player charMove;
    public GameObject newCam;


    void Start()
    {
        col = GetComponent<Collider>();
        fade = GetComponent<FadeScreen>();
    }

	void OnTriggerEnter(Collider col)
    {
        cam = col.GetComponentInChildren<Camera>();
    }

    void Update()
    {
        if(cam != null)
        {
            if (Vector3.Distance(cam.transform.position, newCam.transform.position) > 0.05f)
            {
                cam.transform.position = Vector3.Lerp(cam.transform.position, newCam.transform.position, Time.deltaTime * 1.5f);
                cam.transform.rotation = Quaternion.Lerp(cam.transform.rotation, newCam.transform.rotation, Time.deltaTime * 1.5f);
                charMove.enabled = false;
            }
            else
            {
                cam.enabled = false;
                newCam.SetActive(true);
            }
        }
    }
}
