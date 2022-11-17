using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHelper : MonoBehaviour
{

    private static SceneHelper _instance;


  public SceneId previousScene;
    public static SceneHelper instance 
    {
        get {

            if (_instance == null) {
                _instance = FindObjectOfType<SceneHelper>();

                if (_instance == null)
                {
                    var go = new GameObject("SceneHelper");
                    go.AddComponent<SceneHelper>();

                    _instance = go.GetComponent<SceneHelper>();
                }
               // DontDestroyOnLoad(_instance.gameObject);
            }
            return _instance;
        }
    }
    /*
        public SceneId GetCurrentSceneId()
        {
            Enum.TryParse(SceneManager.GetActiveScene().name, out SceneId sceneId);
            return sceneId;
        }
        public void ReloadScene()
        {
            Enum.TryParse(SceneManager.GetActiveScene().name, out  SceneId sceneId);
            StartCoroutine(_LoadScene(sceneId));
        }
    */

        public void LoadScene(SceneId sceneId) 
        {

            StartCoroutine(_LoadScene( sceneId));
        }

        private IEnumerator _LoadScene(SceneId sceneId)     //Corrutina
        {
            //  SceneManager.GetActiveScene().name
           // yield return LoadingScreen.instance._OnLoadScreen();

            Enum.TryParse(SceneManager.GetActiveScene().name, out previousScene);
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneId.ToString()); //Rutina para cargar una escena en forma asíncrona
        //if (Camera.main.GetComponent<CameraController_1>() != null)
        //{
        //    Camera.main.GetComponent<CameraController_1>().FreezeCamera();
        //}
        //if (HeroController_1.instance != null)
        // {
        //HeroController_1.instance.PutOutBoundaries();
        Camera.main.GetComponent<CameraController_1>().FreezeCamera();      //para que no se mueva la camara al cambiar ed escena
        HeroController_11.instance.UpdatePosition(new Vector2(-10, 0));      //Punto muerto del personaje

            //}
            while (!asyncLoad.isDone)
            {
                yield return null;
            }

        /*
                    var list = FindObjectsOfType<PortalScene>().ToList();
                    if (list != null) {
                        try
                        {
                            var spawnPosition = list.Find(x => x.SceneToLoad() == previousScene).GetSpawnPosition();
                            Debug.Log("spawnPosition " + spawnPosition);
                            HeroController_1.instance.PutOnSpawnPosition(spawnPosition);
                            Camera.main.GetComponent<CameraController_1>().UpdatePosition(spawnPosition);
                        }
                        catch (Exception ex) { 
                        }

                    }


                    yield return new WaitForSeconds(1);
                    yield return LoadingScreen.instance._OnLoadedScreen();
        */

    }

}
