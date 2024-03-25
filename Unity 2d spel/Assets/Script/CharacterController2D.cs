using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Kr�ver att ett Rigidbody2D-komponent ska finnas p� objektet detta skript �r tillagt.
[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController2D : MonoBehaviour
{
    Rigidbody2D rigidbody2d; // Referens till Rigidbody2D-komponenten.
    [SerializeField] float speed = 2f; // Karakt�rens hastighet, kan �ndras i Unity-editorn.
    Vector2 motionVector; // R�relsevektor som best�mmer riktning och storlek p� karakt�rens r�relse.
    public Vector2 lastmotionvector; // Senast anv�nd r�relsevektor.
    Animator animator; // Referens till Animator-komponenten.
    public bool moving; // Bool som indikerar om karakt�ren r�r sig.

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>(); // H�mtar och lagrar referensen till Rigidbody2D-komponenten.
        animator = GetComponent<Animator>(); // H�mtar och lagrar referensen till Animator-komponenten.
    }

    private void Update()
    {
        // H�mtar input fr�n anv�ndaren.
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // Skapar en ny vektor baserad p� inputen.
        motionVector = new Vector2(horizontal, vertical);

        // Uppdaterar animationsparametrar baserat p� r�relseriktning.
        animator.SetFloat("Horizontal", horizontal);
        animator.SetFloat("Vertical", vertical);

        // Kontrollerar om karakt�ren r�r sig.
        moving = horizontal != 0 || vertical != 0;
        animator.SetBool("moving", moving);

        // Sparar den senaste r�relsevektorn om det finns r�relse.
        if (horizontal != 0 || vertical != 0)
        {
            lastmotionvector = new Vector2(horizontal, vertical).normalized;
            animator.SetFloat("lastHorizontal", horizontal);
            animator.SetFloat("lastVertical", vertical);
        }
    }

    private void FixedUpdate()
    {
        // Utf�r r�relseber�kningar baserade p� fysik.
        Move();
    }

    private void Move()
    {
        // Anv�nder velocity f�r att flytta karakt�ren baserat p� motionVector och speed.
        rigidbody2d.velocity = motionVector * speed;
    }
}
