using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BattleUIManager : MonoBehaviour
{
    [SerializeField] private BattleManager bM;
    [SerializeField] private List<TextMeshProUGUI> allText;

    /*private void ChangeStatsOnScreen(int index)
    {
        allText[0].text = bM.heros[bM.heroIndex].heroName;
        allText[1].text = bM.heros[bM.heroIndex].currentHP.ToString() + " / " + bM.heros[bM.heroIndex].maxHP.ToString();
        allText[2].text = bM.heros[bM.heroIndex].currentStamina.ToString() + " / " + bM.heros[bM.heroIndex].maxStamina.ToString();
        allText[3].text = bM.heros[bM.heroIndex].attacksDMG[0].attackName;
        allText[4].text = bM.heros[bM.heroIndex].attacksDMG[0].dmgAmount.ToString();
        allText[5].text = bM.heros[bM.heroIndex].attacksDMG[0].critChance.ToString();
        allText[6].text = bM.heros[bM.heroIndex].attacksDMG[0].staminaCost.ToString();
        allText[7].text = bM.heros[bM.heroIndex].attacksDMG[1].attackName;
        allText[8].text = bM.heros[bM.heroIndex].attacksDMG[1].dmgAmount.ToString();
        allText[9].text = bM.heros[bM.heroIndex].attacksDMG[1].critChance.ToString();
        allText[10].text = bM.heros[bM.heroIndex].attacksDMG[1].staminaCost.ToString();

    }*/


}
