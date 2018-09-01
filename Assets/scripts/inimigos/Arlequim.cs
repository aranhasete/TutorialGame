using UnityEngine;
using System.Collections;
using System;

public class Arlequim : Inimigo {

    private int forma = 1;          //A forma atual do Boss

    //Ataque 1
    public GameObject ataque1;
    public float intervaloAtaque1;
    private float contagemAtaque1;

    //Ataque 2
    public GameObject ataque2;
    public float intervaloAtaque2;
    private float contagemAtaque2;

    //Ataque 3
    public GameObject ataque3;
    public float intervaloAtaque3;
    private float contagemAtaque3;

    protected override void Awake() {
        base.Awake();
        status = new Status(100, 0, 0); //HP = 100 | MP = 0 | Ataque = 0
    }

    protected override void atacar() {
        //Ataque1
        contagemAtaque1 -= Time.deltaTime;
        if (contagemAtaque1 <= 0) {
            var personagem = GameObject.FindGameObjectWithTag("Player").transform;
            Instantiate(ataque1, personagem.position, Quaternion.identity);
            contagemAtaque1 = intervaloAtaque1;
        }

        //Ataque2
        if (forma >= 2) { 
            contagemAtaque2 -= Time.deltaTime;
            if (contagemAtaque2 <= 0) {
                var personagem = GameObject.FindGameObjectWithTag("Player").transform;
                Instantiate(ataque2, personagem.position, Quaternion.identity);
                contagemAtaque2 = intervaloAtaque2;
            }
        }

        //Ataque3
        if (forma >= 3) { 
            contagemAtaque3 -= Time.deltaTime;
            if (contagemAtaque3 <= 0) {
                Instantiate(ataque3, transform.position, Quaternion.identity);
                contagemAtaque3 = intervaloAtaque3;
            }
        }
    }

    public override void recebeDano(int dano) {
        base.recebeDano(dano);

        var porcentagem = (status.getHP() * 100) / status.getHPMax();

        if (porcentagem <= 20) { //Menos de 20%
            forma = 3;
        } else if (porcentagem <= 50) { //Menos de 50%
            forma = 2;
        } else 
            forma = 1;

        animator.SetInteger("forma", forma); //Muda a animação 
    }

    protected override void mover() { }
}
