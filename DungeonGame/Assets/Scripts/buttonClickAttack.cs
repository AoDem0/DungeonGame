using UnityEngine;

public class buttonClickAttack : MonoBehaviour
{
    //public battleManager BM;
    [SerializeField]private eventsList events;
    private bool canAttack;
    private int whichEnemie;
    private int buttonIndex;

    private void OnEnable()
    {
        eventsList.OnEnemyChosen += turnOnAction;
        eventsList.OnBattleStateChange += resetButtons;
    }

    private void OnDisable()
    {
        eventsList.OnEnemyChosen -= turnOnAction;
        eventsList.OnBattleStateChange -= resetButtons;
    }
    private void resetButtons(BattleState s)
    {
        canAttack = false;
    }

    private void turnOnAction(bool can, int i)
    {
        canAttack = can;
        whichEnemie = i; 
        
    }
    public void ClickAttack()
    {

        if (canAttack && whichEnemie > 0)
        {

            events.PlayerInput(whichEnemie, buttonIndex);
            whichEnemie = 0;
        }
        
    }
}
