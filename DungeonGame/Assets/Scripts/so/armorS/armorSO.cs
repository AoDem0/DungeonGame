using UnityEngine;

[CreateAssetMenu(fileName = "ArmorObject", menuName = "ScriptableObjects/ArmorObject", order = 1)]
public class armorSO : ScriptableObject
{
    public string armorName;
    public Sprite armorSprite;
    public int armorDMGReductionAmount;
}
