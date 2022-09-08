using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class AllTime : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tmp_score;

    [SerializeField] private TextMeshProUGUI tmp_collectingObjectCount;

    private GameManager gameManager;


    private void Start()
    {

        gameManager = GameManager.instance;

        setTmpScore();
        setCollectingObjectCount();

        Actions.act_collectedDiamond += setCollectingObjectCount;
        Actions.act_increasedScore += setTmpScore;
        Actions.act_shootedDiamond += setCollectingObjectCount;
    }

    private void OnDisable()
    {
        Actions.act_collectedDiamond -= setCollectingObjectCount;
        Actions.act_increasedScore -= setTmpScore;
        Actions.act_shootedDiamond -= setCollectingObjectCount;
    }

    private void setCollectingObjectCount()
    {
        tmp_collectingObjectCount.text = "Object Count : "+  gameManager.CollectedDiamondCount.ToString();
    }

    private void setTmpScore()
    {
        tmp_score.text = gameManager.GetScore().ToString();
    }
}
