using UnityEngine;
using System.Collections;

public interface IHabilidade {

    void setPersonagem(GameObject personagem);
    int getCustoHabilidade();
    void executar();
    bool podeUsar();
}
