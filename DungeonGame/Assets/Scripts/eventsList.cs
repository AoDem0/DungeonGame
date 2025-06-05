using System;
using UnityEngine;

public class eventsList : MonoBehaviour
{
    public static Action<BattleState> OnBattleStateChange;
    //public static Action<GameObject> OnUIChangeForHero;
    //public static Action<string> OnPlayerAction;
    public static Action<int> OnPlayerInput;
    public static Action OnEnemyInput;

    public static Action<bool, int> OnEnemyChosen;

    public void BattleStateChange(BattleState status)
    {
        OnBattleStateChange.Invoke(status);
    }
    public void PlayerInput(int index)
    {
        OnPlayerInput.Invoke(index);
    }
    public void EnemyInput()
    {
        OnEnemyInput.Invoke();
    }
    public void EnemyChosen(bool canAttack,int enemyIndex)
    {
        OnEnemyChosen.Invoke(canAttack, enemyIndex);
    }

    
    /*public void UIChangeForHero(GameObject hero)
    {
        OnUIChangeForHero.Invoke(hero);
    }
    public void PlayerAttack(string actionName)
    {
        OnPlayerAction.Invoke(actionName);
    }*/

}
