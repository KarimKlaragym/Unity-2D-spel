using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ToolsCharacterController : MonoBehaviour
{
    CharacterController2D character;
    Rigidbody2D rgbd2d;
    [SerializeField] float offsetdistance = 1f;
    [SerializeField] float sizeOfinteractableArea = 1.2f;

    private void Awake()
    {
        character = GetComponent<CharacterController2D>();
        rgbd2d = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            UseTool();

        }
    }
    private void UseTool()
    {
        Vector2 postion = rgbd2d.position + character.lastmotionvector * offsetdistance;

        Collider2D[] collidors = Physics2D.OverlapCircleAll(postion, sizeOfinteractableArea);

        foreach(Collider2D c in collidors)
        {
            ToolHit hit = c.GetComponent<ToolHit>();
            if (hit != null)
            {
                hit.Hit();
                break;
            }
        }
    }
}
