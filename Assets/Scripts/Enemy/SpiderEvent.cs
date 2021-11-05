using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderEvent : MonoBehaviour
{
    protected Player playerPosition;
    protected Spider _spider;
    private void Start()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        _spider = transform.parent.GetComponent<Spider>();
        if (_spider == null)
        {
           // Debug.Log("Spider is NULL!!!");
        }
    }
    public void Fire()
    {
        //Debug.Log("Spider Fire***");
      
            _spider.Attack();
    }
}
