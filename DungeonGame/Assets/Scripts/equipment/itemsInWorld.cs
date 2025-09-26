using UnityEngine;

public class itemsInWorld : MonoBehaviour
{
    private soundManager sounds;

    void Start()
    {
        sounds = FindAnyObjectByType<soundManager>();
    }
    private void OnEnable()
    {
        eventsList.OnBattleStateChange += ChangeClickability;
    }

    private void OnDisable()
    {
        eventsList.OnBattleStateChange -= ChangeClickability;
    }
    private bool canClick = true;
    public void findItemInWorld()
    {
        if (canClick)
        {
            sounds.Play("openChest");
            eventsList.OnObjectDrop();
            Destroy(gameObject);
        }

    }
    private void ChangeClickability(BattleState state)
    {
        if (state == BattleState.Start)
        {
            canClick = false;
        }
        else if (state == BattleState.Won)
        {
            canClick = true;
        }
    }
}
