using UnityEngine;

[CreateAssetMenu(fileName = "PotionObject", menuName = "ScriptableObjects/PotionObject", order = 1)]
public class potionsSO : ScriptableObject
{
    public string potionName;
    public Sprite potionSprite;
    public enum PotionType { healingPotion, staminaRegenPotion, madnessRegenPotion, sizePotion, dmgBoostPotion};
    public PotionType potionType;
    public int potionStatChangeAmount;
    public int potionDropChance;
}

