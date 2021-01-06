using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Interactable))]
public class InteractableTable : MonoBehaviour
{
    [Tooltip("The solid, non-trigger collider for this table.")]
    public BoxCollider2D SolidCollider;

    private Animator animator;

    float leftSideOfTable;
    float rightSideOfTable;
    float topSideOfTable;
    float bottomSideOfTable;

    void Start()
    {
        GetComponent<Interactable>().OnInteract += FlipTable;

        animator = GetComponent<Animator>();

        leftSideOfTable = SolidCollider.bounds.center.x - SolidCollider.bounds.extents.x;
        rightSideOfTable = SolidCollider.bounds.center.x + SolidCollider.bounds.extents.x;
        topSideOfTable = SolidCollider.bounds.center.y + SolidCollider.bounds.extents.y;
        bottomSideOfTable = SolidCollider.bounds.center.y - SolidCollider.bounds.extents.y;
    }

    void FlipTable(GameObject playerFlippingTable)
    {
        // Figure out which side of the table the player is on when they interacted with the table:
        Vector3 closestPoint = SolidCollider.bounds.ClosestPoint(playerFlippingTable.transform.position);

        // The table state ID goes by never-eat-soggy-waffles order. 
        if (closestPoint.y == topSideOfTable)
        {
            Debug.Log("flip");
            animator.SetInteger("TableState", 0);
        }
        else if (closestPoint.x == rightSideOfTable)
        {
            animator.SetInteger("TableState", 1);
        }
        else if (closestPoint.y == bottomSideOfTable)
        {
            animator.SetInteger("TableState", 2);
        }
        else if (closestPoint.x == leftSideOfTable)
        {
            animator.SetInteger("TableState", 3);
        }

        // Change the layer of the solid (rather than interactable) hitbox so that now the table can block gunfire
        transform.Find("Solid Collider").gameObject.layer = LayerMask.NameToLayer("Default");

        // Make the table not interactable anymore
        GetComponent<Interactable>().enabled = false;
        GetComponent<SpriteOutline>().enabled = false;
    }
}
