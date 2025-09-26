using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;


public class HeroSelectionUI : MonoBehaviour
{
    [SerializeField] private GameObject selectionPanel;
    [SerializeField] private GameObject heroSelectionButtonPrefab;
    [SerializeField] private Transform buttonsParent;

    private heroManager heroMan;
    private ItemsManager itemsMan;
    private Item itemToAssign;

    void Awake()
    {
        heroMan = FindAnyObjectByType<heroManager>();
        itemsMan = FindAnyObjectByType<ItemsManager>();
        selectionPanel.SetActive(false);
    }

    private void OnEnable()
    {
        eventsList.OnItemFoundRequestHeroSelection += ShowHeroSelection;
    }

    private void OnDisable()
    {
        eventsList.OnItemFoundRequestHeroSelection -= ShowHeroSelection;
    }

    private void ShowHeroSelection(Item item)
    {
        itemToAssign = item;
        selectionPanel.SetActive(true);
        if (itemsMan != null && itemsMan.panel != null) 
        {
            //itemsMan.panel.SetActive(false);
        }
        foreach (Transform child in buttonsParent)
        {
            Destroy(child.gameObject);
        }

        if (heroMan != null && heroMan.heros != null)
        {
            foreach (playerStats hero in heroMan.heros)
            {
                
                if (hero == null || hero.gameObject == null) continue; 

                GameObject buttonGO = Instantiate(heroSelectionButtonPrefab, buttonsParent);
                Button button = buttonGO.GetComponent<Button>();
                TextMeshProUGUI buttonText = buttonGO.GetComponentInChildren<TextMeshProUGUI>();

                if (buttonText != null)
                {
                    buttonText.text = hero.heroName;
                }
                
                
                button.onClick.AddListener(() => SelectHero(hero));
            }
        }
    }

    public void SelectHero(playerStats selectedHero)
    {
        eventsList.OnHeroSelectedForStatChange?.Invoke(selectedHero);
        selectionPanel.SetActive(false);
        itemToAssign = null;
    }
}