using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpPlatform : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Player _player = other.attachedRigidbody.GetComponent<Player>();
        if (_player != null)
        {
            _player.speed *= 3f;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        Player _player = other.attachedRigidbody.GetComponent<Player>();
        if (_player != null )
        {
            _player.speed /= 3f;
        }
        
    }
}
