using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private Transform _sunroof;

    [SerializeField] [Min(0.0f)] private float _openingSpeed;

    private float _startScale;
    private float _currentScale;
    private bool _isClosing = false;
    private Color _startColor;

    private SpriteRenderer _renderer;

    private void Start() 
    {
        _startScale = _sunroof.transform.localScale.x;
        _currentScale = _startScale;

        _renderer = GetComponent<SpriteRenderer>();
        _startColor = _renderer.color;
    }

    private void Update() {
        _currentScale = _sunroof.localScale.x;

        CloseSunroof();
    }

    private void CloseSunroof()
    {
        if(_isClosing)
        {
            Vector3 sunroofScaling = new Vector3(_sunroof.transform.localScale.x + _openingSpeed * Time.deltaTime, _sunroof.localScale.y, _sunroof.transform.localScale.z);
            _sunroof.localScale = sunroofScaling;

            if(_currentScale >= _startScale)
            {
                _isClosing = false;
            }
        }
    }

    public void Open()
    {
        if(_currentScale >= 0)
        {
            Vector3 sunroofScaling = new Vector3(_sunroof.transform.localScale.x - _openingSpeed * Time.deltaTime, _sunroof.localScale.y, _sunroof.transform.localScale.z);
            _sunroof.localScale = sunroofScaling;

            _renderer.color = Color.red;
        }
        
    }

    public void Close()
    {
        _isClosing = true;

        _renderer.color = _startColor;
    }
}
