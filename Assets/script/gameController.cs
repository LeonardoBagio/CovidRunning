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
    public AudioSource musicaFeliz;
    private GameObject player;
    void Start()
    {
        instance    = this;
        player      = GameObject.FindGameObjectWithTag("Player");
        musicaFeliz = GetComponent<AudioSource>();
        atualizarVida();
    }

    void Update(){
        if(GameObject.FindGameObjectWithTag("Player") != null){
            controlarScore();
        }
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

        if (vidaPersonagem > 3){
            vidaPersonagem = 3;
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
    
    private void gameOver(){
        Destroy(player.gameObject);
    }
}