using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Torus : MonoSingleton<Torus>
{
    [SerializeField] private float diamondXLerpTime;

    [SerializeField] private float diamondZLerpTime;

    [SerializeField] private float destroyDistance;

    private GameManager gameManager;

    private ObjectPoolManager objectPoolManager;

    private Hose hose;

    private List<Transform> collectedDiamonds = new List<Transform>();

    private List<Transform> blueDiamonds = new List<Transform>();

    private List<Vector2> blueDiamondsLerpTimes = new List<Vector2>();


    private void Start()
    {
        objectPoolManager = ObjectPoolManager.instance;
        gameManager = GameManager.instance;
        hose = Hose.instance;
    }


    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<ICollectable>()?.Collect(Collect);
    }

    private void Collect(Transform collectingObject)
    {
        collectedDiamonds.Add(collectingObject);
    }

    private void Update()
    {

        MoveDiamonds();
        MoveBlueDiamonds();
    }

    public void AddBlueDiamonds(Transform blueDiamond)
    {
        blueDiamonds.Add(blueDiamond);
    }

    public void AddBlueDiamondLerpTime(float x, float y)
    {
        blueDiamondsLerpTimes.Add(new Vector2(x, y));
    }

    private void MoveBlueDiamonds()
    {
        if (GameStates.InRun.IsActive())
            for (int i = blueDiamonds.Count - 1; i >= 0; i--)
            {
                Vector3 diamond = blueDiamonds[i].position;
                blueDiamonds[i].position = Vector3.Lerp(       // move X axis
                    diamond,
                    new Vector3(transform.position.x, diamond.y, diamond.z),
                    blueDiamondsLerpTimes[i].x);


                diamond = blueDiamonds[i].position;

                blueDiamonds[i].position = Vector3.Lerp(       // move Z  axis
                 diamond,
                 new Vector3(diamond.x, transform.position.y, transform.position.z),
                 blueDiamondsLerpTimes[i].y);


                if (blueDiamonds[i].position.z - transform.position.z < destroyDistance)
                {
                    hose.IncreaseBoneScale(1);

                    objectPoolManager.CollectToPool(PoolingObjectsTag.blueDiamond, blueDiamonds[i].gameObject);

                    int againt = Random.Range(0, 3);
                    gameManager.IncreaseScore(againt);

                    Actions.act_increasedScore?.Invoke();

                    blueDiamonds.RemoveAt(i);
                    blueDiamondsLerpTimes.RemoveAt(i);
                }
            }
    }

    private void MoveDiamonds()
    {
        if (GameStates.InRun.IsActive())
            for (int i = collectedDiamonds.Count - 1; i >= 0; i--)
            {
                Vector3 diamond = collectedDiamonds[i].position;
                collectedDiamonds[i].position = Vector3.Lerp(       // move z axis
                    diamond,
                    new Vector3(transform.position.x, diamond.y, diamond.z),
                    diamondXLerpTime);


                diamond = collectedDiamonds[i].position;

                collectedDiamonds[i].position = Vector3.Lerp(       // move z axis
                 diamond,
                 new Vector3(diamond.x, transform.position.y, transform.position.z),
                 diamondZLerpTime);


                if (collectedDiamonds[i].position.z - transform.position.z < destroyDistance)
                {
                    hose.IncreaseBoneScale(1);

                    objectPoolManager.CollectToPool(PoolingObjectsTag.diamond, collectedDiamonds[i].gameObject);
                    collectedDiamonds.RemoveAt(i);
                }
            }
    }


}
