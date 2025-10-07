using UnityEngine;

[CreateAssetMenu(fileName = "PotionObject", menuName = "ScriptableObjects/PotionObject", order = 1)]
public class potionsSO : ItemSO
{
    public enum PotionType { healingPotion, staminaRegenPotion, madnessRegenPotion, sizePotion, dmgBoostPotion};
    public PotionType potionType;
    public int potionStatChangeAmount;
    public int potionDropChance;
}

