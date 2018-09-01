using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class Status {

    private int hp;          //Total de vida atual do personagem
    private int hpMax;       //Total de vida máxima do personagem
    private int mp;         //Total de pontos de mágia atual do personagem
    private int mpMax;      //Total de pontos de mágia máxima do personagem
    private int ataque;     //Poder do ataque
    private int exp = 1;    //Total de experiencia
    private int nivel = 1;  //Nível atual do personagem

    public Status() {}

    public Status(int novoHP, int novoMP, int novoAtaque)
    {
        this.hpMax = this.hp = novoHP;
        this.mpMax = this.mp = novoMP;
        this.ataque = novoAtaque;
    }

    public int getHP()
    {
        return hp;
    }

    public int getHPMax()
    {
        return hpMax;
    }

    public int getMP()
    {
        return mp;
    }

    public int getMPMax() {
        return mpMax;
    }

    public int getAtaque() {
        return ataque;
    }

    public int getExp()
    {
        return exp;
    }

    public int getNivel()
    {
        return nivel;
    }

    public void setHP(int hp)
    {
        if (hp > this.hpMax)
            hp = this.hpMax;
        this.hp = hp;
    }

    public void setMP(int mp)
    {
        if (mp > this.mpMax)
            mp = this.mpMax;
        this.mp = mp;
    }

    public void setHPMax(int hpMax)
    {
        this.hpMax = hpMax;
    }

    public void setAtaque(int ataque)
    {
        this.ataque = ataque;
    }

    public void setExp(int exp)
    {
        this.exp = exp;
        this.nivel = (int)System.Math.Ceiling(exp / 100.00);
    }

    public void sofrerDano(int dano)
    {
        this.hp -= dano;
        if (this.hp < 0)
            this.hp = 0;
    }

    public void recuperaHP (int valor)
    {
        this.hp += valor;
        if (this.hp > this.hpMax)
            this.hp = this.hpMax;
    }

    public bool usaMagia(int mp)
    {
        if (this.mp < mp)
            return false;

        this.mp -= mp;
        return true;
    }

    public void recuperaMagia(int valor)
    {
        this.mp += valor;
        if (this.mp > this.mpMax)
            this.mp = this.mpMax;
    }

    public void adicionaExp(int valor)
    {
        exp += valor;
        nivel = (int)System.Math.Ceiling(exp / 100.00);
    }

    public bool estaMorto()
    {
        return this.hp == 0;
    }
    
}


