using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PortalScene : MonoBehaviour
{
   [SerializeField] SceneId levelFrom;                  //escena de donde venimos (obsoleta)
    [SerializeField] SceneId levelToLoad;               //escena a la qua vamos
    [SerializeField] Transform spawnPosition;
    private void OnTriggerEnter2D(Collider2D hero) //Trigger de colisión del portal que detecta el "SpriteHolderHero"="hero"
    {
        //Debug.Log(hero);
        if (hero.gameObject.tag.Equals(TagId_1.Player.ToString())) //Si el objeto con el que colisiona tien el "tag" "player"...
        {
            SceneHelper.instance.LoadScene(levelToLoad);    //Cambia de escena
        }
    }
    /*
    public SceneId SceneToLoad()
    {
        return levelToLoad;
    }

    public Vector2 GetSpawnPosition() {
        return spawnPosition.position;
    }
*/

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        for (int i = 0; i < 10; i++) {
            Gizmos.DrawWireCube(this.transform.position, new Vector3(i * 0.3f, i * 0.3f, 0));
        }
        Handles.Label((Vector2)this.transform.position + Vector2.up * 2, "LEVEL: " + levelToLoad.ToString());

      Gizmos.DrawWireSphere(spawnPosition.position, 0.3f);
    }
#endif
    
}
