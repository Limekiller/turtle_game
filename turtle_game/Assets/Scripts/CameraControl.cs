using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	public float ScrollSpeed = 50;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if ( Input.mousePosition.x >= Screen.width *0.95)
         {
             transform.Translate(Vector3.right * Time.deltaTime * ScrollSpeed);
         }

		if ( Input.mousePosition.x <= Screen.width *0.05)
         {
             transform.Translate(-Vector3.right * Time.deltaTime * ScrollSpeed);

         }

		if ( Input.mousePosition.y >= Screen.height *0.95)
         {
             transform.Translate(Vector3.up * Time.deltaTime * ScrollSpeed);
         }

		if ( Input.mousePosition.y <= Screen.height *0.05)
         {
             transform.Translate(-Vector3.up * Time.deltaTime * ScrollSpeed);
         } 
	}

}
