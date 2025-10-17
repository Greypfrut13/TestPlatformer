using System;
using Player.Health;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Game
{
    public class GameUIHandler : MonoBehaviour
    {
        [SerializeField] private Button _restartButton;
        
        [SerializeField] private SceneLoader _sceneLoader;
        [SerializeField] private PlayerHealth _playerHealth;

        private void Awake()
        {
            _restartButton.onClick.AddListener(_sceneLoader.RestartGame);
            _restartButton.gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            _playerHealth.OnDeath += SetActiveRestartButton;
        }

        private void OnDisable()
        {
            _playerHealth.OnDeath -= SetActiveRestartButton;
        }

        private void SetActiveRestartButton()
        {
            _restartButton.gameObject.SetActive(true);   
        }
    }
}