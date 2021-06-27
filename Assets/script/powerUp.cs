using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUp : MonoBehaviour
{
    private float velocidade = 3;
    private SpriteRenderer sr;
    private CircleCollider2D circle;
    public bool tipoPowerUp = false;

    void Start(){
        sr      = GetComponent<SpriteRenderer>();
        circle  = GetComponent<CircleCollider2D>();
    }

    void Update(){
        move();
    }

    void move(){
        Vector3 movement = new Vector3(-1f, 0f, 0f);
        transform.position += movement * Time.deltaTime * velocidade;
    }    

    void OnTriggerEnter2D(Collider2D collider){
        if (collider.gameObject.tag == "Player"){
            sr.enabled      = false;
            circle.enabled  = false;
            
            if (tipoPowerUp == false){
                gameController.instance.adicionarVida(1);
            } else {
                gameController.instance.adicionarVida(2);
            }
            
            Destroy(gameObject, 0f);
        }

        if (collider.gameObject.tag == "finalMap"){
            Destroy(gameObject, 0f);
        }        
    }
}
