using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Setting variable
    private CharacterController character;
    private Vector3 direction;
    Animator animator;

    // import all file

    // Awake
    void Awake()
    {
        animator = this.gameObject.GetComponent<Animator>();
        character = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        direction = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Monsters")) {
            GameManager.instance.BoxProcess();
        }
    }
}
