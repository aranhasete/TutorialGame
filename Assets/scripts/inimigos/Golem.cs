using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Golem : Inimigo {

    public List<Vector3> pedras;
    public float duracaoAtaque;
    private float contagemAtaque;

    protected override void Awake() {
        base.Awake(); //Chama o Awake da classe Inimigo
        status = new Status(50, 0, 0); //HP = 50 | MP = 0 | Ataque = 0

        contagemAtaque = duracaoAtaque;
    }

    protected override void atacar() {
        contagemAtaque -= Time.deltaTime;

        if (contagemAtaque <= 0) {
            var prefab = Resources.Load("prefabs/inimigos/Pedra");

            //Pedras que Caem
            foreach (var posicao in pedras)
                Instantiate(prefab, posicao, Quaternion.identity);

            //Pedra horizontal
            var pedra = Instantiate(prefab, transform.position, Quaternion.identity) as GameObject;
            pedra.GetComponent<Rigidbody2D>().AddForce(-Vector3.right * 1000);

            contagemAtaque = duracaoAtaque;
            animator.SetTrigger("atacou");
        }
    }

    protected override void mover() {}
}
