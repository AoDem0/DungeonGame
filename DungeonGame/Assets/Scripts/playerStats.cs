using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class BasicAttacks
{
    public string attackName;
    public int dmgAmount;
    public float critChance;
    public int staminaCost;
}
public class playerStats : MonoBehaviour
{
    public string heroName;
    public int maxHP;
    public int currentHP;
    public int maxStamina;
    public int currentStamina;

    public List<BasicAttacks> attacksDMG;
    public int objectID;

}
