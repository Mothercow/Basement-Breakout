using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;

    public override void Interact()
    {
        Debug.Log("Item pickup is happening");
        GetComponent<DialogueTrigger>().TriggerDialogue();
        PickUp();
    }

    void PickUp()
    {
        Debug.Log("Picking up " + item.name);
        bool wasPickedUp = Inventory.instance.Add(item);

        if(wasPickedUp)
        {
            
           Destroy(gameObject);
        }
        

        //hasInteracted = false;
    }
}
