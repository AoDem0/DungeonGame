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
        /*hp1.text = enemies[0].currentHP.ToString() + "/" + enemies[0].maxHP.ToString();
        hp2.text = heros[0].currentHP.ToString() + "/" + heros[0].maxHP.ToString();
        hp3.text = heros[1].currentHP.ToString() + "/" + heros[1].maxHP.ToString();
        hp4.text = enemies[1].currentHP.ToString() + "/" + enemies[1].maxHP.ToString();*/
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
        //zrobic switch?
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

            if (heroIndex >= heros.Count && status == BattleState.PlayerTurn)
            {
                eventsList.OnBattleStateChange(BattleState.EnemyTurn);
                heroIndex = 0;
                //Debug.Log("Enemy turn");
            }
        }

    }

    private void PlayerAction(int HI, int EI, int atk)
    {
        Debug.Log("player: " + HI + " attacks enemie: " + EI + " with attack no: " + atk);
        playerStats target = enemies.Find(e => e.GetComponent<playerStats>().objectID == EI);
        target.currentHP -= heros[HI].attacksDMG[atk];
        if (target.currentHP <= 0)
        {
            Die(target, "enemy");
        }
    }

    private void enemyResponce()
    {
        if (status == BattleState.EnemyTurn && enemyIndex < enemies.Count)
        {
            allEnemyAction();
        }
    }
    private void allEnemyAction()
    {
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
            if (heros[ranHero].currentHP <= 0)
            {
                Die(heros[ranHero], "hero");
            }
            Debug.Log("enemy: " + enemyIndex + " attacks player: " + ranHero + "with atk no: " + ranAtk);
            enemyIndex++;
            isEnemyBussy = false;
            if (enemyIndex < enemies.Count)
            {
                eventsList.OnEnemyInput();
            }
            else if(status == BattleState.EnemyTurn)
            {
                eventsList.OnBattleStateChange(BattleState.PlayerTurn);
                enemyIndex = 0;
                // Debug.Log("Players turn");
            }

        }

    }
    private void Die(playerStats obj, string objType)
    {
        obj.gameObject.SetActive(false);
        if (objType == "enemy")
        {
            enemies.Remove(obj);
            checkTeamCount();
        }
        else if (objType == "hero")
        {
            heros.Remove(obj);
            checkTeamCount();
        }
        Debug.Log("Enemie died");
    }

    private void checkTeamCount()
    {
        if (enemies.Count <= 0)
        {
            eventsList.OnBattleStateChange(BattleState.Won);
        }
        else if (heros.Count <= 0)
        {
            eventsList.OnBattleStateChange(BattleState.Lost);
        }
    }
    

}
