using UnityEngine;
using System.Collections;
//using UnityEngine.SceneManagement;

public class GerenciadorDoGame : MonoBehaviour {

	public static void loadLevel (string scena) {
		Application.LoadLevel(scena);
		//SceneManager.LoadScene(scena);
	}
}
