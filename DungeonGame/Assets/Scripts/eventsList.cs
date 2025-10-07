using System;
using UnityEngine;

public class eventsList : MonoBehaviour
{
    public static Action<BattleState> OnBattleStateChange;
    public static Action<int, int> OnPlayerInput;
    public static Action OnEnemyInput;
    public static Action<bool, int> OnEnemyChosen;
    public static Action OnObjectDrop;
    public static Action<Item> OnItemFoundRequestHeroSelection;
    public static Action<playerStats> OnHeroSelectedForStatChange;
    public static Action<armorSO> OnEquipArmor;
    public static Action<weaponsSO> OnEquipWeapon;
    public static Action<trinketSO, int> OnEquipTrinket;
    public static Action OnLootUIShow;
    public static Action OnLootHideUI;
    public static Action OnAddLoot;
    public static Action<ItemSO> OnUpgradeLoot;

    //-----------------Battle Events------------------------------

    public void BattleStateChange(BattleState status)
    {
        OnBattleStateChange?.Invoke(status);
    }
    public void PlayerInput(int enemyIndex, int atkIndex)
    {
        OnPlayerInput?.Invoke(enemyIndex, atkIndex);
    }
    public void EnemyInput()
    {
        OnEnemyInput?.Invoke();
    }
    public void EnemyChosen(bool canAttack, int enemyIndex)
    {
        OnEnemyChosen?.Invoke(canAttack, enemyIndex);
    }

    public void HeroSelectedForStatChange(playerStats selectedHero)
    {
        OnHeroSelectedForStatChange?.Invoke(selectedHero);
    }

    public void ItemFoundRequestHeroSelection(Item item)
    {
        OnItemFoundRequestHeroSelection?.Invoke(item);
    }


    //--------------EquipmentMAnager events-------------------------------------
    public void EquipArmor(armorSO armor)//dodac wiecej argumentow potem
    {
        OnEquipArmor?.Invoke(armor);
    }
    public void EquipWeapon(weaponsSO weapon)
    {
        OnEquipWeapon?.Invoke(weapon);
    }
    public void EquipTrinket(trinketSO trinket, int fieldIndex)
    {
        OnEquipTrinket?.Invoke(trinket, fieldIndex);
    }



    //--------------Loot events---------------------------------------------------
    public void ObjectDrop()//zmiana na GetLOOt i ShowLootUI
    {
        OnObjectDrop?.Invoke();
    }
    public void LootShowUI()//obv
    {
        OnLootUIShow?.Invoke();
    }
    public void LootHideUI() //obv
    {
        OnLootHideUI?.Invoke();
    }
    public void AddLoot()// add loot in loot field
    {
        OnAddLoot?.Invoke();
    }
    public void UpgradeLoot(ItemSO item)// remove item from your inv and add to loot field
    {
        OnUpgradeLoot?.Invoke(item);
    }

}