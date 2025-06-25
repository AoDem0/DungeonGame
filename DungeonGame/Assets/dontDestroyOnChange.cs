using UnityEngine;

public class dontDestroyOnChange : MonoBehaviour
{
    void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
}
