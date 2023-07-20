using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Item : IInteractable
{
    private SpriteRenderer _renderer;

    private void Start() 
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void Update() 
    {
        FollowParent();
    }

    private void FollowParent()
    {
        if(transform.parent != null)
        {
            transform.position = transform.parent.position;
        }
    }

    public void HideItem()
    {

    }
}
