using UnityEngine;
using System.Collections;

public class GCFaseLago : GCFase {

	void Start () {
        var objPlayer = GameObject.FindGameObjectWithTag("Player");
        //Diminui a gravidade
        var rigidbody2D = objPlayer.GetComponent<Rigidbody2D>();
        rigidbody2D.gravityScale *= 0.5f; //Cai pela metade

        //Velocidade
        var personagem = objPlayer.GetComponent<IPersonagem>();
        var velocidade = personagem.getVelocidade();
        velocidade *= 0.5f;
        personagem.setVelocidade(velocidade);
	}
}
