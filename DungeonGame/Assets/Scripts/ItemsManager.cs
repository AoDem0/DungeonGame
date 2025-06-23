using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
[System.Serializable]
public class Item
{
    public string itemName;
    public Sprite icon;
    public string statChangeName;
    public int statChangeAmount;
    public string itemDescribtion;
}
public class ItemsManager : MonoBehaviour
{
    public List<Item> itemsList;
    private heroManager heroMan;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private GameObject panel;

    void Awake()
    {
        heroMan = FindAnyObjectByType<heroManager>();
        panel.SetActive(false);
    }
    private void OnEnable()
    {
        eventsList.OnObjectDrop += takeItem;
    }

    private void OnDisable()
    {
        eventsList.OnObjectDrop -= takeItem;
    }
    public void takeItem()
    {

        int randItem = Random.Range(0, itemsList.Count);
        Item targetItem = itemsList[randItem];
        ShowItemUI(targetItem);
        int ranHero = Random.Range(0, heroMan.heros.Count);
        playerStats targetHero = heroMan.heros[ranHero];
        matchStat(targetItem, targetHero);

    }
    private void matchStat(Item item, playerStats hero)
    {
        switch (item.statChangeName)
        {
            case "maxHP":
                hero.maxHP += item.statChangeAmount;
                break;
            case "currentHP":
                hero.currentHP += item.statChangeAmount;
                break;
            case "maxStamina":
                hero.maxStamina += item.statChangeAmount;
                break;
            case "atk1DMG":
                hero.attacksDMG[0].dmgAmount += item.statChangeAmount;
                break;
            case "atk2DMG":
                hero.attacksDMG[1].dmgAmount += item.statChangeAmount;
                break;
            case "atk1Stamina":
                hero.attacksDMG[0].staminaCost += item.statChangeAmount;
                break;
            case "atk2Stamina":
                hero.attacksDMG[1].staminaCost += item.statChangeAmount;
                break;
            default:
                break;
        }
    }
    private void ShowItemUI(Item item)
    {
        panel.SetActive(true);
        nameText.text = item.itemName;
        descriptionText.text = item.itemDescribtion;
    }
}
