using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    // Start is called before the first frame update
     public float panSpeed = 20f;
    public float panBorderThickness = 10f;
    public float scrollSpeed = 2f;
    public Vector2 panLimit;
    public float zoomLimit = 20f;
    float scroll;
    float defaultHeight;

    
    // Start is called before the first frame update
    void Start()
    {
      defaultHeight = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
       
        if(Input.GetAxis("Mouse ScrollWheel")<0f)
        {
             if(this.GetComponent<Camera>().orthographicSize>20)
                this.GetComponent<Camera>().orthographicSize=20;
            this.GetComponent<Camera>().orthographicSize+=0.5f;
        }
            if(Input.GetAxis("Mouse ScrollWheel")>0f)
        {
            if(this.GetComponent<Camera>().orthographicSize<3)
                this.GetComponent<Camera>().orthographicSize=3;
            this.GetComponent<Camera>().orthographicSize-=0.5f;
        }

        Vector3 pos = transform.position;
        if (Input.GetKey("w"))
        {
            pos.z += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("s"))
        {
            pos.z -= panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("d"))
        {
            pos.x += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("a"))
        {
            pos.x -= panSpeed * Time.deltaTime;
        }

        pos.x = Mathf.Clamp(pos.x,  -panLimit.x, panLimit.x);
        pos.z = Mathf.Clamp(pos.z,  -panLimit.y,  panLimit.y);
        

        transform.position = pos;
        
    }
}
