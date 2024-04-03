using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageTextGenerator : MonoBehaviour
{
    IBattler parentBattler;
    public GameObject TMPPrefab;

    private void Awake()
    {
        parentBattler = GetComponentInParent<IBattler>();
        parentBattler.onHitDamage += GenerateText;
    }


    void GenerateText(float damage)
    {
        DamageText damageText = Factory.Instance.GetDamageText(transform.position);
        if (damageText != null)
        {
            damageText.damageTMP.text = damage.ToString();
        }

    }
}
