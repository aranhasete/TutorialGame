using UnityEngine;
using System.Collections;

public class AtaqueSeguirJogador : MonoBehaviour {

    private Transform jogador;       //Alvo que irá seguir
    public float velocidade;        //Velocidade que o ataque se move
    public int dano;                //Dano que o ataque causa
    public float tempoDestruir;     //Tempo que levará para o ataque se auto destruir

	void Start () {
        jogador = GameObject.FindGameObjectWithTag("Player").transform; //Recupera o transform do jogador
        if (tempoDestruir > 0)
            Destroy(this.gameObject, tempoDestruir);
	}
	

	void Update () {
        transform.position = Vector3.MoveTowards(transform.position, jogador.position, velocidade * Time.deltaTime);

        //Rotaciona
        var direcao = jogador.transform.position - transform.position;
        var rotacao = Quaternion.LookRotation(direcao, transform.TransformDirection(Vector3.up));
        transform.rotation = new Quaternion(0, 0, rotacao.z, rotacao.w);
    }

    void OnTriggerEnter2D(Collider2D colisor) {
        if (colisor.gameObject.tag.Equals("Player")) {                      
            var personagem = colisor.gameObject.GetComponent<IPersonagem>();
            personagem.recebeDano(dano);
            Destroy(this.gameObject);
        }
    }
}
