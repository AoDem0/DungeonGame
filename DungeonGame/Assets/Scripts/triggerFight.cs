using UnityEngine;

public class triggerFight : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            eventsList.OnBattleStateChange(BattleState.Start);
            Destroy(gameObject);
        }
    }
}
