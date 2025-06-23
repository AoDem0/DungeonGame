using System.Collections.Generic;
using UnityEngine;

public class heroManager : MonoBehaviour
{
    public List<playerStats> heros;
    private int heroIndex;
    private playerMovement movement;
    private BattleManager battleMan;
    private enemyManager enemyMan;

    private void Awake()
    {
        movement = FindAnyObjectByType<playerMovement>();
        battleMan = FindAnyObjectByType<BattleManager>();
        enemyMan = FindAnyObjectByType<enemyManager>();
    }

    

    private void OnEnable()
    {
        eventsList.OnPlayerInput += PlayerResponse;
    }

    private void OnDisable()
    {
        eventsList.OnPlayerInput -= PlayerResponse;
    }
    private void PlayerResponse(int index, int atkI)
    {
        if (battleMan.status == BattleState.PlayerTurn && heroIndex < heros.Count && index > 0)
        {
            // Debug.Log("player turn yay");
            PlayerAction(heroIndex, index, atkI);
            heroIndex++;

            if (heroIndex >= heros.Count && battleMan.status == BattleState.PlayerTurn)
            {
                eventsList.OnBattleStateChange(BattleState.EnemyTurn);
                heroIndex = 0;
                //Debug.Log("Enemy turn");
            }
        }

    }

    private void PlayerAction(int HI, int EI, int atk)
    {

        playerStats target = enemyMan.enemies.Find(e => e.GetComponent<playerStats>().objectID == EI);


        int finalDMG = heros[HI].attacksDMG[atk].dmgAmount;

        if (Random.value < heros[HI].attacksDMG[atk].critChance)
        {
            finalDMG = Mathf.RoundToInt(finalDMG * 1.5f);
        }
        heros[HI].currentStamina -= heros[HI].attacksDMG[atk].staminaCost;
        if (heros[HI].currentStamina > 0)
        {
            target.currentHP -= finalDMG;
        }
        else
        {
            target.currentHP -= 1;
        }


        Debug.Log("player: " + HI + " attacks enemie: " + EI + " with attack no: " + atk + "with dmg: " + finalDMG + " Stamina cost: " + heros[HI].attacksDMG[atk].staminaCost);

        if (target.currentHP <= 0)
        {
            enemyMan.EnemyDeath(target);
        }
    }
    public void HeroDeath(playerStats hero)
    {
        hero.gameObject.SetActive(false);
        Debug.Log("hero dezth" + hero);
        heros.Remove(hero);
        Destroy(hero);
        if (heros.Count <= 0)
        {
            eventsList.OnBattleStateChange(BattleState.Lost);
        }
    }
    public void changeMovement(int newSpeed)
    {
        movement.speed = newSpeed;
    }
    public void resetStamina()
    {
        foreach (playerStats hero in heros)
        {
            hero.currentStamina = hero.maxStamina;
        }
    }
}
