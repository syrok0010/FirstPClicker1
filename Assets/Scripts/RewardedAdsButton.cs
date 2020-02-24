﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

[RequireComponent (typeof (Button))]
public class RewardedAdsButton : MonoBehaviour, IUnityAdsListener 
{
    private string gameId = "3482869";

    Button myButton;
    public string myPlacementId = "rewardedVideo";

    void Start () {   
        myButton = GetComponent <Button> ();

        // Set interactivity to be dependent on the Placement’s status:
        myButton.interactable = Advertisement.IsReady (myPlacementId); 

        // Map the ShowRewardedVideo function to the button’s click listener:
        if (myButton) myButton.onClick.AddListener (ShowRewardedVideo);

        // Initialize the Ads listener and service:
        Advertisement.AddListener (this);
        Advertisement.Initialize (gameId, false);
    }

    // Implement a function for showing a rewarded video ad:
    public void ShowRewardedVideo () {
        Advertisement.Show (myPlacementId);
    }

    // Implement IUnityAdsListener interface methods:
    public void OnUnityAdsReady (string placementId) {
        // If the ready Placement is rewarded, activate the button: 
        if (placementId == myPlacementId) {        
            myButton.interactable = true;
        }
    }

    public void OnUnityAdsDidFinish (string placementId, ShowResult showResult) {
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished) {
            // Reward the user for watching the ad to completion.
            Menu.Instance.CloseOfflineGotPanel();
            MainController.Instance.OfflineGot(2);
        } else if (showResult == ShowResult.Skipped) {
            // Do not reward the user for skipping the ad.
            Menu.Instance.CloseOfflineGotPanel();
            MainController.Instance.OfflineGot(1);
        } else if (showResult == ShowResult.Failed) {
            Menu.Instance.CloseOfflineGotPanel();
            MainController.Instance.OfflineGot(1);
        }
    }

    public void OnUnityAdsDidError (string message) {
        // Log the error.
    }

    public void OnUnityAdsDidStart (string placementId) {
        // Optional actions to take when the end-users triggers an ad.
    } 
}