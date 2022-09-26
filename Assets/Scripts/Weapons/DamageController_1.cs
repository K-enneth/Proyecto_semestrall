using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController_1 : MonoBehaviour
{
    [SerializeField] int damagePoints;
    [SerializeField] TagId_1 targetTag;

    private void Awake()
    {


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.tag.Equals(targetTag.ToString()))
        {
            var component = collision.gameObject.GetComponent<ITargetCombat_1>();
            if (component != null)
            {
                component.TakeDamage(damagePoints);
            }

        }

    }
}
