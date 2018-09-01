using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BotaoSelecaoPersonagem : MonoBehaviour {

    public Sprite spriteSelecionado;    //Imagem do botão não selecionado
    public Sprite spriteNaoSelecionado; //Imagem do botão selecionado
    public bool selecionado;            //Verifica se esse botão está selecionado
    public IPersonagem personagem;      //Pega os dados do personagem do botão             

	void Start () {
        personagem = GetComponentInChildren<IPersonagem>(); //Recupera os dados do personagem do botão

        //Gera a Imagem do personagem no SpritePersonagem
        var spritePersonagem = transform.GetChild(0).GetComponent<Image>(); //Recupera o Script Image do primeiro filho
        spritePersonagem.sprite = personagem.getSprite();                   //Insere o sprite do personagem

        //Status
        //HP
        var sliderHP = transform.GetChild(1).GetComponentInChildren<Slider>();
        sliderHP.value = personagem.getStatus().getHPMax();

        //MP
        var sliderMP = transform.GetChild(2).GetComponentInChildren<Slider>();
        sliderMP.value = personagem.getStatus().getMPMax();

        //Ataque
        var sliderAtaque = transform.GetChild(3).GetComponentInChildren<Slider>();
        sliderAtaque.value = personagem.getStatus().getAtaque();
    }
	
	public void ativarBotao() {
        selecionado = true;
        GetComponent<Image>().sprite = spriteSelecionado;

        var botaoSelecionar = GameObject.Find("BotaoSelecionarPersonagem").GetComponent<Button>();
        botaoSelecionar.interactable = true;
    }

    public void desativarBotao() {
        selecionado = false;
        GetComponent<Image>().sprite = spriteNaoSelecionado;
    }

    public void clicou() {
        var listaBotoes = FindObjectsOfType<BotaoSelecaoPersonagem>();
        foreach (var botao in listaBotoes) {
            botao.desativarBotao();
        }
        ativarBotao();
    }
}

