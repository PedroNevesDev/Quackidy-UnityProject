using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour, IInteractable
{
    [SerializeField] int scoreToAdd;
    [SerializeField] float speedToAdd;
    [SerializeField] float foodToAdd;
    public float SpeedToAdd { get => speedToAdd; }
    public float FoodToAdd { get => foodToAdd; set => foodToAdd = value; }

    public void Interact()
    {
        UIManager.Instance.UpdateScore(scoreToAdd);
        DuckSpawner.Instance.SpawnDuck();
        Destroy(gameObject);
    }
}
