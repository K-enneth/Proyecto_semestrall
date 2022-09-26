using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageFeedbackEffect : MonoBehaviour
{

    private new Renderer renderer;                      //9


    //private bool playBlinkEffect;

    private void Awake()
    {
        renderer = GetComponent<Renderer>();        //9
    }

    public void PlayDamageEffect()                  //9
    {
        StartCoroutine(_PlayDamageEffect());        //9

    }

    public IEnumerator _PlayDamageEffect()          //9
    {
        renderer.material.SetFloat("_FlashAmount", 1);  //9
        yield return new WaitForSeconds(0.3f);          //9

        renderer.material.SetFloat("_FlashAmount", 0);  //9

    }

   
}
