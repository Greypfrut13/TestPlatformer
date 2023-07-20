using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class InteractComponent : MonoBehaviour
{
    private IInteractable _interactable;

    public IInteractable Interactable => _interactable;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        var interactable = other.GetComponent<IInteractable>();
        if(interactable != null)
        {
            _interactable = interactable;
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        var interactable = other.GetComponent<Item>();
        if(interactable != null)
        {
            _interactable = null;
        }
    }
}
