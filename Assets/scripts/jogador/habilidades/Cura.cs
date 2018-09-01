using UnityEngine;
using System.Collections;
using System;

public class Cura : IHabilidade {

    private Personagem2 personagem;

    public void executar() {
        if (podeUsar()) {
            var prefabParticulas = Resources.Load("prefabs/jogador/CuraParticulas"); //O mesmo nome e pasta onde está o prefab
            var particulas = GameObject.Instantiate(prefabParticulas) as GameObject; //Cria o objeto na scene
            particulas.transform.position = personagem.transform.position; //Faz as particulas surgirem onde o personagem está
            particulas.transform.parent = personagem.transform; //Faz as particulas seguirem o personagem, quando ele anda
            GameObject.Destroy(particulas, 2f);                 //Destroi as particulas em 2 segundos

            personagem.getStatus().recuperaHP(5); //Recupera 5HP
            personagem.getStatus().usaMagia(getCustoHabilidade());
        }
    }

    public int getCustoHabilidade() {
        return 6;
    }

    public bool podeUsar() {
        return (personagem.getStatus().getMP() >= getCustoHabilidade());
    }

    public void setPersonagem(GameObject personagem) {
        this.personagem = personagem.GetComponent<Personagem2>();
    }
}
