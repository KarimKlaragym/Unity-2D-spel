using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCuttable : ToolHit

{

    [SerializeField] GameObject pickUpDrop;
    [SerializeField] int dropCount = 5;
    [SerializeField] float spread = 0.7f;

    public override void Hit()
    {
        while (dropCount > 0)
        {
            dropCount -= 1;

            Vector3 postion = transform.position;
            postion.x += spread * UnityEngine.Random.value - spread / 2;
            postion.y += spread * UnityEngine.Random.value - spread / 2;
            GameObject go = Instantiate(pickUpDrop);
            go.transform.position = postion;
        }


        Destroy(gameObject);
    }
}
