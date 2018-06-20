using UnityEngine;

public class Interactable : MonoBehaviour
{
    public bool hasInteracted = false;
    public GameObject selectedObject;

    public virtual void Interact()
    {
        //this method is meant to be overwritten
    }

    void Update()
    {

        if (Input.touchCount > 0)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit Hit;
            Debug.DrawRay(ray.origin, ray.direction * 10, Color.green);
            if (Physics.Raycast(ray, out Hit))
            {
                Debug.Log("Selected Something");
                Interactable interactable = Hit.collider.GetComponent<Interactable>();

                if (interactable != null && interactable.hasInteracted == false)
                {
                    interactable.hasInteracted = true;
                    interactable.Interact();
                }
                else
                {
                    return;
                }
            }
        }

    }
}

/*//old code
 * 
 * if (Input.touchCount > 0 || Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit Hit;
            Debug.DrawRay(ray.origin, ray.direction * 10, Color.green);
            if (Physics.Raycast(ray, out Hit))
            {
                Debug.Log("Selected Something");
                Interactable interactable = Hit.collider.GetComponent<Interactable>();

                if (interactable != null && interactable.hasInteracted == false)
                {
                    interactable.hasInteracted = true;
                    interactable.Interact();
                }
                else
                {
                    return;
                }
            }
        }
 * 
 * */
