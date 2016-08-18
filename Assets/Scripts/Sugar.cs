using UnityEngine;
using System.Collections;

public class Sugar : MonoBehaviour {

	public Vector3 Direction;
	public float Speed;
    public GameObject ParticulaCafé;
    public GameObject ParticulaPrato;

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
                //starta gotas de café
                Vector3 posParCoffe = new Vector3(colisor.transform.position.x, colisor.transform.position.y + 1, colisor.transform.position.z);
                ParticulaCafé.transform.position = posParCoffe;
                ParticleSystem componenteParticulas = ParticulaCafé.GetComponent<ParticleSystem>();
                componenteParticulas.Play();
            }

		} else if (parede != null) {
			if (normal == Vector2.up) {
				colisãoInvalida = true;
			}
		} else {
			colisãoInvalida = false;
			Destroy( colisor.gameObject ); //destroy prato

            //starta particula do prato
            Vector3 posParPrato = new Vector3(colisor.transform.position.x + 1, colisor.transform.position.y, colisor.transform.position.z);
            ParticulaPrato.transform.position = posParPrato;
            ParticleSystem componenteParticulas = ParticulaPrato.GetComponent<ParticleSystem>();
            componenteParticulas.Play();
        }

		if ( !colisãoInvalida ) {
			Direction = Vector2.Reflect( Direction, normal );
			Direction.Normalize();
        } else {
			GerenciadorDoGame.loadLevel("Fase 1");
		}
	}
}
