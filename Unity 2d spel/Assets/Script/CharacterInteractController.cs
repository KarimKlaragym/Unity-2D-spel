using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    CharacterController2D characterController;
    Rigidbody2D rgbd2d;
    [SerializeField] float offsetdistance = 1f;
    [SerializeField] float sizeOfinteractableArea = 1.2f;
    Character character;

    private void Awake()
    {
        characterController = GetComponent<CharacterController2D>();
        rgbd2d = GetComponent<Rigidbody2D>();
        character = GetComponent<Character>();
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Interact();

        }
    }
    private void Interact()
    {
        Vector2 postion = rgbd2d.position + characterController.lastmotionvector * offsetdistance;

        Collider2D[] collidors = Physics2D.OverlapCircleAll(postion, sizeOfinteractableArea);

        foreach (Collider2D c in collidors)
        {
            Interactable hit = c.GetComponent<Interactable>();
            if (hit != null)
            {
                hit.Interact(character);
                break;
            }
        }
    }
}
