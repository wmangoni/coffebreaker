using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//using UnityEngine.SceneManagement;

public class GerenciadorDoGame : MonoBehaviour {
    public static int numeroTotalDeBlocos;
    public static int numeroDeBlocosDestruidos;
    public Image estrelas;
    public GameObject meuCanvas;
    public static GerenciadorDoGame instance;
    public Sugar sugar;
    public Xicara xicara;

    void Awake ()
    {
        instance = this;
    }

    void Start ()
    {
        meuCanvas.SetActive(false);
        numeroDeBlocosDestruidos = 0;
    }

    void Update ()
    {
        if (numeroDeBlocosDestruidos == numeroTotalDeBlocos)
        {
            GerenciadorDoGame.instance.FinalizaGame();
        }
    }

	public void loadLevel (string scena)
    {
		Application.LoadLevel(scena);
	}

    public void FinalizaGame()
    {
        estrelas.fillAmount = (float)numeroDeBlocosDestruidos / (float)numeroTotalDeBlocos;
        meuCanvas.SetActive(true);
        xicara.enabled = false;
        Destroy(sugar.gameObject);
    }
}
