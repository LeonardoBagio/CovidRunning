using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float jumpForce;
    public bool isJumping;
    private Rigidbody2D rig;
    private Animator anim;
    public AudioSource somJump;

    void Start(){
        rig     = GetComponent<Rigidbody2D>();
        anim    = GetComponent<Animator>();
        somJump = GetComponent<AudioSource>();
    }

    void Update(){
        jump();
        down();
    }

    void jump(){
        if (Input.GetButtonDown("Jump")){
            if (!isJumping){
                somJump.Play();
                rig.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                anim.SetBool("jump", true);
            }
        }
    }

    void down(){
        if (Input.GetKey("down")){
            if (isJumping){
                rig.gravityScale = 10;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.layer == 8){
            isJumping = false;
            rig.gravityScale = 3;
            anim.SetBool("jump", false);
        }
    }

    void OnCollisionExit2D(Collision2D collision){
        if (collision.gameObject.layer == 8){
            isJumping = true;
        }        
    }    
}
