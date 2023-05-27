using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
 public Animator animator;

 public float speed;


 private void Awake() {
    Debug.Log("Player Controller Awake");
 }

  private void Update() {
    float horizontal = Input.GetAxisRaw("Horizontal");
    float VerticalInput = Input.GetAxis("Vertical");	

    MoveCharacter(horizontal);
    PlayMovementAnimation(horizontal);

     JumpAnimation(VerticalInput);  

    if (Input.GetKey(KeyCode.LeftControl))
    {
        Crouch(true);
    }
    else
    {
        Crouch(false);
    }   
 }

 private void MoveCharacter(float horizontal){
    Vector3 position = transform.position;
    // (Speed = distance/time)*(1/Frames per second say 30)
    position.x+=horizontal*speed*Time.deltaTime;
    transform.position=position;
 }

 private void PlayMovementAnimation(float horizontal){
        animator.SetFloat("Speed",Mathf.Abs(horizontal));  
    Vector3 scale = transform.localScale;

    if(horizontal<0){
        scale.x=-1f *Mathf.Abs(scale.x);
    }else if(horizontal>0){
        scale.x=Mathf.Abs(scale.x);
    }
    transform.localScale=scale;
 }

 public void Crouch(bool crouch)
 {
          
    animator.SetBool("Crouch", crouch);
 }


 public void JumpAnimation(float vertical)
 {    
    if (vertical > 0 )
    {
        animator.SetTrigger("Jump");            
    }
 }

  
}
