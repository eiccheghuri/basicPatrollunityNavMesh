using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class wayPoint : MonoBehaviour
{


    

    [SerializeField]
    private float debugDrawRadius = 1f;

    public virtual void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,debugDrawRadius);

    }


}
