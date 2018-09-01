using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class IniciarFase : MonoBehaviour {

    private IPersonagem personagem;

	// Use this for initialization
	void Awake () {
        var gameStatus = FindObjectOfType<GCJogo>().getGameStatus();
        var prefabPersonagem = Resources.Load("prefabs/jogador/" + gameStatus.prefabPersonagem);
        var obj = Instantiate(prefabPersonagem) as GameObject;
        personagem = obj.GetComponent<IPersonagem>();
	}
	
	public void voltarMenu() {
        SceneManager.LoadScene("Main");
    }

    public void recuperaVida() {
        personagem.getStatus().recuperaHP(999);
        personagem.getStatus().recuperaMagia(999);
    }

    public void sofreDano() {
        personagem.getStatus().sofrerDano(3);
    }



}
