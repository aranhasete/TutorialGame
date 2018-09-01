using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface IPersonagem {
    Status getStatus();
    void recebeDano(int dano);
    Sprite getSprite();
    string getNomePrefab();
    IHabilidade getHabilidade1();
    IHabilidade getHabilidade2();
    IHabilidade getHabilidade3();

    //List<IHabilidade> getHabilidade();

    Animator getAnimator();
    float getVelocidade();
    void setVelocidade(float velocidade);
}

