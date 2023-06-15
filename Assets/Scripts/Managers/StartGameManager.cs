using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameManager : MonoBehaviour
{
    public static event Action OnStartGame;

    private void Start()
    {
        OnStartGame?.Invoke();
    }
}
