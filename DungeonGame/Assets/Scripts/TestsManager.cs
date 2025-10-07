using UnityEngine;
using UnityEngine.UI;

public class TestsManager : MonoBehaviour
{
    //[SerializeField] private Button 
    [SerializeField] private bool TestMode = true;

    void Start()
    {
        if (TestMode == true)
        {
            Debug.Log("TestMode on");
        }
        else
        {
            Debug.Log("TestMode off");
        }
    }
    public void DropLoot_Test() {
        eventsList.OnObjectDrop();    
    }

}
