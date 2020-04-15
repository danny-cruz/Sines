using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using GooglePlayGames.BasicApi.SavedGame;
using UnityEngine.SocialPlatforms;
using TMPro;
using System;

public class LoadSave : MonoBehaviour 
{
    public UI_GPG_SignIn SignInButton;

    void Awake()
    {

        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
           // enables saving game progress.
           .EnableSavedGames()
           .Build();

        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();
        if (PlayerPrefs.GetInt("InitialLogIn") == 0 || PlayerPrefs.GetInt("LoggedIn") == 1)
        {
            Social.localUser.Authenticate((bool success) =>
            {
                if (success)
                {
                    PlayerPrefs.SetInt("LoggedIn", 1);
                    SignInButton.SignIn = true;
                    if (PlayerPrefs.GetInt("CloudSave") == 0)
                    {
                        OpenSave(false);
                    }
                }
                else
                {
                    PlayerPrefs.SetInt("LoggedIn", 0);
                    SignInButton.SignIn = false;
                }
                PlayerPrefs.SetInt("InitialLogIn", 1);
            });
        }

    }

    private string GetSaveString()
    {  
        string r = PlayerPrefs.GetInt("highscore").ToString();

        return r;
    }

    private void LoadSaveString(string save)
    {
        int localScore = PlayerPrefs.GetInt("highscore");

        if (localScore < int.Parse(save))
        {
            PlayerPrefs.SetInt("highscore", int.Parse(save));         
        }
        if (PlayerPrefs.GetInt("InitialSave") == 0)
        {
            Social.ReportScore(PlayerPrefs.GetInt("highscore"), "CgkIlu2Nm5MWEAIQCQ", (bool success) =>
            {
            });
            PlayerPrefs.SetInt("InitialSave", 1);
        }
    }

    // cloud saving
    private bool isSaving = false;
    public void OpenSave(bool saving)
    {

        if(Social.localUser.authenticated)
        {
            isSaving = saving;
            ((PlayGamesPlatform)Social.Active).SavedGame.OpenWithAutomaticConflictResolution(
                "Looper",
                GooglePlayGames.BasicApi.DataSource.ReadCacheOrNetwork,
                ConflictResolutionStrategy.UseLongestPlaytime, SaveGameOpened);
        }
    }

    private void SaveGameOpened(SavedGameRequestStatus status, ISavedGameMetadata meta)
    {
        if(status == SavedGameRequestStatus.Success)
        {
            if(isSaving) // writing
            {
                byte[] data = System.Text.ASCIIEncoding.ASCII.GetBytes(GetSaveString());
                SavedGameMetadataUpdate update = new SavedGameMetadataUpdate.Builder().WithUpdatedDescription("Saved at" + DateTime.Now.ToString()).Build();

                ((PlayGamesPlatform)Social.Active).SavedGame.CommitUpdate(meta, update, data, SaveUpdate);
            }
            else // reading
            {
                ((PlayGamesPlatform)Social.Active).SavedGame.ReadBinaryData(meta, SaveRead);
            }
        }
    }

    private void SaveRead(SavedGameRequestStatus status, byte[] data)
    {
        if(status == SavedGameRequestStatus.Success)
        {
            string saveData = System.Text.ASCIIEncoding.ASCII.GetString(data);
            LoadSaveString(saveData);
            Debug.Log(saveData);
        }
    }

    private void SaveUpdate(SavedGameRequestStatus status, ISavedGameMetadata meta)
    {
        Debug.Log(status);
    }

    void Update () 
	{
		
	}
}
