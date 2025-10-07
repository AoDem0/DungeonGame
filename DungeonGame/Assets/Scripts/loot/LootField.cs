using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class LootField : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private int lootFieldIndex;
    [SerializeField] private ItemSO currentItem;
    [SerializeField] private Image inFieldItem;
    void Start()
    {
        inFieldItem = GetComponentInChildren<Image>();

    }

    void OnEnable()
    {
        eventsList.OnAddLoot += FindLootInLootMan;
    }
    void OnDisable()
    {
        eventsList.OnAddLoot -= FindLootInLootMan;
    }
    private void FindLootInLootMan()
    {
        LootManager lootMan = FindFirstObjectByType<LootManager>();
        currentItem = lootMan.itemsToDrop[lootFieldIndex];
        Debug.Log("Item in field " + lootFieldIndex);
        inFieldItem.sprite = currentItem.itemSprite;
        Debug.Log("Item sprite in field " + lootFieldIndex);
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (currentItem.itemType == ItemSO.ItemType.potion & currentItem != null)
        {
            Debug.Log("To jest przedmiot do inv!");
            //deleg wziecia przedmiotu
            currentItem = null;
            Debug.Log("clean current item in field");
        }
        else if (currentItem != null)
        {
            Debug.Log("To jest przedmiot do eq!");
            //deleg wziecia przedmiotu
            currentItem = null;
            Debug.Log("clean current item in field");
        }
    }
}
