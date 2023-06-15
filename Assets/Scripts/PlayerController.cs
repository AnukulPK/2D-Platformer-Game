using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
 public ScoreController scoreController;
 public Animator animator;

 public float speed;
 public float jump;
 private Rigidbody2D rb2d;


 private void Awake() {
    Debug.Log("Player Controller Awake");
    rb2d = gameObject.GetComponent<Rigidbody2D>();
 }

    public void KillPlayer(bool death)
    {
        Debug.Log("Player killed by enemy");
        /*Destroy(gameObject);*/

        //Play death animation
        animator.SetBool("Death", death);

        //Reload Level
        ReloadLevel();

    }

    public void ReloadLevel()
    {
        Debug.Log("Player Died");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Update() {
    float horizontal = Input.GetAxisRaw("Horizontal");
    float vertical = Input.GetAxisRaw("Jump");	

    MoveCharacter(horizontal, vertical);
    PlayMovementAnimation(horizontal,vertical); 

    if (Input.GetKey(KeyCode.LeftControl))
    {
        Crouch(true);
    }
    else
    {
        Crouch(false);
    }   
 }

    public void PickUpKey()
    {
        Debug.Log("Player picked up the key");
        scoreController.IncreaseScore(10);
    }

    private void MoveCharacter(float horizontal, float vertical){
    //move character horizontally
    Vector3 position = transform.position;
    // (Speed = distance/time)*(1/Frames per second say 30)
    position.x+=horizontal*speed*Time.deltaTime;
    transform.position=position;

    //move character horizontally
    if(vertical>0){
            rb2d.AddForce(new Vector2(0f, jump),ForceMode2D.Force);
    }
 }

 private void PlayMovementAnimation(float horizontal, float vertical){
    animator.SetFloat("Speed",Mathf.Abs(horizontal));  
    Vector3 scale = transform.localScale;

    if(horizontal<0){
        scale.x=-1f *Mathf.Abs(scale.x);
    }else if(horizontal>0){
        scale.x=Mathf.Abs(scale.x);
    }
    transform.localScale=scale;

    //Jump  
    if(vertical>0){
        animator.SetBool("Jump",true);
    }else{
        animator.SetBool("Jump",false);
    }

 }

 public void Crouch(bool crouch)
 {
          
    animator.SetBool("Crouch", crouch);
 }

}
