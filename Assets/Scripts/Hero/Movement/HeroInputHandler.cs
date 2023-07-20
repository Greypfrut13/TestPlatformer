using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class HeroInputHandler : MonoBehaviour
{
    [SerializeField] private HeroMovement _heroMovement;
    [SerializeField] private HeroInteraction _heroInteraction;

    public void OnHorizontalMovement(InputAction.CallbackContext context)
    {
        float direction = context.ReadValue<float>();

        _heroMovement.SetDirection(direction);
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        _heroMovement.Jump();
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        _heroInteraction.HoldItem();
    }

    public void OnStopInteract(InputAction.CallbackContext context)
    {
        if(context.canceled)
        {
            _heroInteraction.DropItem();
        }
    }
}
