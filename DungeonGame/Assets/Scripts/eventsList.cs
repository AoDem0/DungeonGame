using System;
using UnityEngine;

public class eventsList : MonoBehaviour
{
    public static Action<BattleState> OnBattleStateChange;
    public static Action<int, int> OnPlayerInput;
    public static Action OnEnemyInput;

    public static Action<bool, int> OnEnemyChosen;

    /*public static Action<int, int> OnEnemieHit;
    public static Action<int, int> OnPlayerHit;*/

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
 /*   public void PlayerHit(int attackID, int whichPlayer)
    {
        OnPlayerHit.Invoke(attackID, whichPlayer);
    }
    public void EnemyHit(int attackID, int whichEnemie) //maybe niepotrzebne
    {
        OnEnemieHit.Invoke(attackID, whichEnemie);
    }
*/
}
