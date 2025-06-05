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
    public TextMeshProUGUI statusT;
    public TextMeshProUGUI hp1;
    public TextMeshProUGUI hp2;
    public TextMeshProUGUI hp3;
    public playerStats enemy;
    public List<playerStats> heros;

    void Start()
    {
        status = BattleState.PlayerTurn;
    }
    void Update()
    {
        statusT.text = $"State: {status}";
        hp1.text = $"{enemy.currentHP}";
        hp2.text = heros[0].currentHP.ToString();
        hp3.text = heros[1].currentHP.ToString();
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
    }

}
