using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using GooglePlayGames;


public class Achievements : MonoBehaviour
{
    public static Achievements Instance;

    private void Awake()
    {
        Instance = this;
    }
    public void ShowAchievementsUI()
    {
        Social.ShowAchievementsUI();
    }

    public void DoGrandAchievement(string achievement)
    {
        Social.ReportProgress(achievement, 100.00f, CallBackForAchievements);
    }

    public void DoIncrementalAchievement(string achievement)
    {
        PlayGamesPlatform platform = (PlayGamesPlatform)Social.Active;
        platform.IncrementAchievement(achievement, 1, CallBackForAchievements);
    }

    public void CallBackForAchievements(bool success)
    {
        Debug.Log(success);
    }

    public void ListAchievements()
    {
        Social.LoadAchievements((achievements) =>
        {
            Debug.Log($"Achievements length -> {achievements.Length}");
            foreach (IAchievement ach in achievements)
            {
                Debug.Log($"achievement id -> {ach.id}, proccess -> ${ach.completed}");
            }
        });
    }

    public void ListDescriptions()
    {
        Social.LoadAchievementDescriptions((achievements) =>
        {
            Debug.Log($"Achievements length -> {achievements.Length}");
            foreach (IAchievementDescription ach in achievements)
            {
                Debug.Log($"achievement id -> {ach.id}, proccess -> ${ach.title}");
            }
        });
    }

}
