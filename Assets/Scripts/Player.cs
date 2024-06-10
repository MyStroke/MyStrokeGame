using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed,maxSpeed;
    public bool grounded;
    Physics2D physics2D;
    Animator animator;
    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal;
        horizontal = Input.GetAxis("Horizontal");
        animator.SetBool("Grounded",true);
        animator.SetFloat("Speed",Mathf.Abs(horizontal));
        if(horizontal < 0.1f){
            transform.Translate(Vector2.right * Speed* Time.deltaTime);
            transform.eulerAngles = new Vector2(0,180);  
        }else if(horizontal > 0.1f){
            transform.Translate(Vector2.right * Speed* Time.deltaTime);
            transform.eulerAngles = new Vector2(0,0);
            
        }
    }
}
