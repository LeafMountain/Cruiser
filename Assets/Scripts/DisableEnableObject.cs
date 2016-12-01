using UnityEngine;
using System.Collections;

public class DisableEnableObject : MonoBehaviour {

    public GameObject enableThis;
    public GameObject disableThis;
	
	public void EnableDisable ()
    {
        enableThis.SetActive(true);
        disableThis.SetActive(false);
	}

    void Start()
    {
        EnableDisable();
    }
}
