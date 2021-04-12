using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // private void OnTriggerEnter(Collider other)
    // {
    //     Agent agent = other.GetComponent<Agent>();
    //     
    //     if (agent != null)
    //     {
    //         agent.Damage();
    //     }
    //     
    //     BullsEye bullsEye = other.GetComponent<BullsEye>();
    //
    //     if (bullsEye != null)
    //     {
    //         bullsEye.HideAndRevealTarget();
    //     }
    //     
    // }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
