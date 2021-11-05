using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    protected int health;
    [SerializeField]
    protected int speed;
    [SerializeField]
    protected int gems;
    public GameObject diamondPreFab;

    [SerializeField]
    protected Transform pointA, pointB;

    protected Vector3 currentTarget;
    protected Animator anima;
    protected SpriteRenderer sprite;

    protected bool isHit = false;
    protected Player playerPosition;
    protected Vector3 playerCurrentPosition;
    protected bool isDeath = false;

    public virtual void Init()
    {
        anima = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        playerPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    private void Start()
    {
        Init();

        if (playerPosition == null)
        {
            Debug.Log("Player is Null!!");
        }
    }

    public virtual void Update()
    {
        if (anima.GetCurrentAnimatorStateInfo(0).IsName("Idle") && anima.GetBool("InCombat") == false)
        {
            return;
        }
        if (isDeath == false)
            Movement();      
    }
    public virtual void Movement()
    {
        if (currentTarget == pointA.position)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }
        if (transform.position == pointA.position)
        {
            currentTarget = pointB.position;
            anima.SetTrigger("Idle");
        }
        else if (transform.position == pointB.position)
        {
            currentTarget = pointA.position;
            anima.SetTrigger("Idle");
        }
        if (isHit == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
        }
        Vector3 direction = playerPosition.transform.localPosition - transform.localPosition;
        // Debug.Log("Direction is:" + direction.x);

        if (direction.x < 0 && anima.GetBool("InCombat") == true)
        {
            sprite.flipX = true;

        }
        if (direction.x > 0 && anima.GetBool("InCombat") == true)
        {
            sprite.flipX = false;
        }

        //Combat Mode Enemy
        float dist = Vector3.Distance(transform.localPosition, playerPosition.transform.localPosition);

        if (dist > 5f)
        {
            isHit = false;
            anima.SetBool("InCombat", false);
        }

    }
}
