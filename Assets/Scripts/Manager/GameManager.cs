using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private DataEnemyCrab _dataEnemyCrab;
    public  Transform _playerTransform;
    float currentSpeed = 0f;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public bool IsPaused { get; private set; }
    public void PauseGame() => IsPaused = true;
    public void ResumeGame() => IsPaused = false;
}
