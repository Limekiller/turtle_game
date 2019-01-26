using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SelectBox : MonoBehaviour {
	
	private Rect boundbox;
 	private Vector3 start_box;
 	private Vector3 end_box;
	private Renderer rend;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		

		 if (Input.GetMouseButtonDown(0)) {
     		start_box = Input.mousePosition;
 		}

		 if(Input.GetMouseButtonUp(0)) {
     		end_box = Input.mousePosition;
 			makeBox();
 			GameObject[] csel = GameObject.FindGameObjectsWithTag("Selectable");
 			for (int i = 0; i < csel.Length; i++) {
                Vector3 objectlocation = Camera.main.WorldToScreenPoint(new Vector3(csel[i].transform.position.x,csel[i].transform.position.y,csel[i].transform.position.z));
                     
				rend = csel[i].GetComponent<Renderer>();
                //If the object falls inside the box set its state to selected so we can use it later
                if(boundbox.Contains(objectlocation)) {
					   rend.material.SetFloat("_Outline", 0.03f);
                } else {
					rend.material.SetFloat("_Outline", 0f);
				}
            }
			start_box = new Vector3();
			end_box = new Vector3();
 		}
 	}

	  private void makeBox() {
         //Ensures the bottom left and top right values are correct
         //regardless of how the user boxes units
         float xmin = Mathf.Min(start_box.x, end_box.x);
         float ymin = Mathf.Min(start_box.y, end_box.y);
         float width = Mathf.Max(start_box.x, end_box.x) - xmin;
         float height = Mathf.Max(start_box.y, end_box.y) - ymin;
         boundbox = new Rect(xmin, ymin, width, height);
     }

	 void OnGUI()
	{
    	if (start_box != new Vector3()) {
			var rect = Utils.GetScreenRect( start_box, Input.mousePosition );
            Utils.DrawScreenRect( rect, new Color( 0.8f, 0.8f, 0.95f, 0.25f ) );
            Utils.DrawScreenRectBorder( rect, 2, new Color( 0.8f, 0.8f, 0.95f ) );
		}
	}
	 
}
