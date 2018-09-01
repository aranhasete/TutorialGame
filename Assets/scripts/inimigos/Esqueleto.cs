using UnityEngine;
using System.Collections;
using System;

public class Esqueleto : Inimigo {

    public float alcanceAtaque;
    public bool direita;
    public float alcanceVisao;
    public float velocidade;

    protected override void Awake() {
        base.Awake();
        status = new Status(30, 10, 5); //HP = 30 | MP = 10 | Ataque = 5
    }

    protected override void atacar() {
        //Saber se está proximo
        var direcao = (direita ? Vector2.right : -Vector2.right);
        Debug.DrawRay(transform.position, direcao * alcanceAtaque, Color.red);
        var proximo = Physics2D.Raycast(transform.position, direcao, alcanceAtaque, 1 << LayerMask.NameToLayer("Personagem"));
        
        //Saber se está atacando
        var atacando = animator.GetCurrentAnimatorStateInfo(0).IsName("atacando");

        //Saber se tem MP suficiente
        var temMP = status.getMP() >= 1; //Usamos 1 de MP por ataque
        
        if (proximo && !atacando && temMP && !encostado) {
            var prefab = Resources.Load("prefabs/inimigos/MagiaNegra"); //Prefab da Magia
            Instantiate(prefab, transform.position, Quaternion.identity);
            status.usaMagia(1); //Custo da Magia
            animator.SetTrigger("atacou");
        }
    }

    protected override void mover() {
        var atacando = animator.GetCurrentAnimatorStateInfo(0).IsName("atacando");

        if (!atacando) {
            //Direção do esqueleto
            var personagem = GameObject.FindGameObjectWithTag("Player");
            var direcaoPlayer = personagem.transform.position.x - transform.position.x;

            if (direcaoPlayer > 0 && !direita) {
                direita = true;
                inverter();
            }

            if (direcaoPlayer < 0 && direita) {
                direita = false;
                inverter();
            }

            //Alcance
            var direcao = (direita ? Vector2.right : -Vector2.right);
            var vendo = Physics2D.Raycast(transform.position, direcao, alcanceVisao, 1 << LayerMask.NameToLayer("Personagem"));
            Debug.DrawRay(transform.position, alcanceVisao * direcao, Color.yellow);
            if (vendo) 
                transform.Translate(direcao * velocidade * Time.deltaTime);

            animator.SetBool("movimento", vendo);
        } 
    }
}
