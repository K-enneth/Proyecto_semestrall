//Script para dibujar un rayo en ls plantas del pie del Hero
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerChecker_1 : MonoBehaviour
{

    public enum LayerChekerType
    {
        Ray,
        Circle
    }

    [SerializeField]
    LayerChekerType layerChekerType;
    [SerializeField] LayerMask targetMask;      //
    [SerializeField] Vector2 direction;                 //
    [SerializeField] float distance;                    //


    public bool isTouching;                                 //




    void Update()
    {
       // if (layerChekerType == LayerChekerType.Ray)
        {
            isTouching = Physics2D.Raycast(this.transform.position, direction, distance, targetMask);           //
        }
       // if (layerChekerType == LayerChekerType.Circle)
       // {
          //  isTouching = Physics2D.OverlapCircle(this.transform.position, distance, targetMask);
       // }
    }


#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if (isTouching)
        {
            Gizmos.color = Color.green;
        }
        else
        {
            Gizmos.color = Color.yellow;

        }
       // if (layerChekerType == LayerChekerType.Ray)
        {

            Gizmos.DrawRay(this.transform.position, direction * distance);          //
        }
       // if (layerChekerType == LayerChekerType.Circle)
        {

            //Gizmos.DrawWireSphere(this.transform.position, distance);
        }
    }
#endif

    


}
