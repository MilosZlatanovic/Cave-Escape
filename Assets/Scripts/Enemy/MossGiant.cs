using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy, IDamageble
{

    public int Health { get; set; }

    public override void Init()
    {
        base.Init();
        Health = base.health;
    }
    public override void Movement()
    {
        base.Movement();

    }
    public void Damage()
    {
        if (isDeath)
        {
            return;
        }
        Health--;
        isHit = true;
        anima.SetTrigger("Hit");
        anima.SetBool("InCombat", true);

        if (Health < 1)
        {
            isDeath = true;
            anima.SetTrigger("Death");
            GameObject diamond = Instantiate(diamondPreFab, transform.position, Quaternion.identity) as GameObject;
            diamond.GetComponent<Diamond>().gems = base.gems;
        }
    }
    public void MossGiantAtatck()
    {
        playerCurrentPosition.x = playerPosition.transform.localPosition.x + 1;
        playerCurrentPosition.y = playerPosition.transform.localPosition.y + 0.3f;
        transform.position = Vector3.MoveTowards(transform.position, playerCurrentPosition, speed * Time.deltaTime);
    }
}
