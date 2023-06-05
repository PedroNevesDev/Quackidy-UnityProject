using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class UIManager : MonoBehaviour
{
    static UIManager instance;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] int score ;

    public static UIManager Instance { get => instance; set => instance = value; }

    void Awake()
    {
        if (instance)
            Destroy(gameObject);
        instance = this;
    }
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        text.text = score.ToString();
    }
}
