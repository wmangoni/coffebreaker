using UnityEngine;
using System.Collections;

public class Sugar : MonoBehaviour {

	public Vector3 Direction;
	public float Speed;
    public GameObject ParticulaCafé;

	// Use this for initialization
	void Start () {
		Direction.Normalize(); // equivalente a fazer a Direção = Direção.normalized;
	}
	
	// Update is called once per frame
	void Update () {

		transform.position += Direction * Speed * Time.deltaTime;
	
	}

	void OnCollisionEnter2D( Collision2D colisor ) {

		bool colisãoInvalida = false;
		Vector2 normal = colisor.contacts[0].normal;
		Xicara xicara = colisor.transform.GetComponent<Xicara>();
		Parede parede = colisor.transform.GetComponent<Parede>();

		if (xicara != null) { // Se existir o componente Xicara no gameObject com o qual o açúcar colidiu.

            if (normal != Vector2.up) {
				//colisãoInvalida = true;
			} else {
                GameObject particulas = (GameObject) Instantiate(ParticulaCafé, colisor.transform.position, Quaternion.identity);
                ParticleSystem componenteParticulas = particulas.GetComponent<ParticleSystem>();
                Destroy(particulas, componenteParticulas.duration + componenteParticulas.startLifetime);
            }

		} else if (parede != null) {
			if (normal == Vector2.up) {
				colisãoInvalida = true;
			}
		} else {
			colisãoInvalida = false;
			Destroy( colisor.gameObject );
		}

		if ( !colisãoInvalida ) {
			Direction = Vector2.Reflect( Direction, normal );
			Direction.Normalize();
		} else {
			GerenciadorDoGame.loadLevel("Fase 1");
		}
	}
}
