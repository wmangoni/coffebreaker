using UnityEngine;
using System.Collections;

public class Xicara : MonoBehaviour {

	public float velocidadeXicara;
	public float limitX;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float directionMouse = Input.GetAxis("Mouse X"); // -1 = esquerdo; 0 parado; 1 = direita
		GetComponent<Transform>().position += Vector3.right * directionMouse * velocidadeXicara * Time.deltaTime;
		float xAtual = transform.position.x;
		xAtual = Mathf.Clamp(xAtual, -limitX, limitX);
		transform.position = new Vector3 (xAtual, transform.position.y, transform.position.z);
	}
}
