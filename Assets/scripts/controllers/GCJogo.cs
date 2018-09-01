using UnityEngine;
using System.Collections;

public class GCJogo : MonoBehaviour {

    private GameStatus gameStatus;
    public string sceneLoading; //Scene para usar no Loading

	void Start () {
        gameStatus = new GameStatus();
        DontDestroyOnLoad(this.gameObject);

        if (FindObjectsOfType<GCJogo>().Length > 1)
            Destroy(gameObject);
	}

    public GameStatus getGameStatus() {
        return gameStatus;
    }

    public void novoJogo(string prefabPersonagem, Status statusJogador) {
        gameStatus.faseLiberada = 1;
        gameStatus.prefabPersonagem = prefabPersonagem;
        gameStatus.status = statusJogador;
    }

    public void carregarJogo(GameStatus gameStatus) {
        this.gameStatus = gameStatus;
    }
}
