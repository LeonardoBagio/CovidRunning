using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUp : MonoBehaviour
{
    private SpriteRenderer sr;
    private CircleCollider2D circle;
    public GameObject collected;
    public GameObject apple;
    public int Score;

    void Start(){
        sr      = GetComponent<SpriteRenderer>();
        circle  = GetComponent<CircleCollider2D>();
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.Space)){
            criarObjeto();
        }
    }

    void OnTriggerEnter2D(Collider2D collider){
        if (collider.gameObject.tag == "Player"){
            sr.enabled      = false;
            circle.enabled  = false;
            //collected.SetActive(true);

            gameController.instance.totalScore += Score;
            //gameController.instance.UpdateScoreText();
            Destroy(this, 0f);
            Destroy(gameObject, 0.3f);
        }
    }

    void criarObjeto(){
        Vector3 posicao = new Vector3(3f, -3.5f, 0f);

        Instantiate(apple, posicao, Quaternion.identity);
    }
}
