using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;
    MeshRenderer meshRenderer;
    BoxCollider boxCollider;

    private void Start()
    {
        meshRenderer = this.gameObject.GetComponent<MeshRenderer>();
        boxCollider = this.gameObject.GetComponent<BoxCollider>();
    }

    public override void Interact()
    {
        Debug.Log("Item pickup is happening");
        PickUp();
    }

    void PickUp()
    {
        Debug.Log("Picking up " + item.name);
        bool wasPickedUp = Inventory.instance.Add(item);

        if(wasPickedUp)
        {
            meshRenderer.enabled = false;
            boxCollider.enabled = false;
        }
        

        //hasInteracted = false;
    }
}
