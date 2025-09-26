using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public enum EqFieldType { armor, weapon, trinket }
public enum CurrentHero{ Alice, WhiteRabbit, MadHatter}
[System.Serializable]

public class HeroEquipment
{
    public CurrentHero hero;
    public armorSO armor;    
    public weaponsSO weapon;
    public List<trinketSO> trinkets;


}

public class EquipmentManager : MonoBehaviour
{

    public List<HeroEquipment> allHeroEquipment;
    [SerializeField] private CurrentHero currentHero;
    [SerializeField] private armorSO newArmor;


    void Start()
    {
        //Debug.Log(allHeroEquipment[0].weapon.weaponName);
        equipArmor(newArmor);

    }

    private void equipArmor(armorSO armorToEquip)
    {
        HeroEquipment heroEq = allHeroEquipment.Find(eq => eq.hero == currentHero);

        if (heroEq != null)
        {
            heroEq.armor = armorToEquip;
            Debug.Log($"{currentHero} dostał armor: {armorToEquip.name}");
        }
        else
        {
            Debug.LogWarning($"Nie znaleziono bohatera {currentHero} w allHeroEquipment!");
        }
    }
    private void equipWeapon(weaponsSO weaponToEquip)
    {
        HeroEquipment heroEq = allHeroEquipment.Find(eq => eq.hero == currentHero);

        if (heroEq != null)
        {
            heroEq.weapon = weaponToEquip;
            Debug.Log($"{currentHero} dostał armor: {weaponToEquip.name}");
        }
        else
        {
            Debug.LogWarning($"Nie znaleziono bohatera {currentHero} w allHeroEquipment!");
        }
    }
    private void equipTrinket(trinketSO trinketToEquip, int whichTrinketField)
    {
        HeroEquipment heroEq = allHeroEquipment.Find(eq => eq.hero == currentHero);

        if (heroEq != null & whichTrinketField <= heroEq.trinkets.Count)
        {
            heroEq.trinkets[whichTrinketField] = trinketToEquip;
            Debug.Log($"{currentHero} dostał armor: {trinketToEquip.name}");
        }
        else
        {
            Debug.LogWarning($"Nie znaleziono bohatera {currentHero} w allHeroEquipment!");
        }
    }
    

}
