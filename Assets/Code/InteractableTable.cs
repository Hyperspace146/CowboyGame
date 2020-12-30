using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Interactable))]
public class InteractableTable : MonoBehaviour
{
    void Start()
    {
        GetComponent<Interactable>().OnInteract += FlipTable;
    }

    void FlipTable(GameObject playerFlippingTable)
    {
        // Change the layer of the solid (rather than interactable) hitbox so that now the table can block gunfire
        transform.Find("Solid Hitbox").gameObject.layer = LayerMask.NameToLayer("Default");
    }
}
