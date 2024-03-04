using System;
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
    [SerializeReference] HighlightController highlightController;

    private void Awake()
    {
        characterController = GetComponent<CharacterController2D>();
        rgbd2d = GetComponent<Rigidbody2D>();
        character = GetComponent<Character>();
    }


    private void Update()
    {
        Check();

        if (Input.GetMouseButtonDown(1))
        {
            Interact();

        }
    }

    private void Check()
    {
        Vector2 postion = rgbd2d.position + characterController.lastmotionvector * offsetdistance;

        Collider2D[] collidors = Physics2D.OverlapCircleAll(postion, sizeOfinteractableArea);


        foreach (Collider2D c in collidors)
        {
            Interactable hit = c.GetComponent<Interactable>();
            if (hit != null)
            {
                highlightController.Highlight(hit.gameObject);
                return;
            }
        }

            highlightController.Hide();
        
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
