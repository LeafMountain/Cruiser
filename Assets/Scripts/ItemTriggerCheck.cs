using UnityEngine;
using System.Collections;

public class ItemTriggerCheck : MonoBehaviour
{
    //The objects the script is looking for. Need to be an array later for check of multiple items.
    public GameObject interactableObject;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject == interactableObject)
            GetComponent<Collider>().enabled = false;
    }

    //Runs when item is placer. Need to discuss with the rest of the group on how to do this in a good way.
    void ItemPlaced()
    {
    }
}
