using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    /// <summary>
    /// Number of full 360 degree rotations in 1 second
    /// </summary>
    [SerializeField] private float rotationSpeed = .75f;

    // Update is called once per frame
    private void Update()
    {
        this.transform.Rotate(0, 0, 360 * rotationSpeed * Time.deltaTime);
    }
}
