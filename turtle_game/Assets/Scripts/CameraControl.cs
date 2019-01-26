using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	public float ScrollSpeed = 50;
    private Camera camera;
    public float cameraSize;
    public float newCameraSize;
    public Vector3 currentPos;
    public Vector3 newPos;

	// Use this for initialization
	void Start () {
		camera = GetComponent<Camera>();
        cameraSize = camera.orthographicSize;
        newCameraSize = camera.orthographicSize;

        currentPos = transform.position;
        newPos = currentPos;
	}
	
	// Update is called once per frame
	void Update () {

        // Camera zoom
        if (Input.GetAxis("Mouse ScrollWheel") > 0f) {
            if (camera.orthographicSize > 1){  
                newCameraSize--;
            }
        }  else if (Input.GetAxis("Mouse ScrollWheel") < 0f) {
            if (camera.orthographicSize < 10) {
                newCameraSize++;
            }
        }
        if (cameraSize < newCameraSize - 0.05f || cameraSize > newCameraSize + 0.05f) {
            cameraSize = Mathf.Lerp(Mathf.Clamp(cameraSize, 1, 10), newCameraSize, 0.1f);
            camera.orthographicSize = cameraSize;
        }

        if (currentPos != newPos) {
            currentPos = Vector3.Lerp(currentPos, newPos, 0.05f);
            transform.position = currentPos;
        }
		if ( Input.mousePosition.x >= Screen.width *0.95)
         {
             //transform.Translate(Vector3.right * Time.deltaTime * ScrollSpeed);
             newPos += transform.right * 5 * Time.deltaTime;
         }

		if ( Input.mousePosition.x <= Screen.width * 0.05)
         {
             //transform.Translate(-Vector3.right * Time.deltaTime * ScrollSpeed);
            newPos += -transform.right * 5 *Time.deltaTime;

         }

		if ( Input.mousePosition.y >= Screen.height *0.95)
         {
            //transform.Translate(Vector3.up * Time.deltaTime * ScrollSpeed);
            newPos += transform.up * 5 * Time.deltaTime;

         }

		if ( Input.mousePosition.y <= Screen.height *0.05)
         {
             //transform.Translate(-Vector3.up * Time.deltaTime * ScrollSpeed);
            newPos += -transform.up * 5 * Time.deltaTime;

         } 
	}
}
