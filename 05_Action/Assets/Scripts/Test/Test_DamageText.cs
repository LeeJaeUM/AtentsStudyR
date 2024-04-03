using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Test_DamageText : TestBase
{
    Player player;
    public Enemy enemy;
    public float data = 10.0f;

    public ItemCode code = ItemCode.Ruby;

    private void Start()
    {
        player = GameManager.Instance.Player;
        
    }

    protected override void OnTest1(InputAction.CallbackContext context)
    {
        player.HP += data*2;
        enemy.HP += data * 2;
    }

    protected override void OnTest2(InputAction.CallbackContext context)
    {
        // 플레이어 MP 감소
        player.Defence(data);
        enemy.Defence(data);
    }

    protected override void OnTest3(InputAction.CallbackContext context)
    {
        
    }

    protected override void OnTest4(InputAction.CallbackContext context)
    {
        // 플레이어 MP 틱당 재생
        player.HealthRegenerateByTick(3, 0.5f, 4);
        player.ManaRegenerateByTick(3, 0.5f, 4);
    }

    protected override void OnTest5(InputAction.CallbackContext context)
    {
        Factory.Instance.MakeItem(code);
    }
}
