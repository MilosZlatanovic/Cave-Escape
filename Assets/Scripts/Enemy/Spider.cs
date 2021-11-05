using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageble
{
    public GameObject acidPreFab;
    public int Health { get; set; }
    public override void Init()
    {
        base.Init();
        Health = base.health;
    }
    public override void Update()
    {
    }
    public void Damage()
    {
        if (isDeath)
        {
            return;
        }
        Health--;
        if (Health < 1)
        {
            isDeath = true;
            anima.SetTrigger("Death");
            GameObject diamond = Instantiate(diamondPreFab, transform.position, Quaternion.identity) as GameObject;
            diamond.GetComponent<Diamond>().gems = base.gems;
        }
    }
    public override void Movement()
    {
        //sit stil
    }
    public void Attack()
    {
        float dist = Vector3.Distance(transform.position, playerPosition.transform.localPosition);

        if (dist < 7f)
        {
            Instantiate(acidPreFab, transform.position, Quaternion.identity);
        }
    }
}
