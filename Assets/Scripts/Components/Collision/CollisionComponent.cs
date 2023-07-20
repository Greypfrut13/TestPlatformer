using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class CollisionComponent : MonoBehaviour
{
    [SerializeField] private string[] _tag;

    [SerializeField] private UnityEvent _onStay;
    [SerializeField] private UnityEvent _onExit;

    private void OnCollisionStay2D(Collision2D other) 
    {
        foreach(string tag in _tag)
        {
            if(tag == other.gameObject.tag)
            {
                _onStay?.Invoke();
            }
        }
    }

    private void OnCollisionExit2D(Collision2D other) 
    {
        foreach(string tag in _tag)
        {
            if(tag == other.gameObject.tag)
            {
                _onExit?.Invoke();
            }
        }
    }
}
