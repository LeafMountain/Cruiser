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

	void carry(GameObject obj) {
        obj.transform.position = Vector3.Lerp(obj.transform.position, Camera.main.transform.position + Camera.main.transform.forward * distance, Time.deltaTime * smoothing);
        obj.transform.rotation = Camera.main.transform.rotation; //Objektet roteras jämnlikt med kamerans vinkel.
        //obj.transform.rotation = Quaternion.identity; //Objektet roterar ej med kameran.
    }

	void pickup() {
		if(Input.GetKeyDown (KeyCode.F)) {
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
		if(Input.GetKeyDown (KeyCode.F)) {
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
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            tossObject();
        }
    }
    void tossObject()
    {
        carrying = false;
        carriedObject.gameObject.GetComponent<Rigidbody>().useGravity = true;
        carriedObject.gameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * forceStrength);
        carriedObject = null;
    }
}
