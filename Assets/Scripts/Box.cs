using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public float forceMagnitude = 3f;
    //public ParticleSystem explosionEffect;

    public GameObject boxParticle;
    
    // 旋转速度（度/秒）
    public float rotationSpeed = 100f;
    // 缩放幅度
    public float scaleAmount = 0.3f;
    // 缩放周期（秒）
    public float scalePeriod = 2f;
    // 当前时间
    private float timeSinceLastScaleChange = 0f;
  


    void Explode(GameObject Player)
    {
        //if (explosionEffect != null)
        //{
        //    explosionEffect.transform.position = transform.position;
        //    explosionEffect.Play();
        //}

        Rigidbody2D rb = Player.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            Vector2 direction = (Player.transform.position - transform.position).normalized;
            rb.AddForce((Vector2.up) * forceMagnitude, ForceMode2D.Impulse);
            
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(boxParticle, transform.position, Quaternion.Euler(new Vector3(90, 0, 0)));
            Explode(other.gameObject);
            Destroy(gameObject);
        }
        
    }

    private void Update()
    {
        // 旋转
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);

        // 计算当前应该应用的缩放比例
        timeSinceLastScaleChange += Time.deltaTime;
        float scale = 1 + scaleAmount * Mathf.Sin(2 * Mathf.PI * timeSinceLastScaleChange / scalePeriod);
        transform.localScale = new Vector3(scale, scale, 1); // 假设只在XY平面上缩放
    }

}
