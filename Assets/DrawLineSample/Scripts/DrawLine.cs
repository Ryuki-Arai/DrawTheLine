using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    [SerializeField] float lineWidth = 0.5f;
    [SerializeField] float deleteTime = 3;
    LineRenderer _lr;
    EdgeCollider2D _ec2d;
    List<Vector3> lineVec = new List<Vector3>(); 
    List<Vector2> edgeVec = new List<Vector2>();

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CreateLine();
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            point.z = 0f;
            Drawing(point);
        }
        if (Input.GetMouseButtonUp(0))
        {
            lineVec.Clear();
            edgeVec.Clear();
        }
    }
    void CreateLine()
    {
        var obj = new GameObject($"LineObject");
        obj.transform.parent = transform;
        obj.AddComponent<LineRenderer>();
        obj.AddComponent<EdgeCollider2D>();
        _lr = obj.GetComponent<LineRenderer>();
        _lr.startWidth = lineWidth;
        _lr.positionCount = lineVec.Count;
        _lr.SetPositions(lineVec.ToArray());
        _ec2d = obj.GetComponent<EdgeCollider2D>();
        _ec2d.SetPoints(edgeVec);
    }
    void Drawing(Vector3 drawPoint)
    {
        if (lineVec.Count > 0 && drawPoint == lineVec[lineVec.Count - 1])
        {
            Debug.Log("No Move");
            return;
        }

        lineVec.Add(drawPoint);
        _lr.positionCount = lineVec.Count;
        edgeVec.Add(drawPoint);

        if (lineVec != null && edgeVec != null)
        {
            _lr.SetPositions(lineVec.ToArray());
            _ec2d.SetPoints(edgeVec);
        }
    }
}
