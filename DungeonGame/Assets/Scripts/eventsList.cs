using System;
using UnityEngine;

public class eventsList : MonoBehaviour
{
    public static Action<BattleState> OnBattleStateChange;
    //public static Action<GameObject> OnUIChangeForHero;
    //public static Action<string> OnPlayerAction;
    public static Action OnPlayerInput;
    public static Action OnEnemyInput;

    public void BattleStateChange(BattleState status)
    {
        OnBattleStateChange.Invoke(status);
    }
    public void PlayerInput()
    {
        OnPlayerInput.Invoke();
    }
    public void EnemyInput()
    {
        OnPlayerInput.Invoke();
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
