using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    private Animator _swordAnimator;
    private Player player;
    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _swordAnimator = transform.GetChild(1).GetComponent<Animator>();

        if (null == _animator)
        {
            // play Bounce but start at a quarter of the way though
           // Debug.Log("Animator is Null");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Move(float move)
    {
        _animator.SetFloat("Move", Mathf.Abs(move));

    }

    public void Jump(bool jump)
    {
        _animator.SetBool("Jumping", jump);
    }
    public void Attacking()
    {
        
        _animator.SetTrigger("Attack");
        _swordAnimator.SetTrigger("Sword_Animation");
    }
    public void Dead()
    {
        _animator.SetTrigger("IsDead");
    }
    public void Hit()
    {
        _animator.SetBool("isHit", true);
        //_animator.SetBool("isHit", false);
    }
}