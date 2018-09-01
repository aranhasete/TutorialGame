using UnityEngine;
using System.Collections;

public abstract class Inimigo : MonoBehaviour, IInimigo {

    public Animator animator;
    protected Status status;    
    public bool visivel;
    public float distanciaParaSurgir;
    protected bool encostado = false; //Está encostado no alvo

    protected virtual void Awake() {
        this.gameObject.tag = "Inimigo";
        this.gameObject.layer = 11;         //Layer Inimigo
    }
		
	void Update () {
	    if (!GCPause.getPausado()) {
            if (!visivel) {
                StartCoroutine(surgir());
            } else {
                mover();
                atacar();
            }
        }
	}

    IEnumerator surgir() {
        var posicaoPlayerX = GameObject.FindGameObjectWithTag("Player").transform.position.x;
        var distancia = Mathf.Abs(transform.position.x - posicaoPlayerX);
        
        if (distancia < distanciaParaSurgir) {
            animator.SetTrigger("surgiu");
            var duracaoAnimacao = animator.GetCurrentAnimatorStateInfo(0).length;
            yield return new WaitForSeconds(duracaoAnimacao);
            visivel = true;
        }
    }

    protected abstract void atacar();
    protected abstract void mover();

    public virtual void recebeDano(int dano) {
       if (visivel) {
            if (!status.estaMorto()) {
                status.sofrerDano(dano);

                if (status.estaMorto()) {
                    animator.SetTrigger("morreu");                                          //Chama a animação de morte
                    var duracaoAnimacao = animator.GetCurrentAnimatorStateInfo(0).length;   //Duração da animação
                    Destroy(this.gameObject, duracaoAnimacao);                              //Destroi objeto após animação
                    enabled = false;                                                        //Desabilita esse script com os ataques e movimentos
                }
                else {
                    GetComponent<SpriteRenderer>().material = Resources.Load("materials/SpriteVermelho") as Material;
                    Invoke("corNormal", 0.3f);                            //Normaliza a cor após 0.3 segundo
                }
            }
       }
    }

    void corNormal() {
        GetComponent<SpriteRenderer>().material = Resources.Load("materials/SpriteBranco") as Material;
    }

    protected void inverter() {
        float x = transform.localScale.x;
        x *= -1;
        transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);
    }

    void OnCollisionStay2D(Collision2D colisor) {
        if (!status.estaMorto() && status.getAtaque() > 0) { 
            if (colisor.gameObject.tag.Equals("Player")) {
                encostado = true;
                var personagem = colisor.gameObject.GetComponent<IPersonagem>();
                personagem.recebeDano(status.getAtaque());
                animator.SetTrigger("atacou");
            }
        }
    }


    void OnCollisionExit2D(Collision2D colisor) {
        if (colisor.gameObject.tag.Equals("Player"))
            encostado = false;
    }

}
