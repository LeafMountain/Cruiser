using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour {


    // Place the script on the door's mesh!
    public bool open = false;
    public float angleOpen = 90f;
    public float angleClose = 0f;
    public float openingSmoothness = 2f;

    // Use this for initialization
    void Start() {

    }

    public void ChangeDoorState(){
            open = !open;
        }

// Update is called once per frame
    void Update() {
        if (open)
        {
            Quaternion targetRotation = Quaternion.Euler(0, angleOpen, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, openingSmoothness * Time.deltaTime);

        }
        else
        {
            Quaternion targetRotation2 = Quaternion.Euler(0, angleClose, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation2, openingSmoothness * Time.deltaTime);
        }
    }
}
