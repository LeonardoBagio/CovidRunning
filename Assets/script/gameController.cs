using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameController : MonoBehaviour
{
    public int totalScore;
    public int vidaPersonagem = 3;
    public Text scoreText;
    public static gameController instance;

    void Start()
    {
        instance = this;
    }

    public void UpdateScoreText(){
        scoreText.text = totalScore.ToString();
    }

    public void adicionarVida(int vida){
        if (vidaPersonagem < 3){
            vidaPersonagem += vida;
        }
    }

    public void retirarVida(int vida){
        if (vidaPersonagem >= 1){
            vidaPersonagem -= vida;
        }

        if (vidaPersonagem == 0){
            gameOver();
        }
    }

    public void gameOver(){

    }
}
