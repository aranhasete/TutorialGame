using UnityEngine;
using System.Collections;
using System;

public class Invencibilidade : IHabilidade { 

    private Personagem1 personagem;

    public void executar() {
        if (podeUsar()) {
            personagem.invencibilidade = 5f;
            personagem.getStatus().usaMagia(getCustoHabilidade());
        }
    }

    public bool podeUsar() {
        return (personagem.getStatus().getMP() >= getCustoHabilidade());
    }

    public int getCustoHabilidade() {
        return 6;
    }

    public void setPersonagem(GameObject personagem) {
        this.personagem = personagem.GetComponent<Personagem1>();
    }
}
