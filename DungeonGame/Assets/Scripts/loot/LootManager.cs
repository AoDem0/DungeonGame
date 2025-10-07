using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootManager : MonoBehaviour
{
    [SerializeField]private List<ItemSO> allGameItems; //all items in game
    public List<ItemSO> itemsToDrop = new List<ItemSO>(); //list of items dropped from chest/fight
    [SerializeField] private GameObject lootPanel; // chest/fight loot ui
    [SerializeField] private int lootMaxCapacity = 6; // how many items drops from chests
    [SerializeField] private bool isDoneWithRandomising;



    void Start()
    {
        lootPanel.SetActive(false);
    }

    void OnEnable()
    {
        eventsList.OnLootHideUI += HideUI;
        eventsList.OnObjectDrop += DropLoot;

    }
    void OnDisable()
    {
        eventsList.OnLootHideUI -= HideUI;
        eventsList.OnObjectDrop -= DropLoot;
    }
    private void DropLoot()
    {

        RandomiseLoot();
        //ShowUI();
    }


    private void RandomiseLoot()
    {
        Debug.Log("Strat randomizing");
        int lootCapacity = Random.Range(0, lootMaxCapacity);
        if (allGameItems != null & allGameItems.Count > 0)
        {
            for (int i = 0; i < lootCapacity; i++)
            {
                itemsToDrop.Add(allGameItems[Random.Range(0, allGameItems.Count)]);
                Debug.Log("Added random loot. Current loot count: " + (i + 1));
            }
            Debug.Log("Added all items");
            eventsList.OnAddLoot(); //deleg to loot field
            Debug.Log("Added loot");
        }
        else
    {
        Debug.LogWarning("⚠️ allGameItems is null or empty, no loot added!");
    }
        

    }
    private void UpdateLootList(ItemSO newItem)
    {
        // deleg jakis od invMan i eqMan
        
        itemsToDrop.Add(newItem);
        eventsList.OnAddLoot(); // to refresh loot in loot fields
        Debug.Log("Updatet loot list");
    }

    private void ShowUI()
    {
        if (lootPanel != null)
        {
            lootPanel.SetActive(true);
            Debug.Log("Show loot ui");            
        }

    }

    private void HideUI()
    {
        lootPanel.SetActive(false);
        Debug.Log("Hide loot ui");
    }
    

}
