using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PreFinishTrigger : MonoBehaviour
{
    [SerializeField] PlayableDirector playableDirector;
    [SerializeField] Camera _camera;
    private void OnTriggerEnter(Collider other)
    {
        PlayerBehavior playerBehavior = other.attachedRigidbody.GetComponent<PlayerBehavior>();
        if(playerBehavior != null )
        {
            playerBehavior.StartPrefinishBehaviour();
            _camera.enabled = true;
            playableDirector.Play();
        }
    }
}
