using UnityEngine;
[CreateAssetMenu(fileName = "New Edible", menuName = "Edible")]
public class Edible : ScriptableObject
{
    public new string name;
    public Sprite icon;
    public PotionType edibleType;
    public BuffType buffType;
    public int effectAmount;
    
    public enum PotionType { healing, buffing }
    public enum BuffType{none, basicDMGBuff, critBuff, critChanceBuff, tankBuff}
}
