using System;
using UnityEngine;

public class eventsList : MonoBehaviour
{
    public static Action<BattleState> OnBattleStateChange;
    public static Action<int, int> OnPlayerInput;
    public static Action OnEnemyInput;

    public static Action<bool, int> OnEnemyChosen;

    public static Action OnObjectDrop;

    public void BattleStateChange(BattleState status)
    {
        OnBattleStateChange.Invoke(status);
    }
    public void PlayerInput(int enemyIndex, int atkIndex)
    {
        OnPlayerInput.Invoke(enemyIndex, atkIndex);
    }
    public void EnemyInput()
    {
        OnEnemyInput.Invoke();
    }
    public void EnemyChosen(bool canAttack, int enemyIndex)
    {
        OnEnemyChosen.Invoke(canAttack, enemyIndex);
    }
    public void ObjectDrop()
    {
        OnObjectDrop.Invoke();
    }


}
