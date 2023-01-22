using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using GooglePlayGames;
using TMPro;

public class Leaderboard : MonoBehaviour
{
    public static Leaderboard Instance;

    private void Awake()
    {
        Instance = this;
    }
    public void ShowLeaderboardUI()
    {
        Social.ShowLeaderboardUI();
    }

    public void PostToLeaderboard(int score)
    {
        Social.ReportScore(score, GPGSIds.leaderboard_time_survived, CallBackForLeaderboard);
    }

    public void CallBackForLeaderboard(bool success)
    {
        Debug.Log(success);
    }

    public void PostButton()
    {
        PostToLeaderboard(5);
    }

}
