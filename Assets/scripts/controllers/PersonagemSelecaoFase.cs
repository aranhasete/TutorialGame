using UnityEngine;
using System.Collections;

public class PersonagemSelecaoFase : MonoBehaviour {

    public float velocidade;
    public Vector3 destino;

	void Start () {
        destino = transform.position;
	}
	
	void Update () {
        transform.position = Vector3.MoveTowards(transform.position, destino, velocidade * Time.deltaTime);
	}
}
