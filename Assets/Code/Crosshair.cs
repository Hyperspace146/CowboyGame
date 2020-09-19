using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script to keep the crosshair at the same location as the mouse
public class Crosshair : MonoBehaviour {
    
    //private PlayerInputHandler inputHandler;
    public Rigidbody2D rb;
    public Camera cam;
    
    //public float moveSpeed;

    //***IMPORTANT NOTE: because this script relies on the PlayerInputHandler script,
    //then we need our crosshair object in unity to also be assigned the 
    //PlayerInputHandler script. The camera must also be given to that PlayerInputHandler script
    //from within Unity. If these two things don't happen, there will be errors
    private PlayerInputHandler inputHandler;

    void Start() {

        //store the player's playerinputhandler script here
        //so that we have access to its methods
        inputHandler = GetComponent<PlayerInputHandler>();

    }

    public Vector2 GetCrosshairPos() {
        return rb.position;
    }

    // Update is called once per frame
    void FixedUpdate() {
        //limit the crosshair's movement based on the camera's position

        int Xrange = 20; //range represents the range around the camera which the crosshair is allowed to navigate
        int Yrange = 20;

        float minY = cam.transform.position.y - Yrange;
        float maxY = cam.transform.position.y + Yrange;
        float minX = cam.transform.position.x - Xrange;
        float maxX = cam.transform.position.x + Xrange;

        Vector2 pos = cam.ScreenToWorldPoint(inputHandler.GetLookInput());


        //float xPos = Mathf.Clamp(transform.position.x + pos.x, minX, maxX);
        //float yPos = Mathf.Clamp(transform.position.y + pos.y, minY, maxY);
        float xPos = Mathf.Clamp(pos.x, minX, maxX);
        float yPos = Mathf.Clamp(pos.y, minY, maxY);
        transform.position = new Vector2(xPos, yPos);
        //Debug.Log("In-game coordinates: " + xPos + ", " + yPos + " " + transform.position.z);
        
        
    }

    
}
