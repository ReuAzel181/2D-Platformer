using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Death : MonoBehaviour
{
    [SerializeField] private AudioSource deathSoundEffect;
    private Rigidbody2D rb;
    private Animator anim;

    public void Start(){
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
 
    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag("blueOp")){
            deathSoundEffect.Play();
            Die();
        }
        if (collision.gameObject.CompareTag("Spike")){
            deathSoundEffect.Play();
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
