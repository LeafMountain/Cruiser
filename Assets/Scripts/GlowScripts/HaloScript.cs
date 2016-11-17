using UnityEngine;
using System.Collections;

public class HaloScript : MonoBehaviour
{
    private Behaviour halo;
    private bool isRunning;
    public float glowTime = 2f;
    
    private void Awake()
    {
        if ((Behaviour)GetComponent("Halo") != null)
        {
            halo = (Behaviour)GetComponent("Halo");
        }
        else Debug.Log("No Halo-Effect available, please add one in the inspector before running the scene!");
    }   

    public void haloOnOff()
    {
        if (halo != null)
        {
            if (!isRunning)
            {
                StartCoroutine(haloSwitch(glowTime));
            }
        }
        else Debug.Log("No Halo-Effect available, please add one in the inspector before running the scene!"); 
    }
    
    IEnumerator haloSwitch(float time)
    {
        halo.enabled = true;
        isRunning = true;
        yield return new WaitForSeconds(time);
        halo.enabled = false;
        isRunning = false;
        yield break;        
    }
}
