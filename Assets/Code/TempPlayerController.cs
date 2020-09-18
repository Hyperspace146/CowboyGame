using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempPlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position += new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime * 4, 0, 0);
        this.gameObject.transform.position += new Vector3(0, Input.GetAxis("Vertical") * Time.deltaTime * 4, 0);
    }
}
