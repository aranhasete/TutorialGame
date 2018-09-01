using UnityEngine;
using System.Collections;
using System;

public class AtaqueTriplo : IHabilidade {

    private Personagem2 personagem;

    public void executar() {
        if (podeUsar()) {
            personagem.animator.SetTrigger("atacou"); //Ativa animação

            //Cria as Kunais
            criaKunai(20f); //Rotação (X = 0, Y = 0, Z = 20)
            criaKunai(0f); //Rotação (X = 0, Y = 0, Z = 0)
            criaKunai(-20f); //Rotação (X = 0, Y = 0, Z = -20)

            personagem.atacando = true;               //Informa para o script que está atacando
            personagem.getStatus().usaMagia(getCustoHabilidade()); //Diminui o custo da magia no MP
        }
    }

    private void criaKunai(float grau) {
        var prefabKunai = Resources.Load("prefabs/jogador/Kunai") as GameObject;
        var objAtaque = GameObject.Instantiate(prefabKunai).GetComponent<AtaqueAndante>();      //Cria o objeto no cenário (Hierarchy)
        objAtaque.destroiObjeto(5f);                        //Destroi objeto em 5 Segundos

        objAtaque.direita = personagem.getDireita();        //Define a direção que o objeto vai andar
        if (personagem.getDireita())                        //Verifica de qual lado do personagem será criado
            objAtaque.transform.position = personagem.transform.position + Vector3.right;
        else
            objAtaque.transform.position = personagem.transform.position - Vector3.right;

        objAtaque.dano = personagem.getStatus().getAtaque(); //Define o dano que a Kunai causa

        //Inclinação
        objAtaque.transform.Rotate(0f, 0f, grau);
    }

    public int getCustoHabilidade() {
        return 2;
    }

    public bool podeUsar() {
        return (personagem.getStatus().getMP() >= getCustoHabilidade());
    }

    public void setPersonagem(GameObject personagem) {
        this.personagem = personagem.GetComponent<Personagem2>();
    }
}
