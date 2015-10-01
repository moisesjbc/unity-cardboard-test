using UnityEngine;
using System.Collections;

public class LODPlane : MonoBehaviour {

	// Use this for initialization
	IEnumerator Start () {
		Debug.Log ("LOD Plane created");
		
		WWW www0 = new WWW( "http://pixelkin.org/wp-content/uploads/2014/03/Metal-Gear-Solid-Color-Logo.jpg" );
		yield return www0;

		Renderer renderer = GetComponent<Renderer>();
		renderer.material.mainTexture = www0.texture;
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
