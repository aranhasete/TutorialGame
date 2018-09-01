using UnityEngine;
using System.Collections;
using System;

public class Medusa : Inimigo {

    public float velocidade;        //Velocidade do Inimigo
    private Transform jogador;      //transform que o inimigo vai seguir

    protected override void Awake() {
        base.Awake(); //Chama o Awake da classe Inimigo
        status = new Status(15, 0, 4); //HP = 15 | MP = 0 | Ataque = 4
    }

    void Start() {
        jogador = GameObject.FindGameObjectWithTag("Player").transform;
    }

    protected override void atacar() { }

    protected override void mover() {
        if (!encostado)
            transform.position = Vector3.MoveTowards(transform.position, jogador.position, velocidade * Time.deltaTime);

        //Rotaciona
        var direcao = jogador.transform.position - transform.position;
        var rotacao = Quaternion.LookRotation(direcao, transform.TransformDirection(Vector3.up));
        transform.rotation = new Quaternion(0, 0, rotacao.z, rotacao.w);
    }
}
