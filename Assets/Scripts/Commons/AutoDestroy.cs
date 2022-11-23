using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    [SerializeField] float delay = 3;
    [SerializeField] AudioClip sfx;

   
    private void Awake()
    {
        if (sfx) {
            AudioManager_1.instance.PlaySfx(sfx);
        }
        Destroy(this.gameObject, delay);
    }
}
