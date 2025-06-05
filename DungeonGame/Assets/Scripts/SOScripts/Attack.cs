using UnityEngine;

[CreateAssetMenu(fileName = "New Attack", menuName = "Attack")]
public class Attack : ScriptableObject
{
    public new string name;
    public Sprite icon;
    public Animation animation;
    public int baseDamage;
    public float critChance;
    public AttackType attackType;
    public TargetType targetType;
    public int usableFromPositionMin;
    public int usableFromPositionMax;
    public int hitsTargetPositionMin;
    public int hitsTargetPositionMax;
    public StatusEffect statusEffect;


    public enum AttackType { Melee, Ranged, Magic }
    public enum TargetType { SingleEnemy, EnemyRow, Self, Ally }
    public enum StatusEffect { None, Bleed, Stun, Blight }
    

}
