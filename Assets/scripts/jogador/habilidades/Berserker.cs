using UnityEngine;
using System.Collections;
using System;

public class Berserker : IHabilidade {

    private Personagem1 personagem;

    public void executar() {
        if (podeUsar()) {
            var ataque = personagem.getStatus().getAtaque(); //Recupera o Ataque atual
            personagem.getStatus().setAtaque(ataque+5);      //Adiciona +5 ao ataque
            personagem.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 0.45f, 0.15f); //Adicionamos uma cor avermelhado ao sprite
            personagem.getStatus().usaMagia(getCustoHabilidade());
            personagem.Invoke("removeBerserker", 5f);
        }
    }

    public bool podeUsar() {
        return (personagem.getStatus().getMP() >= getCustoHabilidade());
    }

    public int getCustoHabilidade() {
        return 3;
    }

    public void setPersonagem(GameObject personagem) {
        this.personagem = personagem.GetComponent<Personagem1>();
    }

}
