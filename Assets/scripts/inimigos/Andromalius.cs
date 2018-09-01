using UnityEngine;
using System.Collections;

public class Andromalius : Inimigo { 

    public bool direita;
    public bool subindo;
    public float velocidade;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    protected override void Awake() {
        base.Awake(); //Chama o Awake da classe Inimigo
        status = new Status(30, 0, 7); //HP = 30 | MP = 0 | Ataque = 7

        if (!direita) 
            inverter();
    }

    protected override void atacar() { }

    protected override void mover() {
        var direcao = new Vector3();

        //Horizontal
        if (direita) {
            if (transform.position.x > maxX) {  //Passou do limite da direita
                inverter();
                direita = false;
            }
        } else {
            if (transform.position.x < minX) { //Passou do limite da esquerda
                inverter();
                direita = true;
            }
        }

        //vertical
        if (subindo) {
            if (transform.position.y > maxY)
                subindo = false;
        } else {
            if (transform.position.y < minY)
                subindo = true;
        }

        direcao.x = (direita ? 1 : -1);
        direcao.y = (subindo ? 1 : -1);

        transform.Translate(direcao * velocidade * Time.deltaTime);
    }
}
