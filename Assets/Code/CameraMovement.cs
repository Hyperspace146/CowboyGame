using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Manages the placement of the camera so that it encompasses all characters and crosshairs in game
 * as best as it can whlie remaining the same in size.
 */
public class CameraMovement : MonoBehaviour
{
    void Update()
    {
        // Could be a source of lag. Needs testing
        Stack<Vector2> playersAndCrosshairPositions = new Stack<Vector2>();
        foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player"))
        {
            playersAndCrosshairPositions.Push(player.transform.position);
        }
        foreach (GameObject crosshair in GameObject.FindGameObjectsWithTag("Crosshair"))
        {
            playersAndCrosshairPositions.Push(crosshair.transform.position);
        }

        // Place the camera at the center of the rect that the outermost x/y coordinates of the
        // players and crosshairs create
        if (playersAndCrosshairPositions.Count != 0)
        {
            Vector2 curr = playersAndCrosshairPositions.Pop();
            float minX = curr.x;
            float maxX = minX;
            float minY = curr.y;
            float maxY = minY;
            while (playersAndCrosshairPositions.Count != 0)
            {
                curr = playersAndCrosshairPositions.Pop();
                minX = Mathf.Min(minX, curr.x);
                maxX = Mathf.Max(maxX, curr.x);
                minY = Mathf.Min(minY, curr.y);
                maxY = Mathf.Max(maxY, curr.y);
            }

            // Find the center of the rect and put the camera there
            transform.position = new Vector3((minX + maxX) / 2, (minY + maxY) / 2, transform.position.z);
        }
    }
}
