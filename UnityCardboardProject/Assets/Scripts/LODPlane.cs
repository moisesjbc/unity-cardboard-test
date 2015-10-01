using UnityEngine;
using System.Collections;

public class LODPlane : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log ("LOD Plane created");
	}
	
	// Update is called once per frame
	void Update () {
		Renderer renderer = GetComponent<Renderer>();

		if (Vector3.Distance (transform.position, Camera.main.transform.position) < 10.0f) {
			renderer.material.color = Color.red;
		} else {
			renderer.material.color = Color.blue;
		}
	}
}
