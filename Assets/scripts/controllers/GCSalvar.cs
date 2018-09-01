using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GCSalvar : MonoBehaviour {

    public GameObject painelSelecaoFase; //Ativa o painel ao apertar o botão voltar
    public GameObject painelSalvar;      //Desativa o painel ao apertar o botão salvar
    public Text textoInformativo;        //Informa o jogador o andamento do save
    
    void Start() {
        painelSalvar.SetActive(true);
        for (int slot = 1; slot <= 3; slot++) {
            BinaryFormatter bf = new BinaryFormatter();
            if (File.Exists(Application.persistentDataPath + "/save" + slot + ".dat")) {
                FileStream file = File.Open(Application.persistentDataPath + "/save" + slot + ".dat", FileMode.Open);
                var gameStatus = (GameStatus)bf.Deserialize(file);
                file.Close();

                var textoBotao = GameObject.Find("BotaoSlot" + slot).transform.GetChild(0).GetComponent<Text>();
                textoBotao.text = "Personagem: " + gameStatus.prefabPersonagem + " | Fases Liberadas: " + gameStatus.faseLiberada;
            }
        }
        painelSalvar.SetActive(false);
    }

	public void botaoSlot(int slot) {
        textoInformativo.text = "Salvando no Slot " + slot;

        //Salvando
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/save"+slot+".dat");
        var gameStatus = FindObjectOfType<GCJogo>().getGameStatus();
        bf.Serialize(file, gameStatus);
        file.Close();

        textoInformativo.text = "Jogo salvo no slot " + slot;

        var textoBotao = GameObject.Find("BotaoSlot" + slot).transform.GetChild(0).GetComponent<Text>();
        textoBotao.text = "Personagem: " + gameStatus.prefabPersonagem + " | Fases Liberadas: " + gameStatus.faseLiberada;
    }

    public void botaoVoltar() {
        painelSalvar.SetActive(false);
        painelSelecaoFase.SetActive(true);
    }
}
