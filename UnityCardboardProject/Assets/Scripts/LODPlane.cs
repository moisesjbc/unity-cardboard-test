using UnityEngine;
using System.Collections;

public class LODPlane : MonoBehaviour {

	private WWW www0;
	private WWW www1;
	private WWW www2;

	private Renderer renderer;

	// Use this for initialization
	void Start () {
		Debug.Log ("LOD Plane created");

		www0 = new WWW( "http://pixelkin.org/wp-content/uploads/2014/03/Metal-Gear-Solid-Color-Logo.jpg" );
		www1 = new WWW( "https://upload.wikimedia.org/wikipedia/commons/7/7e/Metal_Gear_Solid_2_logo.png" );
		www2 = new WWW( "https://upload.wikimedia.org/wikipedia/commons/c/c0/Metal_Gear_Solid_3_logo.png" );

		renderer = GetComponent<Renderer>();
		renderer.material.shader = Shader.Find("Sprites/Default");
	}
	
	// Update is called once per frame
	void Update () {
		float distance = Vector3.Distance (transform.position, Camera.main.transform.position);

		if (distance < 9.0f) {
			if( www2.isDone ){
				renderer.material.mainTexture = www2.texture;
			}else{
				renderer.material.mainTexture = Texture2D.whiteTexture;
			}
		} else if (distance < 10.0f) {
			if( www1.isDone ){
				renderer.material.mainTexture = www1.texture;
			}else{
				renderer.material.mainTexture = Texture2D.whiteTexture;
			}
		} else {
			if( www0.isDone ){
				renderer.material.mainTexture = www0.texture;
			}else{
				renderer.material.mainTexture = Texture2D.whiteTexture;
			}
		}
	}
}
