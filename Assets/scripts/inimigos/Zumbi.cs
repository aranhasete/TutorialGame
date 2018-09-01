using UnityEngine;
using System.Collections;
using System;

public class Zumbi : Inimigo {

    public bool direita;
    public float velocidade;
    public float minX;
    public float maxX;

    protected override void Awake() {
        base.Awake(); //Chama o Awake da classe Inimigo
        status = new Status(10, 0, 5); //HP = 10 | MP = 0 | Ataque = 5

        if (direita)
            inverter();
    }

    protected override void atacar() {}

    protected override void mover() {
        if (direita) {
            transform.Translate(Vector3.right * velocidade * Time.deltaTime); //Anda para direita

            if (transform.position.x > maxX) {  //Passou do limite da direita
                inverter();
                direita = false;
            }
        }
        else {
            transform.Translate(-Vector3.right * velocidade * Time.deltaTime); //Anda para esquerda

            if (transform.position.x < minX) { //Passou do limite da esquerda
                inverter();
                direita = true;
            }
        }
    }
}
