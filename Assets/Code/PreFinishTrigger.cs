using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreFinishTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerBehavior playerBehavior = other.attachedRigidbody.GetComponent<PlayerBehavior>();
        if(playerBehavior != null )
        {
            playerBehavior.StartPrefinishBehaviour();
        }
    }
}
