using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleUIManager : MonoBehaviour
{

    [SerializeField] private List<TextMeshProUGUI> allText;
    [SerializeField] private Button button1;
    [SerializeField] private Button button2;

    public void UpdateUI(playerStats hero)
    {
        allText[0].text = hero.heroName;
        allText[1].text = "hp: " + hero.currentHP.ToString() + " / " + hero.maxHP.ToString();
        allText[2].text = "stamina: " + hero.currentStamina.ToString() + " / " + hero.maxStamina.ToString();
        allText[3].text = hero.attacksDMG[0].attackName;
        allText[4].text = "dmg: " + hero.attacksDMG[0].dmgAmount.ToString();
        allText[5].text = "crit%: " + hero.attacksDMG[0].critChance.ToString();
        allText[6].text = "sta: " + hero.attacksDMG[0].staminaCost.ToString();
        allText[7].text = hero.attacksDMG[1].attackName;
        allText[8].text = "dmg: " + hero.attacksDMG[1].dmgAmount.ToString();
        allText[9].text = "crit%: " + hero.attacksDMG[1].critChance.ToString();
        allText[10].text = "sta: " + hero.attacksDMG[1].staminaCost.ToString();

    }
    public void TurnOffUI()
    {
        for (int i = 0; i < allText.Count; i++)
        {
            allText[i].enabled = false;
        }
        button1.gameObject.SetActive(false);
        button2.gameObject.SetActive(false);

    }
    public void TurnOnUI()
    {
        for (int i = 0; i < allText.Count; i++)
        {
            allText[i].enabled = true;
        }
        button1.gameObject.SetActive(true);
        button2.gameObject.SetActive(true);
    }


}
