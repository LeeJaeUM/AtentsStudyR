using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageText : RecycleObject
{
    //pool이있다.
    public TextMeshPro damageTMP;
    [SerializeField] Color TMPColor = Color.white;
    [SerializeField] Color defaultColor = Color.white;
    public float alpha = 1;

    public AnimationCurve movement;
    public float elapesTime = 0.0f;
    public float bounceHeight = 2f; // 튕김의 최대 높이
    public float bounceDuration = 2f; // 튕김의 지속 시간

    float defaultY = 0;

    private void Awake()
    {
        damageTMP = GetComponent<TextMeshPro>();
        defaultColor = damageTMP.color;
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        alpha = 1;
        elapesTime = 0;
        TMPColor = defaultColor;
        defaultY = transform.position.y;
        StartCoroutine(TextUpdate_Co());
    }
    float changeSpeed = 0.1f; // X 값의 변화 속도

    IEnumerator TextUpdate_Co()
    {
        float temp = 0;
        changeSpeed = UnityEngine.Random.Range(1, 15);
        changeSpeed *= 0.1f;
        // 랜덤한 방향 결정
        int direction = UnityEngine.Random.Range(0, 2) == 0 ? -1 : 1;
        float X = 0;
        while (temp < 2f)
        {
            temp += Time.deltaTime;

            // AnimationCurve를 사용하여 y 위치 계산
            float curveValue = movement.Evaluate(temp);
            //float X = Mathf.Min(temp, 0.7f); 
            X += direction * changeSpeed * Time.deltaTime;
            X = Mathf.Clamp(X, -1f, 1f);
            transform.position = new Vector3(X, defaultY + curveValue * bounceHeight, transform.position.z);

            // 텍스트의 투명도 조절
            alpha -= Time.deltaTime * 0.8f;
            TMPColor.a = alpha;
            damageTMP.color = TMPColor;

            yield return null;
        }
        gameObject.SetActive(false);
    }

}
