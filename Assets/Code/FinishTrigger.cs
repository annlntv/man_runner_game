using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    //[SerializeField] GameManager gameManager;
    public void OnTriggerEnter(Collider other)
    {
        PlayerBehavior playerBehavior = other.attachedRigidbody.GetComponent<PlayerBehavior>();
        if (playerBehavior != null)
        {
            playerBehavior.StartFinishBehaviour();
            FindObjectOfType<GameManager>().ShowFinishWindow();
        }
    }
}
