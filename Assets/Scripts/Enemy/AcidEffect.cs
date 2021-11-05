using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidEffect : MonoBehaviour

{

    float _speed = 3f;

    private void Start()
    {
        Destroy(this.gameObject, 5.0f);

    }
    private void Update()
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            IDamageble hit = other.GetComponent<IDamageble>();
            if (hit != null)
            {
                hit.Damage();
                Destroy(this.gameObject);
            }
        }
    }
}

