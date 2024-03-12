using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public GameObject player; // Referens till spelarobjektet.
    public float speed; // Fiendens hastighet.
    public float distanceBetween; // Den distans vid vilken fienden börjar jaga spelaren.

    private float distance; // Den aktuella distansen mellan fienden och spelaren.

    void Update()
    {
        // Beräknar distansen mellan fienden och spelaren.
        distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance < distanceBetween)
        {
            // Bestämmer riktningen mot spelaren men behåller fiendens nuvarande Y-position.
            Vector3 targetPosition = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);

            // Rör fienden mot spelaren med beaktande av endast X-positionen.
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
    }
}