using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
	public AudioSource somJump;
    public float speed;
    public float jumpForce;
    public bool isJumping;
    public bool doubleJumping;
    private Rigidbody2D rig;
    private Animator anim;

    void Start(){
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update(){
        //move();
        jump();
		
    }

    void move(){
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * speed;
        
        if (Input.GetAxis("Horizontal") > 0f){
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        } 
        
        if (Input.GetAxis("Horizontal") < 0f) {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }

        if (Input.GetAxis("Horizontal") == 0f) {
            anim.SetBool("walk", false);
        }
    }

    void jump(){
        if (Input.GetButtonDown("Jump")){
            if (!isJumping){
                rig.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                anim.SetBool("jump", true);
				
            }
        }somJump.Play();
    }

    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.layer == 8){
            isJumping = false;
            anim.SetBool("jump", false);
        }
    }

    void OnCollisionExit2D(Collision2D collision){
        if (collision.gameObject.layer == 8){
            isJumping = true;
        }        
    }    
}
