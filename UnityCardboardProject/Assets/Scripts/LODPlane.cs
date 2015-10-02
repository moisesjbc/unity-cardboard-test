using UnityEngine;
using System.Collections;

public class LODPlane : MonoBehaviour {
	private Texture2D[] textures;

	// Use this for initialization
	void Start () {
		Debug.Log ("LOD Plane created");
		
		GetComponent<Renderer>().material.shader = Shader.Find("Sprites/Default");

		textures = new Texture2D[3];
		for( int i = 0; i < textures.Length; i++) {
			textures[i] = Texture2D.whiteTexture;
		}

		StartCoroutine (LoadImage ("http://pixelkin.org/wp-content/uploads/2014/03/Metal-Gear-Solid-Color-Logo.jpg", 0));
		StartCoroutine (LoadImage ("https://upload.wikimedia.org/wikipedia/commons/7/7e/Metal_Gear_Solid_2_logo.png", 1));
		StartCoroutine (LoadImage ("https://upload.wikimedia.org/wikipedia/commons/c/c0/Metal_Gear_Solid_3_logo.png", 2));
	}
	
	// Update is called once per frame
	void Update () {
		float distance = 
			Vector3.Distance (transform.position, Camera.main.transform.position);
		
		if (distance < 9.0f) {
			GetComponent<Renderer>().material.mainTexture = textures[2];
		} else if (distance < 10.0f) {
			GetComponent<Renderer>().material.mainTexture = textures[1];
		} else {
			GetComponent<Renderer>().material.mainTexture = textures[0];
		}
	}

	private IEnumerator LoadImage( string url, int textureIndex ) {
		WWW www = new WWW( url );
		yield return www;
		textures[textureIndex] = www.texture;
	}
}
