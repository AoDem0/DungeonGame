using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Item
{
    public string itemName;
    public string statChange;
    public int statChangeAmount;
    
}
public class ItemsManager : MonoBehaviour
{
    public List<Item> itemsList;
    private heroManager heroMan;

    void Awake()
    {
        heroMan = FindAnyObjectByType<heroManager>();
    }
    public void takeItem(string name)
    {
        Item targetItem = itemsList.Find(e => e.itemName == name);
        int ranHero = Random.Range(0, heroMan.heros.Count);
        

    }
}
