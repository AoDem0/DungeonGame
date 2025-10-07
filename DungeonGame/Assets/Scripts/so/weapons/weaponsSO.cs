using UnityEngine;

[CreateAssetMenu(fileName = "WeaponObject", menuName = "ScriptableObjects/WeaponObject", order = 1)]
public class weaponsSO : ItemSO
{
    public enum WeaponType { oneHand, twoHand, range }
    public WeaponType weaponType;
    
}
