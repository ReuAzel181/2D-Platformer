using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Death : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    public void Start(){
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
 
    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag("blueOp")){
            Die();
        }
        if (collision.gameObject.CompareTag("Spike")){
            Die();
        }
    }

    private void Die(){
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
    }

    private void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
