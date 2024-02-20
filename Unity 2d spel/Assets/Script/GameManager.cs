using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManeger : MonoBehaviour
{
    public static GameManeger instance;

    private void Awake()
    {
        instance = this;
    }

    public GameObject player;
}
