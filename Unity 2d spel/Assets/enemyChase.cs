using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public GameObject player; // Referens till spelarobjektet.
    public float speed; // Fiendens hastighet.
    public float distanceBetween; // Den distans vid vilken fienden b�rjar jaga spelaren.

    private float distance; // Den aktuella distansen mellan fienden och spelaren.

    void Update()
    {
        // Ber�knar distansen mellan fienden och spelaren.
        distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance < distanceBetween)
        {
            // Best�mmer riktningen mot spelaren men beh�ller fiendens nuvarande Y-position.
            Vector3 targetPosition = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);

            // R�r fienden mot spelaren med beaktande av endast X-positionen.
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
    }
}