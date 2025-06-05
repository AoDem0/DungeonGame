using System.Collections.Generic;
using UnityEngine;

public class playerAction : MonoBehaviour
{
    public List<playerStats> heros;
    public BattleManager battleMan;
    public int heroIndex;
    private void OnEnable()
    {
        eventsList.OnPlayerInput += PlayerResponse;
    }

    private void OnDisable()
    {
        eventsList.OnPlayerInput -= PlayerResponse;
    }
    private void PlayerResponse()
    {
        if (battleMan.status == BattleState.PlayerTurn && heroIndex < heros.Count)
        {
           // Debug.Log("player turn yay");
            PlayerAction(heroIndex);
            heroIndex++;

            if (heroIndex >= heros.Count)
            {
                eventsList.OnBattleStateChange(BattleState.EnemyTurn);
                heroIndex = 0;
                //Debug.Log("Enemy turn");
            }
        }

    }
    
    private void PlayerAction(int i)
    {
        Debug.Log("player " + i + " attacks");
    }

}
