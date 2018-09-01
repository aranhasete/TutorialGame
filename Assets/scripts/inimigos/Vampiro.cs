using UnityEngine;
using System.Collections;
using System;

public class Vampiro : Inimigo {

    public bool direita = false;        //Está virado para direita
    public float tempoVirar;            //De quanto em quanto tempo ele vira
    private float contadorTempoVirar;   //O contador que verifica o tempo para virar

    public int dano;        //Dano causado no jogador
    public float alcance;   //Alcance do ataque


    protected override void Awake() {
        base.Awake(); //Chama o Awake da classe Inimigo
        status = new Status(999, 0, 0); //HP = 999 | MP = 0 | Ataque = 0
        contadorTempoVirar = tempoVirar;
    }

    protected override void atacar() {
        //Verifica se o personagem está no alcance
        var direcao = (direita ? Vector3.right : -Vector3.right); 
        var personagemPerto = Physics2D.Raycast(transform.position, direcao, alcance, 1 << LayerMask.NameToLayer("Personagem"));
        
        //Cria a linha na aba Scene
        Debug.DrawRay(transform.position, direcao * alcance, Color.red);

        //Verifica se pode atacar
        if (personagemPerto && !animator.GetCurrentAnimatorStateInfo(0).IsName("atacando")) {
            animator.SetTrigger("atacou");
            var personagem = GameObject.FindGameObjectWithTag("Player").GetComponent<IPersonagem>();
            personagem.recebeDano(dano);
        }

        //Regenera
        status.recuperaHP(999); //Recupera tudo
    }

    protected override void mover() {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("atacando")) { 
            contadorTempoVirar -= Time.deltaTime;
            if (contadorTempoVirar <= 0) {
                direita = !direita;         //Direita vai receber a negação dela, ou seja se era false vira true, se era true vira false
                inverter();                 //inverte o lado 
                contadorTempoVirar = tempoVirar; //reinicia a contagem
            }
        }
    }
}
