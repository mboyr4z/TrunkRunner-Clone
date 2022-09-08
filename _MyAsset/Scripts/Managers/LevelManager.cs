using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoSingleton<LevelManager>
{
    private GameManager gameManager;

    private Color roadColor;

    private Vector3 startingPoint;

    private MaterialPropertyBlock _materialPropertyBlock;



    private void Start()
    {
        gameManager = GameManager.instance;

        _materialPropertyBlock = new MaterialPropertyBlock();

        createLevel();
    }
    private void createLevel()
    {

        DestroyLevel();

        Level newLevel = (Level)Resources.Load("Level" + ((gameManager.GetLevel() % GetTotalLevelCount()) + 1).ToString());


        roadColor = newLevel.levelTheme.roadColor;


        GameObject createdLevel = Instantiate(newLevel.prefab);

        ChangeRoadColor(createdLevel.transform);

    }





    private void ChangeRoadColor(Transform levelParent)
    {
        Transform Road = levelParent.GetChild(0);

        _materialPropertyBlock.SetColor("_Color", roadColor);

        Road.GetComponent<Renderer>().SetPropertyBlock(_materialPropertyBlock);

    }

    private void DestroyLevel()
    {
        if (transform.childCount > 0)
        {
            Destroy(transform.GetChild(0).gameObject);
        }

    }

    private int GetTotalLevelCount()
    {
        int count;

        for (count = 1; ; count++)
        {
            if (Resources.Load("Level" + count))
            {
            }
            else
            {
                break;
            }

        }
        return count - 1;
    }
}
