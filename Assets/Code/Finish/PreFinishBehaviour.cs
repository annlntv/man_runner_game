using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreFinishBehaviour : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        float x = Mathf.MoveTowards(transform.position.x, 0, Time.deltaTime * 2f);
        float z = transform.position.z + Time.deltaTime * 3f;
        transform.position = new Vector3(x, 0, z);

        float rot = Mathf.MoveTowardsAngle(transform.eulerAngles.y, 0, Time.deltaTime * 100f);
        transform.localEulerAngles = new Vector3(0, rot, 0);
    }
}
