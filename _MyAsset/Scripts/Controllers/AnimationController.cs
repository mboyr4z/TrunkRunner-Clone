using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();

        Actions.act_gameStarted += StartRunAnimation;
        Actions.act_winLevel += StartWinAnimation;
        Actions.act_loseLevel += StartLoseAnimation;
    }

    private void OnDestroy()
    {
        Actions.act_gameStarted -= StartRunAnimation;
        Actions.act_winLevel -= StartWinAnimation;
        Actions.act_loseLevel -= StartLoseAnimation;
    }


    private void StartRunAnimation()
    {
        PlayAnim(AnimType.RUN);
    }

    private void StartWinAnimation()
    {
        PlayAnim(AnimType.WIN);
    }

    private void StartLoseAnimation()
    {
        PlayAnim(AnimType.DEATH);
    }


    public void PlayAnim(AnimType animType)
    {
        animator.SetInteger("AnimType",(int)animType);
    }

}


public enum AnimType
{
    IDLE,
    RUN,
    DEATH,
    WIN
}