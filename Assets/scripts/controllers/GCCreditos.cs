using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class GCCreditos : MonoBehaviour {

    [SerializeField]
    private RectTransform creditos;

    [SerializeField]
    private float velocidade;

    [SerializeField]
    private float tempoCreditos;

    void Update() {
        //Avança os creditos
        var posicao = creditos.position;
        posicao.y += Time.deltaTime * velocidade;
        creditos.position = posicao;

        //Volta pro menu
        tempoCreditos -= Time.deltaTime;
        if (tempoCreditos <= 0)
            SceneManager.LoadScene("Main");
        
    }
}

