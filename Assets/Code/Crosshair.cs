using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

//Script to keep the crosshair at the same location as the mouse
public class Crosshair : MonoBehaviour
{    
    public Rigidbody2D rb;
    public Camera cam;
    public Transform ShootPoint;

    private PlayerInputHandler input;

    void Start()
    {
        cam = Camera.main;
        input = GetComponentInParent<PlayerInputHandler>();
    }
    
    void FixedUpdate()
    {
        // range represents the range around the camera which the crosshair is allowed to navigate
        int Xrange = 10; 
        int Yrange = 10;

        float minY = cam.transform.position.y - Yrange;
        float maxY = cam.transform.position.y + Yrange;
        float minX = cam.transform.position.x - Xrange;
        float maxX = cam.transform.position.x + Xrange;

        Vector2 pos = cam.ScreenToWorldPoint(input.LookInput + (Vector2) ShootPoint.transform.position);

        // Limit the crosshair's movement based on the camera's position
        //float xPos = Mathf.Clamp(transform.position.x + pos.x, minX, maxX);
        //float yPos = Mathf.Clamp(transform.position.y + pos.y, minY, maxY);
        float xPos = Mathf.Clamp(pos.x, minX, maxX);
        float yPos = Mathf.Clamp(pos.y, minY, maxY);
        transform.position = new Vector3(xPos, yPos, 19);
    }
}
