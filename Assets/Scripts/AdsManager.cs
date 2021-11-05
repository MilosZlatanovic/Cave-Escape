using UnityEngine;
using UnityEngine.Advertisements;
public class AdsManager : MonoBehaviour
{
    
    private int gemsRewarded = 100;

    public void ShowRewardedAd()
    {
        // ADS for Unity

        if (Advertisement.IsReady("rewardedVideo"))
        {
            var options = new ShowOptions
            {
                resultCallback = HandleShowResult
            };
            Advertisement.Show("rewardedVideo", options);
        }

    }
    private void HandleShowResult(ShowResult result)
    {
       
        switch (result)
        {
            case ShowResult.Finished:
               // Debug.Log("The ad was successfully shown.");
                //
                // YOUR CODE TO REWARD THE GAMER
                // Give GEMS etc.
               
                 //   Debug.Log("GIVE A PLAYER 100G");

                    GameManager.Instance.Player.AddGems(gemsRewarded);
                  UIManager.Instance.ShopCount(GameManager.Instance.Player.diamound);
               
                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                break;
        }
    }
}

