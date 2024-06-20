using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Setting variable
    private CharacterController character;
    private Vector3 direction;
    public Animator animator { get; private set; }

    // import all file

    // Awake
    private void Awake()
    {
        animator = GetComponent<Animator>();
        character = GetComponent<CharacterController>();

        animator.Play("HeroKnight_Run");
    }

    private void OnEnable()
    {
        direction = Vector3.zero;
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Monsters")) {
            GameManager.instance.BoxProcess();
        }
    }
}
