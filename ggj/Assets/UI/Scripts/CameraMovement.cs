using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    public GameObject Camera;
    float speed1 = 0;
    float speed2 = 0;
    float speed3 = 0;
    public GameObject plane;
    bool check;
    int i = 0;
    
    

   

    // Use this for initialization
    void Start () {
       
    }

    // Update is called once per frame
    private void Update()
    {
        
    
          if ( Camera.transform.eulerAngles.x < 14.0f) {
            i = i + 1;
            plane.GetComponent<CanvasGroup>().alpha = plane.GetComponent<CanvasGroup>().alpha + 0.1f;
            if (i == 20 )
            {

           
            Camera.transform.eulerAngles = new  Vector3(15.0f,0.0f,0.0f);
            Camera.transform.position = new Vector3(0.0f,0.0f,-10.0f);
            
            speed1 = Random.Range(10.0f, 10.0f);
           
            speed2 = Random.Range(0.0f, 10.0f);
            
            speed3 = Random.Range(-1.0f, 1.0f);

             check = true;
                i = 0;
            }
        }
          if (check == true)
        {
            plane.GetComponent<CanvasGroup>().alpha = plane.GetComponent<CanvasGroup>().alpha - 0.1f;
            i = i + 1;
            if (i==20 )
            {
                check = false;
                i = 0;
            }
        }



        






        Camera.transform.RotateAround(Vector3.zero, Vector3.up, speed1 * Time.deltaTime);
        Camera.transform.RotateAround(Vector3.zero, Vector3.right, speed2 * Time.deltaTime);
        Camera.transform.RotateAround(Vector3.zero, Vector3.forward, speed3* Time.deltaTime);
     } 
    




    
   
}
