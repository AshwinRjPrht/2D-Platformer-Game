using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    private void Update()
    {
        this.transform.Rotate(0, 0, 360f * speed * Time.deltaTime);
    }
}
