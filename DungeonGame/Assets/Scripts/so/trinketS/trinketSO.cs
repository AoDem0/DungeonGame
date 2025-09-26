using UnityEngine;

[CreateAssetMenu(fileName = "TrinketObject", menuName = "ScriptableObjects/TrinketObject", order = 1)]
public class trinketSO : ScriptableObject
{
    public string trinketName;
    public Sprite trinketSprite;
    [TextArea(3, 10)]
    public string trinketDescription;
}
