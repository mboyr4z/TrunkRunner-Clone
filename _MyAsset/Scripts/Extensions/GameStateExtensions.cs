using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameStateExtensions
{
    public static bool IsActive(this GameStates state) => state == GameManager.instance.GetState();
}
