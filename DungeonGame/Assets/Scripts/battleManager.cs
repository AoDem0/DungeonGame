using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.PlayerLoop;

public enum BattleState { Start, PlayerTurn, EnemyTurn, Won, Lost }

public class BattleManager : MonoBehaviour
{
    public BattleState status;
    [Header("text components")]
    public TextMeshProUGUI statusT;
    public TextMeshProUGUI hp1;
    public TextMeshProUGUI hp2;
    public TextMeshProUGUI hp3;
    public TextMeshProUGUI hp4;
    [Header("enemies components")]
    public List<playerStats> enemies;
    public int enemyIndex;
    public bool isEnemyBussy;
    [Header("heros components")]
    public List<playerStats> heros;
    public int heroIndex;


    void Start()
    {
        status = BattleState.PlayerTurn;
    }
    void Update()
    {
        statusT.text = $"State: {status}";
        hp1.text = enemies[0].currentHP.ToString() + "/" + enemies[0].maxHP.ToString();
        hp2.text = heros[0].currentHP.ToString() + "/" + heros[0].maxHP.ToString();
        hp3.text = heros[1].currentHP.ToString() + "/" + heros[1].maxHP.ToString();
        hp4.text = enemies[1].currentHP.ToString() + "/" + enemies[1].maxHP.ToString();
    }
    private void OnEnable()
    {
        eventsList.OnBattleStateChange += ChangeState;
        eventsList.OnPlayerInput += PlayerResponse;
        eventsList.OnEnemyInput += allEnemyAction;
    }

    private void OnDisable()
    {
        eventsList.OnBattleStateChange -= ChangeState;
        eventsList.OnPlayerInput -= PlayerResponse;
        eventsList.OnEnemyInput -= allEnemyAction;
    }

    private void ChangeState(BattleState battleState)
    {
        status = battleState;
        enemyResponce();
    }

    private void PlayerResponse(int index, int atkI)
    {
        if (status == BattleState.PlayerTurn && heroIndex < heros.Count && index > 0)
        {
            // Debug.Log("player turn yay");
            PlayerAction(heroIndex, index, atkI);
            heroIndex++;

            if (heroIndex >= heros.Count)
            {
                eventsList.OnBattleStateChange(BattleState.EnemyTurn);
                heroIndex = 0;
                //Debug.Log("Enemy turn");
            }
        }

    }

    private void PlayerAction(int HI, int EI, int atk)
    {
        Debug.Log("player: " + HI + " attacks enemie: " + (EI - 1) + " with attack no: " + atk);
        enemies[EI - 1].currentHP -= heros[HI].attacksDMG[atk];
    }
    
    private void enemyResponce()
    {
        if (status == BattleState.EnemyTurn && enemyIndex < enemies.Count)
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


            int ranHero = Random.Range(0, heros.Count);
            int ranAtk = Random.Range(0, 2);
            heros[ranHero].currentHP -= enemies[enemyIndex].attacksDMG[ranAtk];
            Debug.Log("enemy: " + enemyIndex + " attacks player: " + ranHero + "with atk no: " + ranAtk);
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
