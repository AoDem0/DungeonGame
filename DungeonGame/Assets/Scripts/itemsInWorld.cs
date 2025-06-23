using UnityEngine;

public class itemsInWorld : MonoBehaviour
{
    private bool canClick = true;
    public void findItemInWorld()
    {
        if (canClick)
        {
            eventsList.OnObjectDrop();
            Destroy(gameObject);
        }
        
    }
}
