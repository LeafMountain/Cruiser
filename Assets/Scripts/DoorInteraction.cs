using UnityEngine;
using System.Collections;

public class DoorInteraction : MonoBehaviour {

    public float interactLength = 3f;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, interactLength))
            {
                if (hit.collider.CompareTag("Door")){
                    hit.collider.transform.parent.GetComponent<DoorScript>().ChangeDoorState();
                }
            }
        }
	
	}
}
