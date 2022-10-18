using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Contar_11 : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0) //Si la salud del Ghost = 0..
        {
            SceneManager.LoadScene("Level1_2");                     //Cambia de escena a "Level1_2"
        }
        else if(GameObject.FindGameObjectsWithTag("Player").Length == 0)    ////Si la salud del Héroe = 0..
        {
            SceneManager.LoadScene("Level1_1");                     //Reinicia la escena "Level1_1"
        }
    }
}
