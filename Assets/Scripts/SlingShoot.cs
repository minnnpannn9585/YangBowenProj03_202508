using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingShoot : MonoBehaviour
{
    public static SlingShoot Instance { get; private set; }
    private LineRenderer LineRenderer;
    private Transform Centerpoint;
    private bool isDrawing = false;
    private Transform BallTransform;
    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        LineRenderer = transform.Find("LineRenderer").GetComponent<LineRenderer>();
        Centerpoint = transform.Find("Centerpoint");
        HideLine();

    }

    // Update is called once per frame
    void Update()
    {
        if (isDrawing){
            Draw();
        }
    }
    public void StartDraw(Transform BallTransform)
    {
        isDrawing = true;
        this.BallTransform = BallTransform;
        Showline();
    }
    public void EndDraw()
    {
        isDrawing = false;
        HideLine();
    }
    public void Draw()
    {
        LineRenderer.SetPosition(0, BallTransform.position);
        LineRenderer.SetPosition(1, Centerpoint.position);
    }
    public Vector3 getCenterposition()
    {
        return Centerpoint.transform.position;
    }
    private void HideLine()
    {
        LineRenderer.enabled = false;
        

    }
    private void Showline()
    {
        LineRenderer.enabled = true;
       
    }
}
