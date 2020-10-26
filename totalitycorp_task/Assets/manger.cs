using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class manger : MonoBehaviour
{
    // FOR TESTING

    public Camera cam;
    public GameObject target;
    public float speed =2 ;

    private int fingerCount;

    private Vector3 firstpoint; 
    private Vector3 secondpoint;


    private Vector3 previouspos;
   

    void Start()
    {


        fingerCount = 0;


       // //Initialization our angles of camera
       // xAngle = 0f;
       // yAngle = 0f;
       //// this.transform.rotation = Quaternion.Euler(yAngle, xAngle, 0f);

    }


    //
    // UPDATE
    //

    void Update()
    {
        
        // TOUCH RECOGNITION
        fingerCount = 0;

        foreach (Touch touch in Input.touches)
        {
            if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
            {
                fingerCount++;
            }
        }


        if (fingerCount == 1)
        {

            //Touch Start
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                firstpoint = Input.GetTouch(0).position;
                previouspos = cam.ScreenToViewportPoint(Input.GetTouch(0).position);

            }

            //Move finger by screen
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                secondpoint = Input.GetTouch(0).position;

                //Mainly, about rotate camera. For example, for Screen.width rotate on 180 degree
                //xAngle = xAngTemp + (secondpoint.x - firstpoint.x)  * turnSpeed / Screen.width;
                //yAngle = yAngTemp - (secondpoint.y - firstpoint.y)  * turnSpeed / Screen.height;

                //  Vector3 rot = new Vector3(yAngle, xAngle, 0f);
                //Rotate camera




                //  cam.transform.RotateAround(target.transform.position, Vector3.up, 20 * Time.deltaTime);

                //cam.transform.rotation = Quaternion.Euler(yAngle, xAngle, 0f) * Quaternion.AngleAxis(30, Vector3.up);
                //How long to take to reset. private Vector3 startDirection = Vector3. zero;


                Vector3 dir = previouspos - cam.ScreenToViewportPoint(Input.GetTouch(0).position);

                Vector3 a = new Vector3(target.transform.position.x, 1.05f, target.transform.position.z);
                
                cam.transform.position =a ;

                cam.transform.Rotate(new Vector3(1 , 0, 0) , dir.y * speed * Time.deltaTime);
                cam.transform.Rotate(new Vector3(0, 1, 0)  , dir.x *speed * Time.deltaTime, Space.World);
                cam.transform.Translate(new Vector3(0, 0, -10f));

            }
        }


        if (fingerCount == 2)
        {
            //PAN/Zoom
        }
    }
}
