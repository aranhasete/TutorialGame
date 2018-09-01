using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Fase : MonoBehaviour {

    public GameObject faseCima;         //A fase que o personagem vai ao apertar para cima
    public GameObject faseBaixo;        //A fase que o personagem vai ao apertar para baixo
    public GameObject faseEsquerda;     //A fase que o personagem vai ao apertar para esquera
    public GameObject faseDireita;      //A fase que o personagem vai ao apertar para direita

    public int nivel;                   //O nível da fase
    private bool faseLiberada;          //Verifica se o jogador já liberou essa fase
    public bool faseSelecionada;        //Se o jogador está nesta fase
    public string scene;                //Nome da Scene/Fase que será carregada

    public Sprite spriteLiberada;       //Sprite da Fase Liberada
    public Sprite spriteBloqueada;       //Sprite da fase bloqueada;

    void Start () {
        var gameStatus = FindObjectOfType<GCJogo>().getGameStatus();
        faseLiberada = (nivel <= gameStatus.faseLiberada);

        if (faseLiberada)
            GetComponent<Image>().sprite = spriteLiberada;
        else
            GetComponent<Image>().sprite = spriteBloqueada;
    }

    void OnTriggerEnter2D(Collider2D colisor) {
        if (colisor.name.Equals("Personagem"))
            faseSelecionada = true;
    }

    void OnTriggerExit2D(Collider2D colisor) {
        if (colisor.name.Equals("Personagem"))
            faseSelecionada = false;
    }

    void OnTriggerStay2D(Collider2D colisor) {
        if (colisor.name.Equals("Personagem")) {

            //Move
            var scriptPersonagem = colisor.GetComponent<PersonagemSelecaoFase>();
            if (Input.GetAxisRaw("Horizontal") > 0 && faseDireita != null) //Jogador apertou para Direita e faseDireita não é nula
                scriptPersonagem.destino = faseDireita.transform.position;
            if (Input.GetAxisRaw("Horizontal") < 0 && faseEsquerda != null) //Jogador apertou para Esquerda e faseEsquerda não é nula
                scriptPersonagem.destino = faseEsquerda.transform.position;
            if (Input.GetAxisRaw("Vertical") > 0 && faseCima != null) //Jogador apertou para Cima e faseCima não é nula
                scriptPersonagem.destino = faseCima.transform.position;
            if (Input.GetAxisRaw("Vertical") < 0 && faseBaixo != null) //Jogador apertou para Baixo e faseBaixo não é nula
                scriptPersonagem.destino = faseBaixo.transform.position;

            if (Input.GetButtonDown("Submit"))  //Jogador apertou Enter
                abreFase(); 
        }
    }

    public void  abreFase() {
        if (faseLiberada) {
            var GCJogo = FindObjectOfType<GCJogo>();
            GCJogo.sceneLoading = scene;
            SceneManager.LoadScene("Loading");
        }       
    }
}
