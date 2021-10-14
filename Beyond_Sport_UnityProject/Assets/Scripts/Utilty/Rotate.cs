using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField]
    private Vector3 rotationSpeed = Vector3.zero;

    // Update is called once per frame
    private void Update()
    {
        transform.rotation *= Quaternion.Euler(rotationSpeed * Time.deltaTime);
    }
}