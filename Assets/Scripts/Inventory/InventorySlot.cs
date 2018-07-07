using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Image icon;

    Item item;

    private bool pointerDown = false;
    private bool pointerUp = false;
    private float pointerDownTimer = 0;

    [SerializeField]
    private float requiredHoldTime;

    public UnityEvent onHoldButton;
    public UnityEvent onClickButton;

    public GameObject InspectButton;

    public void AddItem (Item newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null; 
        icon.enabled = false;
    }

    public void OnRemove()
    {
        Inventory.instance.Remove(item);
    }

    public void UseItem()
    {
        if (item != null)
        {
            InspectButton.SetActive(true);
            item.Use();
        }
        else
        {

        }
    }

    public void HoldItem()
    {
        if (item != null)
        {
            //InspectButton.SetActive(true);
            item.Hold();
        }
        else
        {

        }
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDown = true;
        //Debug.Log("OnPointerDown");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pointerUp = true;
        //Debug.Log("OnPointerUp");
    }

    private void Update()
    {

        if (pointerDown == true)
        {
            pointerDownTimer += Time.deltaTime;
            if (pointerDownTimer >= requiredHoldTime)
            {
                if (onHoldButton != null)
                {
                    onHoldButton.Invoke();
                }

                Reset();
            }
           
        }
        if (pointerUp == true)
        {
            if (pointerDownTimer < requiredHoldTime)
            {
                if (onClickButton != null)
                {
                    onClickButton.Invoke();
                }

                Reset();
            }
        }
        
    }

    private void Reset()
    {
        pointerDown = false;
        pointerUp = false;
        pointerDownTimer = 0;
       
    }

}
