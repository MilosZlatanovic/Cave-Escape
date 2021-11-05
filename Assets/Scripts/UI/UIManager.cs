using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                // Debug.LogError("Instance is NULL!!!");
            }
            return _instance;
        }
    }
    public Text playerGemText;
    public Image selectionImage;
    public Text gemCountText;
    public Image[] healtLists;
    private void Awake()
    {
        _instance = this;
    }
    public void ShopCount(int gemCount)
    {
        playerGemText.text = "" + gemCount + "G";
    }
    public void UpdateShopSelestion(int yPos)
    {
        selectionImage.rectTransform.anchoredPosition =
            new Vector2(selectionImage.rectTransform.anchoredPosition.x, yPos);
    }
    public void UpdateGemCount(int count)
    {
        gemCountText.text = "" + count;
    }
    public void UpdateLives(int livesRemaining)
    {

        for (int i = 0; i <= livesRemaining; i++)
        {
            if (livesRemaining == i)
            {
                healtLists[i].enabled = false;
            }
        }
    }
}
