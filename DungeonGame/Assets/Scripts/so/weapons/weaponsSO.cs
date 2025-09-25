using UnityEngine;

[CreateAssetMenu(fileName = "WeaponObject", menuName = "ScriptableObjects/WeaponObject", order = 1)]
public class weaponsSO : ScriptableObject
{
    public string weaponName;
    public Sprite weaponSprite;
    public enum WeaponType { oneHand, twoHand, range }
    public WeaponType weaponType;
    
}
