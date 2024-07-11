using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class MoveTrigger : MonoBehaviour
{
    [SerializeField] PlayableDirector playableDirector;
    [SerializeField] Camera _camera;
    //[SerializeField] CharacterAutoMove character;
    private void OnTriggerEnter(Collider other)
    {
        PlayerBehavior playerBehavior = other.attachedRigidbody.GetComponent<PlayerBehavior>();
        if (playerBehavior != null)
        {
            playerBehavior.MoveToOnePoint();
            _camera.enabled = true;
            playableDirector.Play();
            //character.StartMovement();
        }
    }
}
