using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class MagoAzul : Inimigo {

    public List<Vector3> posicoes;
    public float duracaoAtaque;
    private float contagemAtaque;

    protected override void Awake() {
        base.Awake(); //Chama o Awake da classe Inimigo
        status = new Status(30, 0, 0); //HP = 30 | MP = 0 | Ataque = 0

        contagemAtaque = duracaoAtaque;
    }

    protected override void atacar() {
        contagemAtaque -= Time.deltaTime;   //Reduz o tempo da contagem
        if (contagemAtaque <= 0) {          //Caso tenha completado o tempo, solta o ataque
            Invoke("lancarMagia", 0.1f);    //Lança uma mágia após 0.1 segundo    
            Invoke("lancarMagia", 1f);      //Lança uma mágia após 1 segundo    
            Invoke("lancarMagia", 2f);      //Lança uma mágia após 2 segundos    
            contagemAtaque = duracaoAtaque; //Reinicia a contagem
        }
    }

    void lancarMagia() {
        var prefab = Resources.Load("prefabs/inimigos/MagiaNegra");
        var obj = Instantiate(prefab, transform.position, Quaternion.identity) as GameObject;
        var magia = obj.GetComponent<AtaqueSeguirJogador>();
        magia.velocidade = UnityEngine.Random.Range(1f, 10f);
    }

    protected override void mover() { }

    public override void recebeDano(int dano) {
        base.recebeDano(dano);

        if (!status.estaMorto()) { 
            var random = new System.Random();
            var tamanhoDaLista = posicoes.Count;
            var posicao = random.Next(0, (tamanhoDaLista - 1));
            transform.position = posicoes[posicao];
        }
    }
}
