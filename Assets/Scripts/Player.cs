using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Setting variable
    private CharacterController character;
    private Vector3 direction;
    public Animator animator { get; private set; }

    // Setting Attack List
    private string[] attackList = {"HeroKnight_Attack1", "HeroKnight_Attack2", "HeroKnight_Attack3"};
    private static System.Random rnd = new System.Random();

    // import all file
    private GameManager gameManager;

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

            // Random Attack
            int acttackIndex = RandomAttack();
            animator.Play(attackList[acttackIndex]);
        }
    }

    // Random Attack
    private int RandomAttack()
    {
        int index = rnd.Next(attackList.Length);
        return index;
    }
}
