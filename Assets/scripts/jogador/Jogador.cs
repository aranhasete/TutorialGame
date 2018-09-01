using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public abstract class Jogador : MonoBehaviour, IPersonagem {

    protected Status status;            //Classe com informações de HP, MP, Ataque, EXP, Nivel do personagem
    public Animator animator;           //Classe do próprio Unity responsável pela troca de Animação
    public float velocidade;            //Velocidade que o personagem anda
    public float forcaPulo;             //A força que será aplicada ao personagem pular
    protected bool direita = true;      //Lado para qual nosso personagem esta virado
    public GameObject chaoVerificador;  //Objeto que usaremos para saber se nosso objeto esta encostado no chão
    protected bool estaNoChao;          //Variável que informa (true) se nosso personagem estiver no chão
    public bool atacando;               //Verifica se o jogador está atacando
    public float invencibilidade;       //Por quanto tempo o personagem ainda está invencível 
    public bool desabilitarComandos = false; //Não permite controlar o personagem

    protected IHabilidade habilidade1;
    protected IHabilidade habilidade2;
    protected IHabilidade habilidade3;

    protected List<IHabilidade> listaHabilidade;

    protected virtual void Awake() {
        gameObject.tag = "Player";
        gameObject.layer = 10;
    }

    void Update() {
        if (!GCPause.getPausado()) {
            if (desabilitarComandos) 
                GetComponent<Rigidbody2D>().isKinematic = true;    
            else {
                GetComponent<Rigidbody2D>().isKinematic = false;
                if (!atacando)
                    mover();
                if (estaNoChao)
                    atacar();
            }
        }
    }

    void FixedUpdate() {
        invencivel();
    }

    protected virtual void mover() {
        //Andar
        if (Input.GetAxisRaw("Horizontal") > 0) {
            if (!direita)
                inverter();

            transform.Translate(Vector3.right * velocidade * Time.deltaTime);

            direita = true;
        }

        if (Input.GetAxisRaw("Horizontal") < 0) {
            if (direita)
                inverter();

            transform.Translate(Vector3.left * velocidade * Time.deltaTime);

            direita = false;
        }

        animator.SetFloat("velocidade", Mathf.Abs(Input.GetAxisRaw("Horizontal")));

        //Pular
        estaNoChao = Physics2D.Linecast(transform.position, chaoVerificador.transform.position, 1 << LayerMask.NameToLayer("Piso"));
        if (Input.GetButtonDown("Jump") && estaNoChao) {
            GetComponent<Rigidbody2D>().AddForce(transform.up * forcaPulo);
        }

        animator.SetBool("estaNoChao", estaNoChao);
    }

    protected abstract void atacar();

    void inverter() {
        float x = transform.localScale.x;
        x *= -1;
        transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);
    }


    public Status getStatus() {
        return status;
    }

    public void recebeDano(int dano) {
        if (!status.estaMorto()) {
            if (invencibilidade <= 0f) {
                status.sofrerDano(dano);

                if (status.estaMorto())
                    animator.SetTrigger("morreu");
                else
                    invencibilidade = 3f;
            }
        }
    }

    public bool getDireita() {
        return direita;
    }

    public bool getEstaNoChao() {
        return estaNoChao;
    }

    void invencivel() {
        var cor = GetComponent<SpriteRenderer>().color;
        if (invencibilidade > 0f) {
            if (cor.a == 1f)
                cor.a = 0f;
            else
                cor.a = 1f;
            invencibilidade -= Time.deltaTime;
        }
        else
            cor.a = 1f;
        
        GetComponent<SpriteRenderer>().color = cor;
    }
    
    public Sprite getSprite() {
        return GetComponent<SpriteRenderer>().sprite;
    }

    public string getNomePrefab() {
        return this.gameObject.name;
    }

    public IHabilidade getHabilidade1() {
        return this.habilidade1;
    }

    public IHabilidade getHabilidade2() {
        return this.habilidade2;
    }

    public IHabilidade getHabilidade3() {
        return this.habilidade3;
    }

    public Animator getAnimator() {
        return animator;
    }

    public float getVelocidade() {
        return velocidade;
    }

    public void setVelocidade(float velocidade) {
        this.velocidade = velocidade;
    }

    public List<IHabilidade> getHabilidade()
    {
        return this.listaHabilidade;
    }
}
