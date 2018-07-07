using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    public GameObject inspectGameObject = null;
    public bool isDefaultItem = false;
    public int distance = 20;
    public int itemIndex;
    public bool hasSelectedItem = false;
    public static bool isInspecting = false;


    Inventory inventory;
    GameObject myGameObject;
    

   /* void Start()
    {
        inventory = Inventory.instance;
    }*/

    public virtual void Use()
    {
        Inspect();
    }

    public virtual void Hold()
    {
        //Inspect();
    }

    public  void Inspect()
    {

        if (isInspecting == false)
        {
            myGameObject = Instantiate(inspectGameObject, Camera.main.transform.position + Camera.main.transform.forward * distance, Camera.main.transform.rotation);
            myGameObject.transform.SetParent(Camera.main.transform);
            isInspecting = true;
        }
        else if (isInspecting == true)
        {
            foreach (Transform child in Camera.main.transform)
            {
                GameObject.Destroy(child.gameObject);
            }

            myGameObject = Instantiate(inspectGameObject, Camera.main.transform.position + Camera.main.transform.forward * distance, Camera.main.transform.rotation);
            myGameObject.transform.SetParent(Camera.main.transform);
        }

        
    }
}
