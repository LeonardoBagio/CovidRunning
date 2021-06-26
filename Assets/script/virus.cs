using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class virus : MonoBehaviour
{
    private float velocidade = 3;
    private SpriteRenderer sr;
    private CircleCollider2D circle;
    public GameObject objetoSpawn;
    public float timeBetweenSpan;
    private float spawnTime;    

    void Start(){
        sr      = GetComponent<SpriteRenderer>();
        circle  = GetComponent<CircleCollider2D>();
    }

    void Update(){
        move();

        if (Time.time > spawnTime){
            criarObjeto();
            spawnTime = Time.time + timeBetweenSpan;
        }
    }

    void move(){
        Vector3 movement = new Vector3(-1f, 0f, 0f);
        transform.position += movement * Time.deltaTime * velocidade;
    }    

    void OnTriggerEnter2D(Collider2D collider){
        if (collider.gameObject.tag == "Player"){
            sr.enabled      = false;
            circle.enabled  = false;
            
            gameController.instance.vidaPersonagem -= 1;
            //gameController.instance.UpdateScoreText();
            Destroy(gameObject, 0f);
        }

        if (collider.gameObject.tag == "finalMap"){
            Destroy(gameObject, 0f);
        }
    }

    void criarObjeto(){
        Vector3 posicao = new Vector3(7f, -3.9f, 0f);

        Instantiate(objetoSpawn, posicao, Quaternion.identity);
    }
}
