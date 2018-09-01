using UnityEngine;
using System.Collections;
using System;

public class Personagem1 : Jogador {

    public Ataque ataque;

    protected override void Awake() {
        base.Awake();
        status = new Status(20, 6, 10);

        habilidade1 = new Slash();
        habilidade2 = new Berserker();
        habilidade3 = new Invencibilidade();

        habilidade1.setPersonagem(gameObject);
        habilidade2.setPersonagem(gameObject);
        habilidade3.setPersonagem(gameObject);

        //listaHabilidade[1] = new Slash();
        //listaHabilidade[2] = new Berserker();
        //listaHabilidade[3] = new Invencibilidade();

        //listaHabilidade[1].setPersonagem(gameObject);
        //listaHabilidade[2].setPersonagem(gameObject);
        //listaHabilidade[3].setPersonagem(gameObject);
    }

    protected override void atacar() {
        if (!atacando) {
            //Ataque Normal
            if (Input.GetButtonDown("Ataque")) {
                animator.SetTrigger("atacou");
                var objAtaque = Instantiate(ataque);
                objAtaque.destroiObjeto(animator.GetCurrentAnimatorStateInfo(0).length);

                if (direita)
                    objAtaque.transform.position = transform.position + (Vector3.right * 2);
                else
                    objAtaque.transform.position = transform.position - (Vector3.right * 2);

                objAtaque.dano = status.getAtaque();

                atacando = true;
            }

            //Habilidades
            if (Input.GetButtonDown("Habilidade1"))
                habilidade1.executar();

            if (Input.GetButtonDown("Habilidade2"))
                habilidade2.executar();

            if (Input.GetButtonDown("Habilidade3"))
                habilidade3.executar();

            //if (Input.GetButtonDown("Habilidade1"))
            //    listaHabilidade[1].executar();

            //if (Input.GetButtonDown("Habilidade2"))
            //    listaHabilidade[2].executar();

            //if (Input.GetButtonDown("Habilidade3"))
            //    listaHabilidade[3].executar();

        }
        else {
            atacando = animator.GetCurrentAnimatorStateInfo(0).IsName("atacando");
        }
    }

    void removeBerserker()
    {
        var ataque = status.getAtaque();
        status.setAtaque(ataque - 5);
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}

