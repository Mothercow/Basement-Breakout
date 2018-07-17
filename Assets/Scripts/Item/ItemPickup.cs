using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;
    MeshRenderer meshRenderer;
    BoxCollider boxCollider;

    public static bool hasPaperclip = false;
    public static bool hasPaperclip2 = false;

    private void Start()
    {
        meshRenderer = this.gameObject.GetComponent<MeshRenderer>();
        boxCollider = this.gameObject.GetComponent<BoxCollider>();
    }

    private void Update()
    {
        Debug.Log(hasPaperclip);
        Debug.Log(hasPaperclip2);
    }

    public override void Interact()
    {
        GetComponent<DialogueTrigger>().TriggerDialogue();
        Debug.Log("Item pickup is happening");
        
        PickUp();
    }

    void PickUp()
    {
        Debug.Log("Picking up " + item.name);
        if(item.name == "Paperclip")
        {
            hasPaperclip = true;
        }

        if (item.name == "Paperclip2")
        {
            hasPaperclip2 = true;
        }
        bool wasPickedUp = Inventory.instance.Add(item);

        

        if(wasPickedUp)
        {
            if(this.gameObject.tag == "MultipleObjects" )
            {
                foreach (Transform child in transform)
                {
                    child.GetComponent<MeshRenderer>().enabled = false;
                }
            }
            else
            {
                this.gameObject.SetActive(false);
                //meshRenderer.enabled = false;
                //boxCollider.enabled = false;
            }
            
        }

        //hasInteracted = false;
    }
}
