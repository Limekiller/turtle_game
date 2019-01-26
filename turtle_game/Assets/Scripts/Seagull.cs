using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seagull : MonoBehaviour {

	private Vector3 dest;
	private float moveSpeed = 0.05f;
	private float yPos = 8.981354f;
	public GameObject Projector;
	private GameObject InstProjector;

	// Use this for initialization
	void Start () {
		findDest();
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.MoveTowards(transform.position, dest, moveSpeed);

		Vector3 direction = dest - transform.position;
		Quaternion newRot = Quaternion.LookRotation(direction);
		transform.rotation = Quaternion.Lerp(transform.rotation, newRot, moveSpeed);

		if (transform.position == dest) {
			findDest();
		}

		if (Random.Range(0, 50000) == 10) {
			divebomb();
		}
	}

	void findDest() {
		if (moveSpeed != 0.05) {
			moveSpeed = 0.05f;
			Destroy(InstProjector);
		}
		dest = new Vector3(Random.Range(-20, 20), yPos, Random.Range(-20, 20));
	}

	void divebomb(){
		GameObject[] csel = GameObject.FindGameObjectsWithTag("Selectable");
		GameObject dbTarget = csel[Random.Range(0, csel.Length)];
		moveSpeed = 0.075f;
		dest = dbTarget.transform.position;
		InstProjector = Instantiate(Projector, new Vector3(dest.x, dest.y+3, dest.z), Projector.transform.rotation);
	}
}
