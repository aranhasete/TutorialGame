using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GCIntro : MonoBehaviour {

    [SerializeField]    //Isso permite exibir a variavel no Editor do Unity, mesmo que ela seja private ou protected
    private float duracaoScene;

    [SerializeField]
    private RectTransform objetos;

    [SerializeField]
    private float velocidade;

    private float tamanho;

	void Update () {
        tamanho += Time.deltaTime * velocidade;
        tamanho = Mathf.Min(tamanho, 100);
        objetos.sizeDelta = new Vector2(tamanho, tamanho); //Aumenta o Width e Height do objeto canvas

        //Transição de Scene
        duracaoScene -= Time.deltaTime;
        if (duracaoScene <= 0)
            SceneManager.LoadScene("Main");
	}
}

