using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController2D : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb2d;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Animator animator; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal") * moveSpeed;
        rb2d.velocity = new Vector2(moveHorizontal, rb2d.velocity.y);
        Debug.Log(moveHorizontal);

        if (moveHorizontal !=0 )
        {
            spriteRenderer.flipX = moveHorizontal < 0;
        }
        animator.SetBool("IsPlayerRun", Mathf.Abs(moveHorizontal) > 0);
    }
}