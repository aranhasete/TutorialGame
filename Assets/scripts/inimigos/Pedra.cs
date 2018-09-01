using UnityEngine;
using System.Collections;

public class Pedra : MonoBehaviour {

    public int dano;
    public float tempoAutoDestruicao;

	void Awake() {
        gameObject.layer = 11; //Layer Inimigos
        Destroy(this.gameObject, tempoAutoDestruicao);
    }

    void OnCollisionEnter2D (Collision2D colisor) {
        if (colisor.gameObject.tag.Equals("Player")) {
            var personagem = colisor.gameObject.GetComponent<IPersonagem>();
            personagem.recebeDano(dano);

            Destroy(this.gameObject); //Destroi a pedra
        }
    }
}
