using UnityEngine;

public class buttonClickChooseEnemie : MonoBehaviour
{
    public int index;
    private bool atack = true;
    public void ClickChoose()
    {
        eventsList.OnEnemyChosen(atack ,index);
    }
}
