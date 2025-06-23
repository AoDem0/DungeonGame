using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum BattleState { Start, PlayerTurn, EnemyTurn, Won, Lost }

public class BattleManager : MonoBehaviour
{
    public BattleState status;
    [SerializeField] private TextMeshProUGUI statusT;
    [SerializeField] private enemyManager enemyMan;
    [SerializeField] private heroManager heroMan;
    private BattleUIManager battleUI;


    void Awake()
    {
        enemyMan = FindAnyObjectByType<enemyManager>();
        heroMan = FindAnyObjectByType<heroManager>();
        battleUI = FindAnyObjectByType<BattleUIManager>();
        battleUI.TurnOffUI();
    }
    void Update()
    {
        statusT.text = $"State: {status}";
    }
    private void OnEnable()
    {
        eventsList.OnBattleStateChange += ChangeState;
    }

    private void OnDisable()
    {
        eventsList.OnBattleStateChange -= ChangeState;
    }

    private void ChangeState(BattleState battleState)
    {
        status = battleState;
        switch (battleState)
        {
            case BattleState.Start:
                battleStart();
                break;
            case BattleState.EnemyTurn:
                battleUI.TurnOffUI();
                enemyMan.enemyResponce();
                break;
            case BattleState.PlayerTurn:
                battleUI.TurnOnUI();
                break;
            case BattleState.Won:
                battleWon();
                break;
            case BattleState.Lost:
                battleLost();
                break;
            default:
                break;
        }
    }

    private void battleStart()
    {
        heroMan.changeMovement(0);
        battleUI.TurnOnUI();
        battleUI.UpdateUI(heroMan.heros[0]);
        enemyMan.spawnEnemies();
        eventsList.OnBattleStateChange(BattleState.PlayerTurn);
    }
    private void battleLost()
    {
        heroMan.changeMovement(5);
        battleUI.TurnOffUI();

    }
    private void battleWon()
    {
        heroMan.changeMovement(5);
        GameObject enemieGrupa = GameObject.FindWithTag("enemieGrupa");
        Destroy(enemieGrupa);
        battleUI.TurnOffUI();
        heroMan.resetStamina();
    }
    
    

}
