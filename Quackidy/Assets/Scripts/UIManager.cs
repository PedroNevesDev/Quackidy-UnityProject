using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class UIManager : MonoBehaviour
{
    static UIManager instance;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] int score;
    [SerializeField] GameObject EngGamePannel;
    [SerializeField] GameObject PauseGamePannel;
    [SerializeField] TextMeshProUGUI engGameScore;
    [SerializeField] float foodToLose;
    float foodToLoseBoost = 1f;
    [SerializeField] Image hunger;
    [SerializeField] Texture2D cursor;

    public static UIManager Instance { get => instance; set => instance = value; }
    public float FoodToLoseBoost { get => foodToLoseBoost; set => foodToLoseBoost = value; }
    public int Score { get => score; set => score = value; }

    void Awake()
    {
        Cursor.SetCursor(cursor, Camera.main.ScreenToWorldPoint(Input.mousePosition), CursorMode.ForceSoftware);
        if (instance)
            Destroy(gameObject);
        instance = this;
    }
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        text.text = score.ToString();
    }
    private void Update()
    {
        if (hunger.fillAmount > 0f)
            hunger.fillAmount -= Time.deltaTime * foodToLose *foodToLoseBoost;
        else
            EndGame();
    }

    public void AddFood(float foodToAdd)
    {
        hunger.fillAmount += foodToAdd;
    }
    
    public void EndGame()
    {
        text.enabled= false;
        engGameScore.text = score.ToString();
        EngGamePannel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void PauseToggle()
    { 
        PauseGamePannel.SetActive(!PauseGamePannel.activeSelf);
    }
}
