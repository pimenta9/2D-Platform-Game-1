using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;

    // Update is called once per frame
    private void Update()
    {
        this.transform.position = new Vector3
                                      (playerTransform.position.x,
                                      playerTransform.position.y + 1f,
                                      this.transform.position.z);
    }
}
