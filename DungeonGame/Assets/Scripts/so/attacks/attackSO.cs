using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Attack", menuName = "ScriptableObjects/Attack", order = 1)]
public class attackSO : ScriptableObject
{
    public string attackName;
    public enum Effect { stun, bleed, knockOut, poison }
    public List<Effect> weaponEffect;
}
