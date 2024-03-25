using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Kräver att ett Rigidbody2D-komponent ska finnas på objektet detta skript är tillagt.
[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController2D : MonoBehaviour
{
    Rigidbody2D rigidbody2d; // Referens till Rigidbody2D-komponenten.
    [SerializeField] float speed = 2f; // Karaktärens hastighet, kan ändras i Unity-editorn.
    Vector2 motionVector; // Rörelsevektor som bestämmer riktning och storlek på karaktärens rörelse.
    public Vector2 lastmotionvector; // Senast använd rörelsevektor.
    Animator animator; // Referens till Animator-komponenten.
    public bool moving; // Bool som indikerar om karaktären rör sig.

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>(); // Hämtar och lagrar referensen till Rigidbody2D-komponenten.
        animator = GetComponent<Animator>(); // Hämtar och lagrar referensen till Animator-komponenten.
    }

    private void Update()
    {
        // Hämtar input från användaren.
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // Skapar en ny vektor baserad på inputen.
        motionVector = new Vector2(horizontal, vertical);

        // Uppdaterar animationsparametrar baserat på rörelseriktning.
        animator.SetFloat("Horizontal", horizontal);
        animator.SetFloat("Vertical", vertical);

        // Kontrollerar om karaktären rör sig.
        moving = horizontal != 0 || vertical != 0;
        animator.SetBool("moving", moving);

        // Sparar den senaste rörelsevektorn om det finns rörelse.
        if (horizontal != 0 || vertical != 0)
        {
            lastmotionvector = new Vector2(horizontal, vertical).normalized;
            animator.SetFloat("lastHorizontal", horizontal);
            animator.SetFloat("lastVertical", vertical);
        }
    }

    private void FixedUpdate()
    {
        // Utför rörelseberäkningar baserade på fysik.
        Move();
    }

    private void Move()
    {
        // Använder velocity för att flytta karaktären baserat på motionVector och speed.
        rigidbody2d.velocity = motionVector * speed;
    }
}
