using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendCollisionMessageUpwards : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("child collision");
        SendMessageUpwards("ChildOnCollisionEnter2D", collision, SendMessageOptions.RequireReceiver);
    }
}
