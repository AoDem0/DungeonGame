using UnityEngine;

public class buttonClickAttack : MonoBehaviour
{
    //public battleManager BM;
    public eventsList events;
    public void ClickAttack()
    {
        // BM.PlayerAttack();
        events.PlayerInput();
    }
}
