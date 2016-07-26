using UnityEngine;
using System.Collections;

public class Sugar : MonoBehaviour {

	public Vector3 Direction;
	public float Speed;

	// Use this for initialization
	void Start () {
		Direction.Normalize(); // equivalente a fazer a Direção = Direção.normalized;
	}
	
	// Update is called once per frame
	void Update () {

		transform.position += Direction * Speed * Time.deltaTime;
	
	}

	void OnCollisionEnter2D( Collision2D colisor ) {

		Vector2 normal = colisor.contacts[0].normal;
		Direction = Vector2.Reflect( Direction, normal );
		Direction.Normalize();

	}
}
