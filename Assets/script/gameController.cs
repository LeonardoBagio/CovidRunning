using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameController : MonoBehaviour
{
    public GameObject coracao;
    public int vidaPersonagem = 3;
    public static gameController instance;
    public int totalScore;
    private float controleTimeScore;
    public Text scoreText;
    public Text vida;

    void Start()
    {
        instance = this;
        atualizarVida();
    }

    void Update(){
        controlarScore();
    }

    private void controlarScore(){
        if (Time.time > controleTimeScore){
            controleTimeScore = Time.time + 0.4f;
            totalScore       += 1;
            atualizarScore();
        }
    }

    private void atualizarScore(){
        scoreText.text = "Total Score: "+totalScore.ToString()+"m";
    }

    public void adicionarVida(int vida){
        if (vidaPersonagem < 3){
            vidaPersonagem += vida;
        }

        atualizarVida();
    }
    public void retirarVida(int vida){
        if (vidaPersonagem >= 1){
            vidaPersonagem -= vida;
        }

        if (vidaPersonagem == 0){
            gameOver();
        }

        atualizarVida();
    }

    private void atualizarVida(){
        vida.text = "Vida: "+vidaPersonagem.ToString();
    }

    private void criarCoracao(){
        if (vidaPersonagem > 1){
            Vector3 posicao = new Vector3(-7f, 4.2f, 0f);
            Instantiate(coracao, posicao, Quaternion.identity);
        }

        if (vidaPersonagem > 2){
            Vector3 posicao = new Vector3(-5.5f, 4.2f, 0f);
            Instantiate(coracao, posicao, Quaternion.identity);
        }

        if (vidaPersonagem == 3){
            Vector3 posicao = new Vector3(-4f, 4.2f, 0f);
            Instantiate(coracao, posicao, Quaternion.identity);
        }
    }
    
    private void gameOver(){
        
    }
}
