using UnityEngine;
using System.Collections;

public class Serra : MonoBehaviour {

    public float velocidade;        //Velocidade da movimentação
    public int dano;                //Dano causado ao encostar
    public Vector3 posicaoInicial;  //Posição inicial do objeto
    public Vector3 posicaoFinal;    //Posição até o objeto vai
    public bool inicio;             //Direção que está indo, se é pro inicio ou pro fim

	
	void Update () {
        //Move a Serra
	    if (inicio) {
            transform.position = Vector3.MoveTowards(transform.position, posicaoInicial, velocidade * Time.deltaTime);

            if (transform.position == posicaoInicial)
                inicio = false;
        } else {
            transform.position = Vector3.MoveTowards(transform.position, posicaoFinal, velocidade * Time.deltaTime);

            if (transform.position == posicaoFinal)
                inicio = true;
        }

        //Gira a Serra
        var rotacao = transform.eulerAngles;
        rotacao.z += velocidade * 100 * Time.deltaTime;
        if (rotacao.z > 360)
            rotacao.z -= 360;
        transform.eulerAngles = rotacao;
    }

    void OnCollisionStay2D(Collision2D colisor) { 
        if (colisor.gameObject.tag.Equals("Player")) {
            var personagem = colisor.gameObject.GetComponent<IPersonagem>();
            personagem.recebeDano(dano);
        }
    }
}
