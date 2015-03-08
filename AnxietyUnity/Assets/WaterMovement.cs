using UnityEngine;
using System.Collections;

public class WaterMovement : MonoBehaviour {
	public float minHeight = 0.0f;
	public float maxHeight = 2.0f;
	public float speed = 1.0f;

	public bool goingUp;

	// Use this for initialization
	void Start () {
		goingUp = true;
	}
	
	// Update is called once per frame
	void Update () {

		if (goingUp) {
			transform.Translate (Vector3.up * speed);
		} else {
			transform.Translate(Vector3.up * -speed);
		}

		if (transform.position.y > maxHeight) {
			goingUp = false;
		} else if (transform.position.y < minHeight) {
			goingUp = true;
		}
	}

}
