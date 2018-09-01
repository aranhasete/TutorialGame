using UnityEngine;
using System.Collections;

public class Scrolling : MonoBehaviour {

    public float velocidade;        //Velocidade que a imagem irá se mover
    private Material material;       //Material do Objeto com o Script

	void Start () {
        material = GetComponent<Renderer>().material;
	}
	
	void Update () {
        var x = Mathf.Repeat(Time.time * velocidade, 1); //Acrescendo um novo valor ao offset Horizontalmente
        var novoOffset = new Vector2(x, 0);             //Define  esse novo offset
        material.SetTextureOffset("_MainTex", novoOffset); //aplica a alteração
    }
}
