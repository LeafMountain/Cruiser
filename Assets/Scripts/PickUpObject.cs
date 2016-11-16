using UnityEngine;
using System.Collections;

public class PickUpObject : MonoBehaviour {

	bool carrying;
	GameObject carriedObject;
	public float distance;
	public float smoothing;
    public float forceStrength;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (carrying) {
			carry(carriedObject);
			checkDrop();
            checkToss();
		}
		else {
			pickup();
		}
	}

	void carry(GameObject o) {
        o.transform.position = Vector3.Lerp(o.transform.position, Camera.main.transform.position + Camera.main.transform.forward * distance, Time.deltaTime * smoothing);
		o.transform.rotation = Quaternion.identity;
	}

	void pickup() {
		if(Input.GetKey (KeyCode.F)) {
			float x = Screen.width / 2;
			float y = Screen.height / 2;

            Ray ray = Camera.main.ScreenPointToRay(new Vector3(x, y));
            RaycastHit hit;
			if(Physics.Raycast(ray, out hit)) {
				Pickapable p = hit.collider.GetComponent<Pickapable>();
				if(p != null) {
					carrying = true;
					carriedObject = p.gameObject;
					p.gameObject.GetComponent<Rigidbody>().useGravity = false;
				}
			}
		}
	}

	void checkDrop() {
		if(Input.GetKey (KeyCode.F)) {
			dropObject();
		}
	}

	void dropObject() {
		carrying = false;
		carriedObject.gameObject.GetComponent<Rigidbody>().useGravity = true;
		carriedObject = null;
	}

    void checkToss()
    {
        if (Input.GetKeyDown (KeyCode.E))
        {
            tossObject();
        }
    }
    void tossObject()
    {
        carrying = false;
        carriedObject.gameObject.GetComponent<Rigidbody>().useGravity = true;
        carriedObject.gameObject.GetComponent<Rigidbody>().AddRelativeForce(forceStrength, ForceMode.Impulse);
        carriedObject = null;
    }
}
