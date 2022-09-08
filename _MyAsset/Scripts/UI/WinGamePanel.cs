using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

using Random = UnityEngine.Random;

public class WinGamePanel : MonoBehaviour
{

    private GameManager gameManager;

    private void OnEnable()
    {
        gameManager = GameManager.instance;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gameManager.IncreaseLevel();
            SceneManager.LoadScene(0);
        }
    }
}
