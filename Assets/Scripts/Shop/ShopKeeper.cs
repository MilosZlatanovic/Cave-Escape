using UnityEngine;

public class ShopKeeper : MonoBehaviour
{
    public GameObject shopPanel;
    private int currentItemSelected;
    private Player player;
    // public int paid;
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            player = other.GetComponent<Player>();
            if (player != null)
            {

                UIManager.Instance.ShopCount(player.diamound);
                //UIManager.Instance.ShopCount(player._diamound - paid);
                shopPanel.SetActive(true);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            shopPanel.SetActive(false);
        }
    }
    public void SelectItem(int item)
    {

        switch (item)
        {
            case 0: //falame sword
                UIManager.Instance.UpdateShopSelestion(74);
                currentItemSelected = 200;
                break;
            case 1: //flight boots
                UIManager.Instance.UpdateShopSelestion(-29);
                currentItemSelected = 400;
                break;
            case 2: //key clasle
                UIManager.Instance.UpdateShopSelestion(-130);
                currentItemSelected = 100;
                break;
        }
        //  currentItemSelected = item;


    }
    public void BuyItem()
    {

        if (player.diamound >= currentItemSelected)
        {
            if (currentItemSelected == 100)
            {
                GameManager.Instance.HasKeyToCastle = true;
            }
           // Debug.Log("You Buy:: " + currentItemSelected);
            player.diamound -= currentItemSelected;
            UIManager.Instance.ShopCount(player.diamound);
        }
        else
        {
           // Debug.Log("You Dont Have a MANY");
            shopPanel.SetActive(false);
        }

    }
}
