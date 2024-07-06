using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] int value;
    [SerializeField] DeformationType deformationType;
    [SerializeField] GateAppearance appearance;
    private void OnValidate()
    {
        appearance.UpdateVisual(deformationType, value);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerModifier modifier = other.attachedRigidbody.GetComponent<PlayerModifier>();
        if (modifier != null)
        {
            if(deformationType == DeformationType.Width)
            {
                modifier.AddWidth(value);
            }
            else if (deformationType == DeformationType.Height)
            {
                modifier.AddHeight(value);
            }

            Destroy(gameObject);
        }
    }
}
