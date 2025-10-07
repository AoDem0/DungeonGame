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
    public GameObject panel;

    private Item currentDroppedItem;

    void Awake()
    {
        heroMan = FindAnyObjectByType<heroManager>();
        if (panel != null)
        {
            panel.SetActive(false);
        }
    }

    private void OnEnable()
    {
        eventsList.OnObjectDrop += takeItem;
        eventsList.OnHeroSelectedForStatChange += ApplyItemToSelectedHero;
    }

    private void OnDisable()
    {
        eventsList.OnObjectDrop -= takeItem;
        eventsList.OnHeroSelectedForStatChange -= ApplyItemToSelectedHero;
    }

    public void takeItem()
    {
        int randItem = Random.Range(0, itemsList.Count);
        currentDroppedItem = itemsList[randItem];
        ShowItemUI(currentDroppedItem);

        eventsList.OnItemFoundRequestHeroSelection?.Invoke(currentDroppedItem);
    }

    private void ApplyItemToSelectedHero(playerStats selectedHero)
    {
        if (currentDroppedItem != null && selectedHero != null)
        {
            matchStat(currentDroppedItem, selectedHero);
            currentDroppedItem = null;
        }
    }

    private void matchStat(Item item, playerStats hero)
    {
        switch (item.statChangeName)
        {
            case "maxHP":
                hero.maxHP += item.statChangeAmount;
                hero.currentHP += item.statChangeAmount;
                break;
            case "currentHP":
                hero.currentHP += item.statChangeAmount;
                if (hero.currentHP > hero.maxHP) hero.currentHP = hero.maxHP;
                break;
            case "maxStamina":
                hero.maxStamina += item.statChangeAmount;
                hero.currentStamina += item.statChangeAmount;
                break;
            case "currentStamina":
                hero.currentStamina += item.statChangeAmount;
                if (hero.currentStamina > hero.maxStamina) hero.currentStamina = hero.maxStamina;
                break;
            case "atk1DMG":
                if (hero.attacksDMG.Count > 0)
                    hero.attacksDMG[0].dmgAmount += item.statChangeAmount;
                if (hero.attacksDMG.Count > 1)
                hero.attacksDMG[1].dmgAmount += item.statChangeAmount;
                break;
            case "atk2DMG":
                if (hero.attacksDMG.Count > 1)
                    hero.attacksDMG[1].dmgAmount += item.statChangeAmount;
                if (hero.attacksDMG.Count > 0)
                    hero.attacksDMG[0].dmgAmount += item.statChangeAmount;    
                break;
            case "atk1Stamina":
                if (hero.attacksDMG.Count > 0)
                    hero.attacksDMG[0].staminaCost -= item.statChangeAmount;
                break;
            case "atk2Stamina":
                if (hero.attacksDMG.Count > 1)
                    hero.attacksDMG[1].staminaCost -= item.statChangeAmount;
                break;
            default:
                Debug.LogWarning($"Nieznana nazwa statystyki do zmiany: {item.statChangeName}");
                break;
        }
        Debug.Log($"Przedmiot '{item.itemName}' zmienil statystyke '{item.statChangeName}' o {item.statChangeAmount} dla {hero.heroName}.");
    }

    private void ShowItemUI(Item item)
    {
        if (panel != null)
        {
            panel.SetActive(true);
            nameText.text = item.itemName;
            descriptionText.text = item.itemDescribtion;
        }
        else
        {
            Debug.LogError("Panel UI w ItemsManager nie został przypisany!");
        }
    }
}