using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LeaderboardDisplay : MonoBehaviour
{
    public GameObject rowPrefab;
    public Transform rowsParent;

    private string currentLevel = "Level1"; // Default level

    public void GetLeaderboard()
    {
        var request = new GetLeaderboardRequest()
        {
            StatisticName = currentLevel,
            StartPosition = 0,
            MaxResultsCount = 2
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardSuccess, OnError);
    }

    public void ChangeLevelToLevel1()
    {
        currentLevel = "Level1";
        GetLeaderboard();
    }

    public void ChangeLevelToLevel2()
    {
        currentLevel = "Level2";
        GetLeaderboard();
    }

    public void ChangeLevelToLevel3()
    {
        currentLevel = "Level3";
        GetLeaderboard();
    }

    public void ChangeLevelToLevel4()
    {
        currentLevel = "Level4";
        GetLeaderboard();
    }

    public void ChangeLevelToLevel5()
    {
        currentLevel = "Level5";
        GetLeaderboard();
    }

    void OnLeaderboardSuccess(GetLeaderboardResult result)
    {

        var sortedLeaderboard = result.Leaderboard.OrderBy(x => x.StatValue).ToList();

    foreach (Transform item in rowsParent)
    {
        Destroy(item.gameObject);
    }

    // Display the sorted leaderboard
    foreach (var item in sortedLeaderboard)
    {
        GameObject newGo = Instantiate(rowPrefab, rowsParent);
        Text[] texts = newGo.GetComponentsInChildren<Text>();
        texts[1].text = item.DisplayName;
        texts[2].text = ((decimal)item.StatValue / 100).ToString("F2");
    }
    }

    void OnError(PlayFabError error)
    {
        Debug.Log("Error in creation: " + error.GenerateErrorReport());
    }
    public void backButton(){
        SceneManager.LoadScene("Level Select Screen");
    }
    public void BackToLevel(){
        SceneManager.LoadScene("LeaderBoard");
    }
}


