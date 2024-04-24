using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;
//using UnityEditor.Build.Content;
using System.Collections.Generic;
using PlayFab.ClientModels;
using PlayFab;

public class Goal : MonoBehaviour
{
    public GameObject buttonToShow;
    public GameObject buttonToShow2;
    public TMP_Text timerText;
    public TMP_Text collisionText; 
    private bool movementStopped = false;
    private float timer = 0f;

    private void Start()
    {
        Time.timeScale = 1f;
        movementStopped = false;
        UpdateTimerDisplay();
    }

    private void Update()
    {
        if (movementStopped)
        {
            Time.timeScale = 0f;
            return;
        }

        timer += Time.deltaTime;
        
        UpdateTimerDisplay();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Goal"))
        {
            movementStopped = true;
            ShowCollisionText(); 
            buttonToShow.SetActive(true);
            buttonToShow2.SetActive(true);
            string currentScene= SceneManager.GetActiveScene().name;
            CurrentScene(currentScene);
            TimerFloat(timer);
            SendLeaderboard((int)(timer*100), currentScene);

        }
    }

    private void UpdateTimerDisplay()
    {
        if (timerText != null)
        {
            timerText.text = "Time: " + timer.ToString("F2");

        }
    }

    private void ShowCollisionText()
    {
        if (collisionText != null)
        {
            collisionText.gameObject.SetActive(true);
        }
    }

    public void ReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoBack()
    {
        SceneManager.LoadScene("Level Select Screen");
    }
    public float TimerFloat(float finalTimeValue){
        Debug.Log("Final Timer Value" + (finalTimeValue*100));
        return timer;
    }
    public string CurrentScene(string currentScene){
        Debug.Log(currentScene);
        return currentScene;
    }
    public void SendLeaderboard(int score, string currentScene){
        // string sceneSelect= CurrentScene();
        var request= new  UpdatePlayerStatisticsRequest{
            Statistics= new List<StatisticUpdate>{
                new StatisticUpdate{
                StatisticName = currentScene,
                Value= score
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnError);
    }
    void OnLeaderboardUpdate(UpdatePlayerStatisticsResult result){
        Debug.Log("successfull leaderboard sent");
    }
    void OnError(PlayFabError error){
        Debug.Log("Error in LeaderBoard: " + error.GenerateErrorReport());
    }
    
}
