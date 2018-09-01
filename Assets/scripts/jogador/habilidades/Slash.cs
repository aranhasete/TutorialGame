using UnityEngine;
using System.Collections;
using System;

public class Slash : IHabilidade {

    public Personagem1 personagem;

    public void executar() {
        if (podeUsar()) { 
            var prefabSlash = Resources.Load("prefabs/jogador/Slash") as GameObject;
            personagem.animator.SetTrigger("atacou");
            var objSlash = GameObject.Instantiate(prefabSlash).GetComponent<AtaqueAndante>();
            objSlash.destroiObjeto(3f); //Destroi após 3 Segundos
            objSlash.direita = personagem.getDireita(); //Arrumar

            if (objSlash.direita)
                objSlash.transform.position = personagem.transform.position + (Vector3.right);
            else
                objSlash.transform.position = personagem.transform.position - (Vector3.right);

            personagem.atacando = true;

            personagem.getStatus().usaMagia(getCustoHabilidade());
        }
    }

    public bool podeUsar() {
        return (personagem.getStatus().getMP() >= getCustoHabilidade());
    }

    public int getCustoHabilidade() {
        return 2;
    }

    public void setPersonagem(GameObject personagem) {
        this.personagem = personagem.GetComponent<Personagem1>();
    }
}
