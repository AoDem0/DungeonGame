using UnityEngine;

public class offItem : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    private soundManager sounds;

    void Start()
    {
        sounds = FindAnyObjectByType<soundManager>();
    }

    public void closeItemView()
    {
        sounds.Play("UISound");
        panel.SetActive(false);
    }
}
