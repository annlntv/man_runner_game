using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] Animator animator;
    private float oldMousePositionX;
    private float eulerY;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            oldMousePositionX = Input.mousePosition.x;
            animator.SetBool("run", true);
        }
        if (Input.GetMouseButton(0)) 
        {
            Vector3 newPos = transform.position + transform.forward * Time.deltaTime * speed;
            newPos.x = Mathf.Clamp(newPos.x, -2.5f, 2.5f);
            transform.position = newPos;

            float deltaX = Input.mousePosition.x - oldMousePositionX;
            oldMousePositionX = Input.mousePosition.x;

            eulerY += deltaX;
            eulerY = Mathf.Clamp(eulerY, -70, 70);
            transform.eulerAngles = new Vector3(0, eulerY, 0);
        }

        if (Input.GetMouseButtonUp(0))
        {
            animator.SetBool("run", false);
        }
        
    }
}
