using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Gun : MonoBehaviour
{
    [SerializeField] private Transform shootSpawn;

    [SerializeField] private float firePower;

    [SerializeField] private float fireRate;

    private GameManager gameManager;

    private ObjectPoolManager objectPoolManager;

    private List<Transform> targetCubesInStack = new List<Transform>();

    private float lastFireTime = -1f;

    private LayerMask obstackleLayer;

    private void Awake()
    {
        obstackleLayer = LayerMask.GetMask("Obstackle");
    }

    private void Start()
    {
        gameManager = GameManager.instance;
        objectPoolManager = ObjectPoolManager.instance;
        
    }


    private void Update()
    {
        if (IsGunReady())
        {
            lastFireTime = Time.time;

            

            GameObject createdDiamond = objectPoolManager.SpawnFromPool(PoolingObjectsTag.diamond, shootSpawn.position, Quaternion.identity);

            gameManager.DecreaseDiamond();

            createdDiamond.GetComponent<IThrowable>()?.Throw();
            
            Rigidbody rb = createdDiamond.GetComponent<Rigidbody>();
            rb.AddForce(firePower * transform.forward);

            Actions.act_shootedDiamond?.Invoke();
        }
    }

    private bool IsGunReady() {
        if(Time.time - lastFireTime > fireRate && GameStates.InRun.IsActive() && !gameManager.CollectedDiamondCount.IsNumberZero())
        {
            RaycastHit hit;

            if(Physics.Raycast(transform.position,transform.forward, out hit, 15f, obstackleLayer.value)){
                return true;
            }
        }
        return false;
    }

}
