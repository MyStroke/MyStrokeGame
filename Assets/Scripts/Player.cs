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
    public string[] attackList = {"HeroKnight_Attack1", "HeroKnight_Attack2", "HeroKnight_Attack3"};
    private static System.Random rnd = new System.Random();
    private string AttackName;

    // import all file
    private GameManager gameManager;
    private Countdown countdown;

    // Awake
    private void Awake()
    {
        animator = GetComponent<Animator>();
        character = GetComponent<CharacterController>();
        countdown = FindObjectOfType<Countdown>();

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

        // if player hit the boss
        else if (other.CompareTag("Boss")) {
            GameManager.instance.BoxProcessBoss();
            countdown.bossSpawned = true; // Set Boss Spawned

            // Random Attack
            int acttackIndex = RandomAttack();
            animator.Play(attackList[acttackIndex]);
        }
    }

    // Random Attack
    public int RandomAttack()
    {
        int index = rnd.Next(attackList.Length);
        return index;
    }
}
