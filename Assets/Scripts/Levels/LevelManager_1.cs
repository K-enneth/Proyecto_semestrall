using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager_1 : MonoBehaviour
{

    [SerializeField] AudioClip levelMusic;
    //[SerializeField] AudioClip finalBossMusic;

    //[SerializeField] float cameraSize;
    //[SerializeField] GameObject finalBoss;
    //[SerializeField] public bool isFinalBoss;
    

    //private bool activeBossFight;
    void Start()
    {

        AudioManager_1.instance.PlayMusic(levelMusic);
       
    }
    /*
    public void FinalBossWasVanquished() {
        AudioManager.instance.PlayMusic(levelMusic);
        var block = FindObjectOfType<BossBlock>();
        if (block)
        {
            block.StartUnlock();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!activeBossFight && isFinalBoss&& collision.gameObject.tag.Equals(TagId.Player.ToString()))
        {
            activeBossFight = true;

            AudioManager.instance.PlayMusic(finalBossMusic);
            var block = FindObjectOfType<BossBlock>();
            if (block) {
                block.StartBlock();
            }
            if (finalBoss) {
                finalBoss.SetActive(true);
            }
            FindObjectOfType<CameraController>().ChangeCameraSize(cameraSize);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    */
}
