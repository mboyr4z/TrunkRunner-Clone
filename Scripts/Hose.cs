using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Hose : MonoSingleton<Hose>
{
    [SerializeField] private List<Transform> bones;

    [SerializeField] private Transform player;

    [SerializeField] private Vector3 bigBoneScale;

    [SerializeField] private float moveLerpTime;

    [SerializeField] private float bigBoneTime;

    [SerializeField] private float firstBoneTime;


    private Vector3 firstBoneScale;


    private Vector3[] offsets;

    private Vector3 bp, beforeBp, bs, beforeBs;

    private void Start()
    {
        offsets = new Vector3[bones.Count];
        firstBoneScale = bones[1].localScale;

        //bones[1].localScale = new Vector3(0.1f,2.54f,2.54f);

        SetOffsets();
    }

    private void SetOffsets()
    {
        for (int i = 0; i < bones.Count; i++)
        {
            offsets[i] = player.position - bones[i].position;
        }
    }





    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IncreaseBoneScale(0);
        }


        MoveBones();
        
    }


    public void IncreaseBoneScale(int boneRank)
    {

        bones[boneRank].DOScale(bigBoneScale, bigBoneTime).OnComplete(() => {
            bones[boneRank].DOScale(firstBoneScale, firstBoneTime);
            if (boneRank < bones.Count - 3)
            {
                IncreaseBoneScale(++boneRank);
            }
        });
    }



    private void MoveBones()
    {
        if (GameStates.InRun.IsActive())
        {
            for (int i = 0; i < bones.Count; i++)
            {
                bp = bones[i].position;
                bones[i].position = new Vector3(bp.x, bp.y, player.position.z - offsets[i].z);
            }       // only move z axis

            bp = bones[0].position;
            bones[0].position = Vector3.Slerp(bp, new Vector3(player.position.x - offsets[0].x, player.position.y - offsets[0].y, bp.z), 1f);

            bp = bones[1].position;
            bones[1].position = Vector3.Slerp(bp, new Vector3(player.position.x - offsets[1].x, player.position.y - offsets[1].y, bp.z), 1f);
            /*bones[1].LookAt(bones[2]);
            bones[1].Rotate(90, 180, 90);*/


            for (int i = 2; i < bones.Count; i++)           // move x axis
            {
                beforeBp = bones[i - 1].position;
                bp = bones[i].position;


                bones[i].position = Vector3.Lerp(bp, new Vector3(beforeBp.x, beforeBp.y, bp.z), moveLerpTime);

                bones[i].LookAt(bones[i - 1].position);

                bones[i].Rotate(90, 0, 90);
            }
        }
    }






}
