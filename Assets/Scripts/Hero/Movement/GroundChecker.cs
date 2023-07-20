using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private LayerMask _groundLayer;

    private Collider2D _collider;
    private bool _isTouchingGround;

    public bool IsTouchingGround => _isTouchingGround;

    private void Start() 
    {
        _collider = GetComponent<Collider2D>();
    }

    private void OnTriggerStay2D(Collider2D other) 
    {
        _isTouchingGround = _collider.IsTouchingLayers(_groundLayer);
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        _isTouchingGround = _collider.IsTouchingLayers(_groundLayer);
    }
}
