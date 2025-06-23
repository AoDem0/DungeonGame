using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BattleUIManager : MonoBehaviour
{

    [SerializeField] private List<TextMeshProUGUI> allText;

    public void UpdateUI(playerStats hero)
    {
        allText[0].text = hero.heroName;
        allText[1].text = hero.currentHP.ToString() + " / " + hero.maxHP.ToString();
        allText[2].text = hero.currentStamina.ToString() + " / " + hero.maxStamina.ToString();
        allText[3].text = hero.attacksDMG[0].attackName;
        allText[4].text = hero.attacksDMG[0].dmgAmount.ToString();
        allText[5].text = hero.attacksDMG[0].critChance.ToString();
        allText[6].text = hero.attacksDMG[0].staminaCost.ToString();
        allText[7].text = hero.attacksDMG[1].attackName;
        allText[8].text = hero.attacksDMG[1].dmgAmount.ToString();
        allText[9].text = hero.attacksDMG[1].critChance.ToString();
        allText[10].text = hero.attacksDMG[1].staminaCost.ToString();

    }
    public void TurnOffUI()
    {
        for (int i = 0; i < allText.Count; i++)
        {
            allText[i].enabled = false;
        }
    }
    public void TurnOnUI()
    {
        for (int i = 0; i < allText.Count; i++)
        {
            allText[i].enabled = true;
        }
    }


}
