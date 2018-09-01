using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GCSelecaoFase : MonoBehaviour {

    public GameObject painelSelecaoFase; //Desativa o painel ao apertar o botão salvar
    public GameObject painelSalvar;      //Ativa o painel ao apertar o botão salvar

    public void botaoSalvar() {
        painelSalvar.SetActive(true);
        painelSelecaoFase.SetActive(false);
    }

    public void botaoSelecionarFase() {
        var listaDeFases = FindObjectsOfType<Fase>(); //Recupera todos os objetos com o script Fase nessa Scene

        foreach (var fase in listaDeFases) {
            if (fase.faseSelecionada)           //Verifica se é a fase selecionada
                fase.abreFase();                //Abre a fase, caso esteja liberada
        }
    }

    public void botaoMenuPrincipal() {
        SceneManager.LoadScene("Main"); //Simples, viu? Vai dizer que não consegue?
    }
}
