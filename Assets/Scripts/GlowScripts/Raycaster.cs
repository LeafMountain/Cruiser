using UnityEngine;

public class Raycaster : MonoBehaviour
{
    private Ray ray;
    private RaycastHit rayHit;
    [Tooltip("How far away shall the glow-effect be triggered?")]public float rayCastLength = 15f;
    private Behaviour halo;
    [Tooltip("Change the tag to the tag that the items "+ 
        "that shall have the gloweffect!")] public string glowTag = "Usable";

    private void FixedUpdate()
    {
        //debug Ray for the inspector
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * rayCastLength, Color.green);
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, out rayHit, rayCastLength))
        {
            if (rayHit.transform.tag == glowTag)
            {
                Debug.Log("You hit: " + rayHit.transform.gameObject.name);
                rayHit.transform.GetComponent<HaloScript>().haloOnOff();                
            }
        }        
    }
}