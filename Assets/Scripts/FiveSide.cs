using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiveSide : MonoBehaviour
{
    public int score = 3000;
    public GameObject FivesideParticle;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponent<AudioSource>().Play();
            Instantiate(FivesideParticle, transform.position, Quaternion.Euler(new Vector3(90, 0, 0)));
            ScoreManager.Instance.ShowScore(transform.position, score);

        }

    }
}
