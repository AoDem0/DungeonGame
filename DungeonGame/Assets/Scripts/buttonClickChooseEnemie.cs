using UnityEngine;

public class buttonClickChooseEnemie : MonoBehaviour
{
    private int index;
    private bool atack = true;
    private soundManager sounds;

    void Start()
    {
        sounds = FindAnyObjectByType<soundManager>();
    }
    public void ClickChoose()
    {
        sounds.Play("UISound");
        index = GetComponentInParent<playerStats>().objectID;
        eventsList.OnEnemyChosen(atack, index);
    }
}
