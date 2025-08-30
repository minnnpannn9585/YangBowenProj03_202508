using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationObject : MonoBehaviour
{
    
    public GameObject TriangleParticle;
    public float rotationSpeed = 100f;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponent<AudioSource>().Play();
            Instantiate(TriangleParticle, transform.position, Quaternion.Euler(new Vector3(90, 0, 0)));
            

        }

    }
    private void Update()
    {
        // 旋转
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
