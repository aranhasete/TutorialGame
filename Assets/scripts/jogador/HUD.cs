using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUD : MonoBehaviour {

    public Slider sliderHP;                            //Slider HP
    public Slider sliderMP;                            //Slider Magia
    public Image iconeHabilidade1;                     //Icone Habilidade 1
    public Image iconeHabilidade2;                     //Icone Habilidade 2
    public Image iconeHabilidade3;                     //Icone Habilidade 3
    private Status status;                             //Status do jogador
    private IHabilidade habilidade1;                   //Status do jogador
    private IHabilidade habilidade2;                   //Status do jogador
    private IHabilidade habilidade3;                   //Status do jogador
    private Color habilidadeDisponivel = Color.white;  //Icone na cor normal
    private Color habilidadeIndisponivel = Color.grey; //Icone meio transparente

    // Use this for initialization
    void Start () {
        //Busca os valores
        var personagem = GameObject.FindWithTag("Player").GetComponent<IPersonagem>();
        status = personagem.getStatus();
        habilidade1 = personagem.getHabilidade1();
        habilidade2 = personagem.getHabilidade2();
        habilidade3 = personagem.getHabilidade3();

        //Informa os valores nos slides
        sliderHP.maxValue = status.getHPMax(); //Define o valor máximo do Slider
        sliderMP.maxValue = status.getMPMax(); //Define o valor máximo do Slider
    }
	
	void Update () {
        //Atualiza Sliders
        sliderHP.value = status.getHP();
        sliderMP.value = status.getMP();

        //Atualizar Icones
        //Habilidade 1
        if (habilidade1.podeUsar())
            iconeHabilidade1.color = habilidadeDisponivel;
        else
            iconeHabilidade1.color = habilidadeIndisponivel;

        //Habilidade 2
        if (habilidade2.podeUsar())
            iconeHabilidade2.color = habilidadeDisponivel;
        else
            iconeHabilidade2.color = habilidadeIndisponivel;


        //Habilidade 3
        if (habilidade3.podeUsar())
            iconeHabilidade3.color = habilidadeDisponivel;
        else
            iconeHabilidade3.color = habilidadeIndisponivel;
    }
}
