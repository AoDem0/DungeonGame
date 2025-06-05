using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAction : MonoBehaviour
{
    public List<playerStats> enemies;
    public BattleManager battleMan;
    public int enemyIndex;
    public bool isEnemyBussy;
    private void OnEnable()
    {
        eventsList.OnBattleStateChange += enemyResponce;
        eventsList.OnEnemyInput += allEnemyAction;
    }

    private void OnDisable()
    {
        eventsList.OnBattleStateChange -= enemyResponce;
        eventsList.OnEnemyInput -= allEnemyAction;
    }


    private void enemyResponce(BattleState stat)
    {
        if (stat == BattleState.EnemyTurn && enemyIndex < enemies.Count)
        {
            allEnemyAction();
        }
    }
    private void allEnemyAction() {
        StartCoroutine(singleEnemyAction());
    }

    IEnumerator singleEnemyAction()
    {
        if (isEnemyBussy == false)
        {
            isEnemyBussy = true;
            yield return new WaitForSeconds(1f);
            
            Debug.Log("enemy " + enemyIndex + " attacks");
            enemyIndex++;
            isEnemyBussy = false;
            if (enemyIndex < enemies.Count)
            {
                eventsList.OnEnemyInput();
            }
            else
            {
                eventsList.OnBattleStateChange(BattleState.PlayerTurn);
                enemyIndex = 0;
               // Debug.Log("Players turn");
            }
            
        }
        
    }
}
