using UnityEngine;
using System.Collections;
using System;

public class PuloDuplo : IHabilidade {

    private Personagem2 personagem;

    public void executar() {
        if (podeUsar()) {
            personagem.GetComponent<Rigidbody2D>().AddForce(Vector3.up * personagem.forcaPulo); //Aplica o pulo
            personagem.animator.SetTrigger("voou");                 //Ativa animação
            personagem.getStatus().usaMagia(getCustoHabilidade());  //Reduz o custo da magia
        }
    }

    public int getCustoHabilidade() {
        return 3;
    }

    public bool podeUsar() {
        return (personagem.getStatus().getMP() >= getCustoHabilidade() && !personagem.getEstaNoChao());
    }

    public void setPersonagem(GameObject personagem) {
        this.personagem = personagem.GetComponent<Personagem2>();
    }
}
