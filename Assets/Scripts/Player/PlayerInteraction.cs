using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [Header("Interaction area")]
    [SerializeField] float size = 1.5f;
    [SerializeField] Vector3 offest;

    [SerializeField] GameObject iteractionButtonHint;
    public IteractableBase interactable;

    // Update is called once per frame
    void FixedUpdate()
    {

        int interactionLayer = 1 << 8;
        Collider[] colliders = Physics.OverlapSphere(transform.position + offest, size,interactionLayer);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].tag == "Interactable Item")
            {
                OnIteractionAreaEnter(colliders[i]);
                return;
            }            
        }

        if (interactable != null)
        {
            OnIteractionAreaExit();
        }
    }


    private void Update()
    {
        if (interactable!=null)
        {
            if (Input.GetKeyDown(KeyCode.E))
               interactable.Interact();
        }
    }

    void OnIteractionAreaEnter(Collider collider)
    {
        ShowHint();
        interactable = collider.GetComponent<IteractableBase>();
        Debug.Log(interactable.name);
    }

    void OnIteractionAreaExit()
    {
        HideHint();
        interactable.ExitInteract();
        interactable = null;
    }


    public void ShowHint()
    {
        iteractionButtonHint.SetActive(true);
    }

    public void HideHint()
    {
        iteractionButtonHint.SetActive(false);
    }

    private void OnDrawGizmos()
    {
        if(interactable==null)
           Gizmos.color = Color.red;
        else
           Gizmos.color = Color.green;

        Gizmos.DrawSphere(transform.position + offest, size);
    }
}
