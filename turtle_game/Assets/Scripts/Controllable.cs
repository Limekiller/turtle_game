using UnityEngine;

public class Controllable  : MonoBehaviour
{
    public GameObject m_Cube;


    public float m_DistanceY;

    public Plane m_Plane;
    Vector3 m_DistanceFromCamera;

	private Renderer rend;


    void Start()
    {
        m_DistanceFromCamera = new Vector3(Camera.main.transform.position.x, 0, Camera.main.transform.position.z);

        m_Plane = new Plane(Vector3.up, m_DistanceFromCamera);
    }

    void Update()
    {
        if (Input.GetMouseButton(1)) {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            float enter = 0.0f;
			GameObject[] csel = GameObject.FindGameObjectsWithTag("Selectable");
			Debug.Log(csel.Length);
            if (m_Plane.Raycast(ray, out enter)) {
                Vector3 hitPoint = ray.GetPoint(enter);
                // m_Cube.transform.position = hitPoint;

				foreach (GameObject turtle in csel) {
					rend = turtle.GetComponent<Renderer>();
					if (rend.material.GetFloat("_Outline") > 0f && turtle.GetComponent<Moving>().isMoving == false) {
						turtle.transform.LookAt(hitPoint);
						turtle.GetComponent<Moving>().isMoving = true;
						turtle.GetComponent<Moving>().destinationPoint = hitPoint;
						Debug.Log("attempted to move " + turtle);
					}

					else if (rend.material.GetFloat("_Outline") > 0f && turtle.GetComponent<Moving>().isMoving == true) {
						turtle.transform.LookAt(hitPoint);
						turtle.GetComponent<Moving>().destinationPoint = hitPoint;
					}
				}
            }
        }
		foreach (GameObject turtle in GameObject.FindGameObjectsWithTag("Selectable")) {
			if (turtle.GetComponent<Moving>().isMoving == true) {
				if (turtle.transform.position != turtle.GetComponent<Moving>().destinationPoint) {
					turtle.transform.position = Vector3.MoveTowards(turtle.transform.position, turtle.GetComponent<Moving>().destinationPoint, 0.05f);
				} else {
					turtle.GetComponent<Moving>().isMoving = false;
				}
			}
		}
    }

	void moveTheDeal(GameObject turtle, Vector3 theDeal, Vector3 hitPoint, float mDD) {
		turtle.GetComponent<Moving>().isMoving = true;
		turtle.transform.LookAt(hitPoint);
		while(turtle.transform.position != hitPoint) {
			turtle.transform.position = Vector3.MoveTowards(turtle.transform.position, hitPoint, 0.05f);
		}
		turtle.GetComponent<Moving>().isMoving = false;
	}
}