using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int score = 3000;
    public GameObject StarParticle;
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            GetComponent<AudioSource>().Play();
            Instantiate(StarParticle, transform.position, Quaternion.Euler(new Vector3(90, 0, 0)));
            Destroy(gameObject,0.3f);
            ScoreManager.Instance.ShowScore(transform.position, score);
            Debug.Log("”Œœ∑Ω· ¯£°");
        }
    }
    
}
