using UnityEngine;
using System.Collections;

public class Parede : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Camera cam = Camera.main;
		EdgeCollider2D colisor = GetComponent<EdgeCollider2D>();
		Vector2 cantoInferiorEsq = cam.ScreenToWorldPoint ( new Vector3( 0, 0, 0 ) );
		Vector2 cantoSuperiorEsq = cam.ScreenToWorldPoint ( new Vector3( 0, Screen.height, 0 ) );
		Vector2 cantoSuperiorDir = cam.ScreenToWorldPoint ( new Vector3( Screen.width, Screen.height, 0 ) );
		Vector2 cantoInferiorDir = cam.ScreenToWorldPoint ( new Vector3( Screen.width, 0, 0 ) );
		colisor.points = new Vector2[5] {cantoInferiorEsq, cantoSuperiorEsq, cantoSuperiorDir, cantoInferiorDir, cantoInferiorEsq};
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
