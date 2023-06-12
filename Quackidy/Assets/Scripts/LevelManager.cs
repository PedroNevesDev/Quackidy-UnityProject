using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    static LevelManager instance;
    public static LevelManager Instance { get => instance; set => instance = value; }

    UIManager ui;
    void Awake()
    {
        if (instance)
            Destroy(gameObject);
        instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ui.PauseToggle();
            TogglePause();

        }

    }
    private void Start()
    {
        Time.timeScale = 1.0f;
        ui = UIManager.Instance;
    }
    public void ChangeLevel(string level)
    {
        SceneManager.LoadScene(level);
    }

    public void TogglePause()
    {
        Time.timeScale = Time.timeScale == 1 ? 0f : 1f;
    }

    public void Exit()
    {
        Application.Quit();
    }
}
