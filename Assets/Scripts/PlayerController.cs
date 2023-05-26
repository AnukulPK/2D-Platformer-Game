using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
 public Animator animator;

 private void Awake() {
    Debug.Log("Player Controller Awake");
 }

  private void Update() {
    float speed = Input.GetAxisRaw("Horizontal");
    float VerticalInput = Input.GetAxis("Vertical");	

    animator.SetFloat("Speed",Mathf.Abs(speed));  
    Vector3 scale = transform.localScale;

    if(speed<0){
        scale.x=-1f *Mathf.Abs(scale.x);
    }else if(speed>0){
        scale.x=Mathf.Abs(scale.x);
    }
    transform.localScale=scale;

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
