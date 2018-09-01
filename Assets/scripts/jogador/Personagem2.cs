using UnityEngine;
using System.Collections;
using System;

public class Personagem2 : Jogador { 

    public AtaqueAndante kunai;

    protected override void Awake() {
        base.Awake();
        status = new Status(10, 12, 5); //HP 10 | MP 12 | Ataque 5

        habilidade1 = new AtaqueTriplo();
        habilidade2 = new PuloDuplo();
        habilidade3 = new Cura();

        habilidade1.setPersonagem(this.gameObject);
        habilidade2.setPersonagem(this.gameObject);
        habilidade3.setPersonagem(this.gameObject);
    }

    protected override void mover() {
        base.mover();

        if (Input.GetButtonDown("Habilidade2"))
            habilidade2.executar();
    }

    protected override void atacar() {
        if (!atacando) {

            //Ataque comum
            if (Input.GetButtonDown("Ataque")) {    //Apertou o botão de ataque
                animator.SetTrigger("atacou");      //Ativa animação
                var objAtaque = Instantiate(kunai); //Cria o objeto no cenário (Hierarchy)
                objAtaque.destroiObjeto(5f);        //Destroi objeto em 5 Segundos

                objAtaque.direita = direita;        //Define a direção que o objeto vai andar
                if (direita)                        //Verifica de qual lado do personagem será criado
                    objAtaque.transform.position = transform.position + Vector3.right;
                else
                    objAtaque.transform.position = transform.position - Vector3.right;

                objAtaque.dano = status.getAtaque(); //Define o dano que a Kunai causa

                atacando = true;                    //Informa que o personagem está atacando
            }

            //Habilidades
            if (Input.GetButtonDown("Habilidade1")) //Habilidade AtaqueTriplo
                habilidade1.executar();

            if (Input.GetButtonDown("Habilidade3")) //Habilidade Cura
                habilidade3.executar();
        } else 
            atacando = animator.GetCurrentAnimatorStateInfo(0).IsName("atacando");
    }
}
