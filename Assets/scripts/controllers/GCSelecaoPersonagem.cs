using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GCSelecaoPersonagem : MonoBehaviour {

    public void novoJogo() {
        var listaBotoes = FindObjectsOfType<BotaoSelecaoPersonagem>();
        var GCJogo = FindObjectOfType<GCJogo>();

        foreach (var botao in listaBotoes) {
            if (botao.selecionado == true) {
                var status = botao.personagem.getStatus();
                var prefabPersonagem = botao.personagem.getNomePrefab();
                GCJogo.novoJogo(prefabPersonagem, status);
                break;
            }
        }
        SceneManager.LoadScene("MenuFases"); //ou SceneManager.LoadScene(1);
    }
}
