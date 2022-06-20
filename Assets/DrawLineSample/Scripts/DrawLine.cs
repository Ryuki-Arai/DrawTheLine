using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(EdgeCollider2D))]
public class DrawLine : MonoBehaviour
{
    [SerializeField] float lineWidth = 0.5f;
    [SerializeField] float deleteTime = 3;
    LineRenderer _lr;
    EdgeCollider2D _ec2d;
    Camera mainCamera;
    List<Vector3> lineVec = new List<Vector3>(); 
    List<Vector2> edgeVec = new List<Vector2>();
    float _time;

    void Start()
    {
        _lr = GetComponent<LineRenderer>();
        _lr.useWorldSpace = false;
        _lr.startWidth = lineWidth;
        _ec2d = GetComponent<EdgeCollider2D>();
        mainCamera = Camera.main;
        _ec2d.edgeRadius = _lr.startWidth/2;
    }

    void Update()
    {
        _time += Time.deltaTime;

        if (Input.GetMouseButton(0))
        {
            Vector3 pos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0f;
            if (lineVec.Count > 0 && pos == lineVec[lineVec.Count - 1]) return;

            lineVec.Add(pos);
            _lr.positionCount = lineVec.Count;
            edgeVec.Add(pos);
        }
        if (Input.GetMouseButtonUp(0))
        {
            CreateLineObject();
        }
        if (!(Input.GetMouseButton(0)))
        {
            lineVec.Clear();
            edgeVec.Clear();
        }
        //if (_time > deleteTime)
        //{
        //    _time = 0;
        //    if (lineVec.Count > 0)
        //    {
        //        lineVec.Remove(lineVec[0]);
        //        _lr.positionCount = lineVec.Count;
        //        edgeVec.Remove(edgeVec[0]);
        //    }
        //}
        if (lineVec != null && edgeVec != null)
        {
            _lr.SetPositions(lineVec.ToArray());
            _ec2d.SetPoints(edgeVec);
        }
    }
    void CreateLineObject()
    {
        var obj = new GameObject($"LineObject");
        obj.transform.parent = transform;
        obj.AddComponent<LineRenderer>();
        obj.AddComponent<EdgeCollider2D>();
        var lr = obj.GetComponent<LineRenderer>();
        lr.startWidth = lineWidth;
        lr.positionCount = lineVec.Count;
        lr.SetPositions(lineVec.ToArray());
        obj.GetComponent<EdgeCollider2D>().SetPoints(edgeVec);
    }
}
