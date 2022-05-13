using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager: MonoBehaviour
{
    [SerializeField]
    private GameObject LevelCompletePrefab, WinText;

    [SerializeField]
    private UIManager UIManager;

    [SerializeField]
    private bool LevelCompleted = false;

    [SerializeField]
    public float GravityScale = 9.81f, GravityChangeSpeed = .1f;

    public static GameManager _instance;

    void Awake() 
    {
        _instance = gameObject.GetComponent<GameManager>();
    }

    void Update() 
    {
        ChangeGravity();
    }

    private void ChangeGravity() 
    {
        GravityScale += (Random.Range(-1, 1) * Mathf.Sin(Time.time)) * GravityChangeSpeed * Time.deltaTime;
        UIManager.SetGravitySlider(GravityScale);
    }

    public static GameManager Get() 
    {
        if (_instance == null)
        {
            GameObject GameManager = new GameObject("GameManager");
            _instance = GameManager.AddComponent<GameManager>();
        }
        return _instance;
    }

    public int MaxBalls = 15;

    public void UpdateScore(int BallsCounter) 
    {
        UIManager.UpdateScore(BallsCounter);
        if (BallsCounter == MaxBalls && !LevelCompleted) CompleteLevel();
    }

    private void CompleteLevel() 
    {
        WinText.SetActive(true);
        Instantiate(LevelCompletePrefab, transform);

        LevelCompleted = true;
    }

    public void LevelFailed() 
    {
        Debug.Log("Level Failed");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
