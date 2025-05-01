using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public PlayerController player{get;private set;}
    private void Awake()
    {
        Instance = this;
        player = FindAnyObjectByType<PlayerController>();
        player.Init(this);
    }
}
