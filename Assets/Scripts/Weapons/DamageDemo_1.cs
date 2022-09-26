using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDemo_1 : MonoBehaviour, ITargetCombat_1
{
    [SerializeField] int health;
    [SerializeField] DamageFeedbackEffect damageFeedbackEffect;

    public void TakeDamage(int damagePoints)
    {
        damageFeedbackEffect.PlayDamageEffect();
        health -= damagePoints;

    }
}
