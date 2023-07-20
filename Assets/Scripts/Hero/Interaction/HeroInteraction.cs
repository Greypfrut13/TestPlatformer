using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroInteraction : MonoBehaviour
{
    [SerializeField] private InteractComponent _interactComponent;
    [SerializeField] private Hero _hero;

    public void HoldItem()
    {
        var item = _interactComponent.Interactable;
        
        if(item != null)
        {
            item.transform.SetParent(transform);
            item.transform.position = transform.position;

            item.GetComponent<SpriteRenderer>().enabled = false;
            _hero.GetComponent<SpriteRenderer>().color = Color.yellow;
        }
    }

    public void DropItem()
    {
        var item = _interactComponent.Interactable;

        if(item != null)
        {
            item.transform.SetParent(null);

            item.GetComponent<SpriteRenderer>().enabled = true;
            _hero.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}
