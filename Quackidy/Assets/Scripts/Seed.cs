using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour, IInteractable
{
    [SerializeField] int scoreToAdd;

    public void Interact()
    {
        UIManager.Instance.UpdateScore(scoreToAdd);
        DuckSpawner.Instance.SpawnDuck();
        
        Destroy(gameObject);
    }
}
