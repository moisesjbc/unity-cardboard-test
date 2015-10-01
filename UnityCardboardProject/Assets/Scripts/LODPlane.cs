using UnityEngine;
using System.Collections;

public class LODPlane : MonoBehaviour {

	private WWW www0;
	private WWW www1;
	private WWW www2;

	// Use this for initialization
	IEnumerator Start () {
		Debug.Log ("LOD Plane created");

		www0 = new WWW( "http://pixelkin.org/wp-content/uploads/2014/03/Metal-Gear-Solid-Color-Logo.jpg" );
		www1 = new WWW( "https://upload.wikimedia.org/wikipedia/commons/7/7e/Metal_Gear_Solid_2_logo.png" );
		www2 = new WWW( "https://upload.wikimedia.org/wikipedia/commons/c/c0/Metal_Gear_Solid_3_logo.png" );

		// Wait for download to complete
		yield return www0;
		yield return www1;
		yield return www2;

		yield return null;
	}
	
	// Update is called once per frame
	void Update () {
		Renderer renderer = GetComponent<Renderer>();
		renderer.material.shader = Shader.Find("Sprites/Default");

		float distance = Vector3.Distance (transform.position, Camera.main.transform.position);

		if (distance < 9.0f) {
			if( www2.isDone ){
				renderer.material.mainTexture = www2.texture;
			}
		} else if (distance < 10.0f) {
			if( www1.isDone ){
				renderer.material.mainTexture = www1.texture;
			}
		} else {
			if( www0.isDone ){
				renderer.material.mainTexture = www0.texture;
			}
		}
	}
}
