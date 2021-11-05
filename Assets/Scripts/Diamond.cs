using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Diamond : MonoBehaviour
{
    protected Player _player;
    public int gems = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        _player = other.GetComponent<Player>();
        if (_player != null)
        {
            if (other.tag == "Player")
            {
               _player.AddGems(gems);
                Destroy(this.gameObject);
            }
        }
    }

}
