using UnityEngine;

public class buttonClickChooseEnemie : MonoBehaviour
{
    private int index;
    [SerializeField]private bool atack = true;
    private soundManager sounds;

    void Start()
    {
        sounds = FindAnyObjectByType<soundManager>();
        atack = true;
    }
    public void ClickChoose()
    {
        Debug.Log("clicked enemie");
        sounds.Play("UISound");
        index = GetComponentInParent<playerStats>().objectID;
        eventsList.OnEnemyChosen(atack, index);
    }
}
