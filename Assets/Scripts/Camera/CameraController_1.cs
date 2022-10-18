using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class BoundaryRange      //Clase para el movimiento de la cpamara siguiendo al Hero
{
    public float min;
    public float max;
    
}
/*[Serializable]
public class CameraSize         //Clase par el rectángulo de la cámara    
{
    public float min;
    public float max;

*/

public class CameraController_1 : MonoBehaviour
{

      [SerializeField] TagId_1 target;

      [SerializeField] float offsetZ;

        [SerializeField] BoundaryRange boundaryX;
        [SerializeField] BoundaryRange boundaryY;
 //       [SerializeField] GameObject background;
 //          [SerializeField] float sizeSpeed=1;
//           [SerializeField] Vector2 scaleFactor;
           private GameObject targetGameObject;


//               CameraSize cameraSizeX;
//               CameraSize cameraSizeY;

           Vector3 vel;
    /*

           Vector2 targetTemp;

           private bool freezeCamera = false;

          public void ChangeCameraSize(float sizeCamera) {
               StartCoroutine(_ChangeCameraSize( sizeCamera));
           }
           IEnumerator _ChangeCameraSize(float sizeCamera)
           {
               var size = Camera.main.orthographicSize;

               while (size< sizeCamera) {
                   size += sizeSpeed;
                   Camera.main.orthographicSize = size;
                   background.transform.localScale= new Vector3(size* scaleFactor.x, size* scaleFactor.y,1);
                   GetSize();
                   yield return new WaitForSeconds(Time.deltaTime);

               }


           }*/
    void Start()
    {
               targetGameObject = GameObject.FindGameObjectWithTag(target.ToString());

//               GetSize();
//           }
//           void GetSize() 
//         {

//               cameraSizeX = new CameraSize();
//               cameraSizeY = new CameraSize();

//               cameraSizeX.min = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x - this.transform.position.x;
//               cameraSizeX.max = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - this.transform.position.x;

//               cameraSizeY.min = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y - this.transform.position.y;
//               cameraSizeY.max = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - this.transform.position.y;

    }
 /*
           public void UpdatePosition(Vector2 position)
           {
               this.transform.position = (Vector3)position+new Vector3(0,0,offsetZ);
           }
           public void FreezeCamera() 
           {
               freezeCamera = true;
           }
*/
           void Update()
           {

              if (targetGameObject)
                {
//                   targetTemp = new Vector2( targetGameObject.transform.position.x, targetTemp.y);
//                   if (HeroController.instance.playerIsOnGround) {
//                        targetTemp.y= targetGameObject.transform.position.y;
//                   }
                   var targetPosition = new Vector3(

                            Mathf.Clamp(targetGameObject.transform.position.x, boundaryX.min, boundaryX.max ),
                            Mathf.Clamp(targetGameObject.transform.position.y, boundaryY.min, boundaryY.max ),

                          //                           Mathf.Clamp(targetTemp.x + HeroController.instance.transform.right.x * 2, boundaryX.min - cameraSizeX.min, boundaryX.max - cameraSizeX.max),
                          //                           Mathf.Clamp(targetTemp.y, boundaryY.min - cameraSizeY.min, boundaryY.max - cameraSizeY.max),
                          offsetZ

                       );

                   this.transform.position = Vector3.SmoothDamp(this.transform.position, targetPosition , ref vel, 0.3f);   //La camara sigue al hero pero suevemente


               }

           }
/*

       #if UNITY_EDITOR                                 //Para dibujar un rectángulo donde se movería la cámara
           private void OnDrawGizmos()
           {

               var pointA = new Vector3(boundaryX.min, boundaryY.min);      //Primer línea vertical izquierda
               var pointB = new Vector3(boundaryX.min, boundaryY.max);
               Gizmos.DrawLine(pointA,pointB);


                pointA = new Vector3(boundaryX.max, boundaryY.min);         //Segunda línea vertical derecha
                pointB = new Vector3(boundaryX.max, boundaryY.max);
               Gizmos.DrawLine(pointA, pointB);



               pointA = new Vector3(boundaryX.min, boundaryY.min);          //Primer línea horizontal inferior
               pointB = new Vector3(boundaryX.max, boundaryY.min);
               Gizmos.DrawLine(pointA, pointB);


               pointA = new Vector3(boundaryX.min, boundaryY.max);          //Segunda línea horizontal superior
        pointB = new Vector3(boundaryX.max, boundaryY.max);
               Gizmos.DrawLine(pointA, pointB);
           }

       #endif
   */    

}
