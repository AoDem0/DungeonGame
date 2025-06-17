using TMPro;
using UnityEngine;

public class hpTextScript : MonoBehaviour
{
    [SerializeField]private playerStats stats;
    [SerializeField]private TextMeshProUGUI text;
    
    // Update is called once per frame
    void Update()
    {
        text.text = stats.currentHP.ToString() + " / " + stats.maxHP.ToString();
    }
}
