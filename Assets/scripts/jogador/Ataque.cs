using UnityEngine;
using System.Collections;

public class Ataque : MonoBehaviour {

    public int dano;  //Dano causado pelo ataque

    void Awake() {
        gameObject.layer = 10; //Layer do personagem
    }

    public void destroiObjeto(float tempo) {
        Destroy(gameObject, tempo);
    }

    void OnTriggerEnter2D(Collider2D colisor) {
        if (colisor.gameObject.tag.Equals("Inimigo")) {
            var inimigo = colisor.gameObject.GetComponent<IInimigo>();
            inimigo.recebeDano(dano);
            Destroy(gameObject);
        }
    }
}
