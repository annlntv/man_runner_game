using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] float rotationSpeed;
    [SerializeField] GameObject effectPrefab;
    void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<CoinManager>().AddOne();
        Destroy(gameObject);
        Instantiate(effectPrefab, transform.position, transform.rotation);
    }
}
