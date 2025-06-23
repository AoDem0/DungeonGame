using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyManager : MonoBehaviour
{
    public List<playerStats> enemies;
    [SerializeField] private List<GameObject> enemiesPrefabs;
    private int enemyIndex;
    private bool isEnemyBussy;
    private BattleManager battleMan;
    private heroManager heroMan;
    [SerializeField] private Transform player;
    void Awake()
    {
        battleMan = FindAnyObjectByType<BattleManager>();
        heroMan = FindAnyObjectByType<heroManager>();
    }

    private void OnEnable()
    {
        eventsList.OnEnemyInput += enemyResponce;
    }

    private void OnDisable()
    {
        eventsList.OnEnemyInput -= enemyResponce;
    }
    public void enemyResponce()
    {
        if (battleMan.status == BattleState.EnemyTurn && enemyIndex < enemies.Count)
        {
            allEnemyAction();
        }
    }
    private void allEnemyAction()
    {
        StartCoroutine(singleEnemyAction());
    }

    private IEnumerator singleEnemyAction()
    {
        if (isEnemyBussy == false)
        {
            isEnemyBussy = true;
            yield return new WaitForSeconds(1f);

            int ranHero = Random.Range(0, heroMan.heros.Count);
            int ranAtk = Random.Range(0, 2);


            int finalDMG = enemies[enemyIndex].attacksDMG[ranAtk].dmgAmount;
            if (Random.value < enemies[enemyIndex].attacksDMG[ranAtk].critChance)
            {
                finalDMG = Mathf.RoundToInt(finalDMG * 1.5f);
            }

            heroMan.heros[ranHero].currentHP -= finalDMG;

            if (heroMan.heros[ranHero].currentHP <= 0)
            {
                heroMan.HeroDeath(heroMan.heros[ranHero]);
            }
            Debug.Log("enemy: " + enemyIndex + " attacks player: " + ranHero + "with atk no: " + ranAtk + "with dmg: " + finalDMG);
            enemyIndex++;
            isEnemyBussy = false;
            if (enemyIndex < enemies.Count)
            {
                eventsList.OnEnemyInput();
            }
            else if (battleMan.status == BattleState.EnemyTurn)
            {
                eventsList.OnBattleStateChange(BattleState.PlayerTurn);
                enemyIndex = 0;
                // Debug.Log("Players turn");
            }

        }

    }

    public void spawnEnemies()
    {
        Vector3 playerPos = player.transform.position;
        int ranPref = Random.Range(0, enemiesPrefabs.Count);
        Vector3 spawnPos = new Vector3(playerPos.x + 2.5f, playerPos.y, playerPos.z);
        Instantiate(enemiesPrefabs[ranPref], spawnPos, Quaternion.identity);

        GameObject[] foundObjects = GameObject.FindGameObjectsWithTag("Enemie");
        foreach (GameObject found in foundObjects)
        {
            playerStats foundScript = found.GetComponent<playerStats>(); ;
            enemies.Add(foundScript);
        }
    }
    public void EnemyDeath(playerStats enemie)
    {
        enemie.gameObject.SetActive(false);
        Debug.Log("enemy death" + enemie);
        enemies.Remove(enemie);
        Destroy(enemie);
        if (enemies.Count <= 0)
        {
            eventsList.OnBattleStateChange(BattleState.Won);
        }
    }
}
