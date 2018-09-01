using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GCFase : MonoBehaviour {

    public Vector3 posicaoInicial;
    public int nivel;
    private Transform player;
    public GameObject boss;
    private bool reiniciar = false;

    void Awake() {
        //Cria o personagem na fase
        //var nomePrefab = FindObjectOfType<GCJogo>().getGameStatus().prefabPersonagem; //Busca o nome do prefab
        //var prefabPlayer = Resources.Load("prefabs/jogador/" + nomePrefab);           //Busca o prefab
        //var objPersonagem = Instantiate(prefabPlayer) as GameObject;                  //Cria o personagem
        var objPersonagem = GameObject.FindGameObjectWithTag("Player").GetComponent<Personagem1>();               //Cria o personagem
        objPersonagem.transform.position = posicaoInicial;
        player = objPersonagem.transform;

        //Ajusta a camera
        var camera = FindObjectOfType<GCCamera>();
        camera.alvo = objPersonagem.transform;
    }

    void Update() {
        if (boss == null)
            Invoke("finalizarFase", 1f);

        var personagem = GameObject.FindGameObjectWithTag("Player").GetComponent<IPersonagem>();
        if (personagem.getStatus().estaMorto() && !reiniciar) {
            var duracaoAnimacao = personagem.getAnimator().GetCurrentAnimatorStateInfo(0).length;
            Invoke("reiniciarFase", duracaoAnimacao);
            reiniciar = true;   //Evita que entre nesse if outras vezes
        }
    }

    public virtual void finalizarFase() {
        var gameStatus = FindObjectOfType<GCJogo>().getGameStatus();                                    //Busca o GameStatus
        var status = GameObject.FindGameObjectWithTag("Player").GetComponent<IPersonagem>().getStatus();//Busca o Status do personagem ativo
        if (nivel == gameStatus.faseLiberada)                                                           //Verifica se esse nível é ultimo liberado
            gameStatus.faseLiberada++;                                                                  //Libera o próximo nivel

        status.recuperaHP(999);                     //Recupera todo HP
        status.recuperaMagia(999);                  //Recupera toda MP
        gameStatus.status = status;                 //Informa para o gameStatus o novo status do jogador.

        SceneManager.LoadScene("MenuFases");                   //Chama a scene de selação de fases
    }

    public void reiniciarFase() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

