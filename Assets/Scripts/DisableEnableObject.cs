using UnityEngine;
using System.Collections;

public class DisableEnableObject : MonoBehaviour {

    public GameObject enableThis;
    public GameObject disableThis;
	
	public void EnableDisable ()
    {
        if (enableThis != null)
            enableThis.SetActive(true);
        if(disableThis != null)
            disableThis.SetActive(false);
	}

    void Start()
    {
        EnableDisable();
    }
}
