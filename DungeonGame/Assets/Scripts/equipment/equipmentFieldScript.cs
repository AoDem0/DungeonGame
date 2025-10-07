using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class equipmentFieldScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    [SerializeField] private int equipmentFieldIndex;
    [SerializeField] private EqFieldType eqFieldType;
    [SerializeField] private GameObject infoPanel;

    void Start()
    {
        infoPanel.SetActive(false);
    }
    private void FindItemInCharacterInventory()
    {
        Debug.Log("");
        EquipmentManager eqMan = FindFirstObjectByType<EquipmentManager>();

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("The cursor entered the selectable UI element.");
        infoPanel.SetActive(true);

    }
    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("The cursor exited the selectable UI element.");
        infoPanel.SetActive(false);

    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(this.gameObject.name + " Was Clicked.");
    }

}
