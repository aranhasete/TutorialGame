using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;

public class GCMenuPrincipal : MonoBehaviour {

    public GameObject painelPrincipal;
    public GameObject painelConfiguracoes;
    public GameObject painelSelecaoPersonagem;
    public GameObject painelCarregar;
    public Image btVolume;
    public new GCCamera camera;
   
    void Awake() {
        if (!PlayerPrefs.HasKey("volume")) //Senão existir nenhuma informação já salva
            PlayerPrefs.SetInt("volume", 1); //Definimos o volume como ativo

        var volume = PlayerPrefs.GetInt("volume"); 
        var color = btVolume.color;
        if (volume == 1)
            color.a = 1f; //Alteramos o valor de alpha
        else
            color.a = 0.4f; //Alteramos o valor de alpha
        btVolume.color = color;
    }

    void Start() {
        painelCarregar.SetActive(true);
        var botaoCarregarAtivo = false;

        for (int slot = 1; slot <= 3; slot++) {
            BinaryFormatter bf = new BinaryFormatter();
            if (File.Exists(Application.persistentDataPath + "/save" + slot + ".dat")) {
                botaoCarregarAtivo = true;
                FileStream file = File.Open(Application.persistentDataPath + "/save" + slot + ".dat", FileMode.Open);
                var gameStatus = (GameStatus)bf.Deserialize(file);
                file.Close();

                var textoBotao = GameObject.Find("BotaoSlot" + slot).transform.GetChild(0).GetComponent<Text>();
                textoBotao.text = "Personagem: " + gameStatus.prefabPersonagem + " | Fases Liberadas: " + gameStatus.faseLiberada;
            }
        }
        painelCarregar.SetActive(false);

        if (botaoCarregarAtivo) {
            var botaoCarregar = GameObject.Find("CarregarJogo").GetComponent<Button>();
            botaoCarregar.interactable = botaoCarregarAtivo;
        }
    }


    //PainelPrincipal
    public void botaoNovoJogo() {
        painelPrincipal.SetActive(false);//Desativa o Painel Principal
        painelSelecaoPersonagem.SetActive(true); //Ativa o Painel de Seleção de Personagens
    }

    public void botaoCarregarJogo() {
        painelPrincipal.SetActive(false);//Desativa o Painel Principal
        painelCarregar.SetActive(true); //Ativa o Painel de Carregar
    }

    public void botaoCarregarSlot(int slot) {
        if (File.Exists(Application.persistentDataPath + "/save"+slot+".dat")) { //Existe um save
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/save" + slot + ".dat", FileMode.Open); //Abre arquivo
            var gameStatus = (GameStatus) bf.Deserialize(file);        //Transforma de binário para GameStatus
            file.Close();

            var GCJogo = FindObjectOfType<GCJogo>();
            GCJogo.carregarJogo(gameStatus);

            SceneManager.LoadScene("MenuFases");
        }
    }

    public void botaoConfiguracoes() {
        painelPrincipal.SetActive(false);//Desativa o Painel Principal
        painelConfiguracoes.SetActive(true); //Ativa o Painel de Configurações
    }

    public void botaoSair() {
        Application.Quit(); //Fecha o jogo
    }

    //PainelConfiguracoes
    public void botaoVolume() {
        var volume = PlayerPrefs.GetInt("volume");  //Recupera informação sobre o som
        var color = btVolume.color;                 //Recupera a cor do botão
        if (volume == 1) {
            PlayerPrefs.SetInt("volume", 0);    //Salva a informação do volume
            color.a = 0.4f;                     //Torna o botão mais transparente
            camera.desabilitarSom();            //Desabilita o som
        } else {
            PlayerPrefs.SetInt("volume", 1);    //Salva a informação do volume
            color.a = 1f;                       //Torna o botão 100% visivel
            camera.habilitarSom();              //Habilita o som
        }
        btVolume.color = color;
    }

    public void botaoVoltar() {
        painelPrincipal.SetActive(true);//Ativa o Painel Principal
        painelConfiguracoes.SetActive(false); //Desativa o Painel de Configurações
        painelSelecaoPersonagem.SetActive(false); //Desativa o Painel de Seleção de Personagens
        painelCarregar.SetActive(false); //Desativa o Painel de Carregar jogo
    }
}
