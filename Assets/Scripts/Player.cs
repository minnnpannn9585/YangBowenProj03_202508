using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;


public enum BallState
{
    Waiting,
    BeforeShoot,
    AfterShoot
    
}

public class Player : MonoBehaviour
{
    public BallState state = BallState.BeforeShoot;
    // Start is called before the first frame update
    private bool isMouseDown = false;
    public float maxDistance = 2.5f;
    public float flySpeed = 20;
    private Rigidbody2D rgd;
    void Start()
    {
        rgd = GetComponent<Rigidbody2D>();
        

    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case BallState.Waiting:
                break;
            case BallState.BeforeShoot:
                MoveControl();


                break;
            case BallState.AfterShoot:
                break;
            default:
                break;
        }
    }
    private void OnMouseDown()
    {
        if(state==BallState.BeforeShoot)
        {
            isMouseDown = true;
            SlingShoot.Instance.StartDraw(transform);
        }
    }
    private void OnMouseUp()
    {
        if (state == BallState.BeforeShoot)
        {
            isMouseDown = false;
            SlingShoot.Instance.EndDraw();
            fly();
        }
        
    }
    private void MoveControl()
    {
        if (isMouseDown)
        {
            transform.position = GetMousePosition();
        }
    }
    private Vector3 GetMousePosition()
    {
        Vector3 centerPositon = SlingShoot.Instance.getCenterposition();
        Vector3 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mp.z = 0;
        Vector3 mouseDir = mp - centerPositon;
        float distance = mouseDir.magnitude;
        if (distance > maxDistance)
        {
            mp = mouseDir.normalized * maxDistance + centerPositon;
        }

        return mp;
    }
    private void fly()
    {
        rgd.bodyType = RigidbodyType2D.Dynamic;
        rgd.velocity = (SlingShoot.Instance.getCenterposition() - transform.position).normalized * flySpeed;
        state = BallState.AfterShoot;
        
    }
}
 