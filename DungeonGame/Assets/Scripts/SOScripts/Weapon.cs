using UnityEngine;

[CreateAssetMenu(fileName = "New weapon", menuName = "Weapon")]
public class Weapon : ScriptableObject
{
  public new string name;
    public Sprite icon;
    public WeaponType weaponType;
    public int weaponCritChance;
    public int weaponCritDmg;
    public int weaponMinBasicDmg;
    public int weaponMaxBasicDmg;
     public enum WeaponType { Melee, Ranged, Magic }
}
