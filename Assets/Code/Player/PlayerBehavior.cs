using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] PreFinishBehaviour preFinishBehaviour;
    [SerializeField] Animator animator;
    [SerializeField] Camera _mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        player.enabled = false;
        preFinishBehaviour.enabled = false;
    }

    public void Play()
    {
        player.enabled = true;
    }

    public void StartPrefinishBehaviour() {
        _mainCamera.enabled = false;
        player.enabled = false;
        preFinishBehaviour.enabled = true;
    }

    public void StartFinishBehaviour()
    {
        preFinishBehaviour.enabled = false ;
        
        animator.SetTrigger("dance");
    }
}
