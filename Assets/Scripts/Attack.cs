using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public bool isAttack = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
       

        IDamageble hit = other.GetComponent<IDamageble>();

        if (hit != null)
        {
            if (isAttack == true)
            {
                hit.Damage();
                isAttack = false;
                StartCoroutine(ResetDamage());
            }
        }
    }
    IEnumerator ResetDamage()
    {
        yield return new WaitForSeconds(0.5f);
        isAttack = true;
    }
}
