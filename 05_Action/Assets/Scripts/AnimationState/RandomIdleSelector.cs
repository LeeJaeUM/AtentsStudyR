using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomIdleSelector : StateMachineBehaviour
{
    readonly int IdleSelect_Hash = Animator.StringToHash("IdleSelect");

    // OnStateEnter is called before OnStateEnter is called on any state inside this state machine
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetInteger(IdleSelect_Hash, RandomSelect());
    }

    /// <summary>
    /// 랜덤하게 0~4 사이의 값을 선택하는 함수(수별로 확률 다름)
    /// </summary>
    /// <returns>0~4</returns>
    int RandomSelect()
    {
        int select = 0;     // 80%
        float num = Random.value;

        if(num < 0.05f)
        {
            select = 4;     // 5%
        }
        else if(num < 0.10f)
        {
            select = 3;     // 5%
        }
        else if (num < 0.15f)
        {
            select = 2;     // 5%
        }
        else if (num < 0.20f)
        {
            select = 1;     // 5%
        }
        return select;
    }
}
