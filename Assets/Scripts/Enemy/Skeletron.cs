using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeletron : Enemy, IDamageble
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

        float distance = Vector3.Distance(playerPosition.transform.localPosition, transform.localPosition);

        //Debug.Log("Distance to other: " + distance);

        // Enemy Direction
        Vector3 direction = playerPosition.transform.localPosition - transform.localPosition;
        // Debug.Log("Direction is:" + direction.x);

        if (direction.x < 0 && anima.GetBool("InCombat") == true)
        {
            sprite.flipX = true;
            playerCurrentPosition.x = playerPosition.transform.localPosition.x + 1;
            playerCurrentPosition.y = playerPosition.transform.localPosition.y;
            transform.position = Vector3.MoveTowards(transform.position, playerCurrentPosition, speed * Time.deltaTime);

        }
        if (direction.x > 0 && anima.GetBool("InCombat") == true)

        {
            sprite.flipX = false;
            playerCurrentPosition.x = playerPosition.transform.localPosition.x - 1;
            playerCurrentPosition.y = playerPosition.transform.localPosition.y;
            transform.position = Vector3.MoveTowards(transform.position, playerCurrentPosition, speed * Time.deltaTime);
        }


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
    public void SkeletronAtatck()
    {
        playerCurrentPosition.x = playerPosition.transform.localPosition.x + 1;
        playerCurrentPosition.y = playerPosition.transform.localPosition.y;
        transform.position = Vector3.MoveTowards(transform.position, playerCurrentPosition, speed * Time.deltaTime);
    }
}
