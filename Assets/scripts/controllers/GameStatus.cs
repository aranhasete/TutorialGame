using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class GameStatus {

    public int faseLiberada;            //Guarda a ultima fase liberada
    public Status status;               //Guarda o Status do personagem
    public string prefabPersonagem;     //Guarda o nome do prefab do personagem
}
