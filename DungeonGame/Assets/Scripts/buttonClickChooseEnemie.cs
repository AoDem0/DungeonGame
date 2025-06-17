using UnityEngine;

public class buttonClickChooseEnemie : MonoBehaviour
{
    private int index;
    private bool atack = true;
    public void ClickChoose()
    {
        index = GetComponentInParent<playerStats>().objectID;
        eventsList.OnEnemyChosen(atack ,index);
    }
}
