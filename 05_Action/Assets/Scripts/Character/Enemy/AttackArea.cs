using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    public SphereCollider attackArea;

    private void Awake()
    {
        attackArea = GetComponent<SphereCollider>();    
    }

    private void OnTriggerEnter(Collider other)
    {
        //// 추적상태이고 플레이어가 들어왔으면
        //if (State == EnemyState.Chase && other.CompareTag("Player"))
        //{
        //    attackTarget = other.GetComponent<IBattler>();  // 공격 대상 저장해 놓기
        //    State = EnemyState.Attack;
        //}
    }

    private void OnTriggerExit(Collider other)
    {
        //if (other.CompareTag("Player"))
        //{
        //    attackTarget = null;
        //    if (State != EnemyState.Dead)
        //    {
        //        State = EnemyState.Chase;
        //    }
        //}
    }
    private void OnDrawGizmos()
    {
        if (attackArea != null)
        {
            Handles.color = Color.red;
            Handles.DrawWireDisc(transform.position, transform.up, attackArea.radius, 5);   // 공격 범위 그리기
        }
    }
}
