using UnityEngine;

public class offItem : MonoBehaviour
{
    [SerializeField] private GameObject panel;

    public void closeItemView()
    {
        panel.SetActive(false);
    }
}
