using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField] float _deleteTime;
    LineRenderer _lr;
    EdgeCollider2D _ec2d;
    float _time;
    List<Vector3> lineVec = new List<Vector3>();
    List<Vector2> edgeVec = new List<Vector2>();
    List<float> pointTime = new List<float>();

    void Start()
    {
        _lr = GetComponent<LineRenderer>();
        _lr.positionCount = lineVec.Count;
        _lr.SetPositions(lineVec.ToArray());
        _ec2d = GetComponent<EdgeCollider2D>();
        _ec2d.SetPoints(edgeVec);
    }

    
    void Update()
    {
        Debug.Log(pointTime.Count);
        if(_time >= _deleteTime + pointTime[0])
        {
            lineVec.RemoveAt(0);
            _lr.positionCount = lineVec.Count;
            edgeVec.RemoveAt(0);
            _lr.SetPositions(lineVec.ToArray());
            _ec2d.SetPoints(edgeVec);
            pointTime.RemoveAt(0);
            Destroy();
        }
        else
        {
            _time += Time.deltaTime;
        }
    }

    public void AddPoints(Vector3 Point ,float _pointTime)
    {
        if (lineVec.Count > 0 && Point == lineVec[lineVec.Count - 1]) return;
        lineVec.Add(Point);
        _lr.positionCount = lineVec.Count;
        edgeVec.Add(Point);
        _lr.SetPositions(lineVec.ToArray());
        _ec2d.SetPoints(edgeVec);
        pointTime.Add(_pointTime);
    }

    public void Destroy()
    {
        if (_lr.positionCount <= 1)
        {
            Destroy(gameObject);
        }
    }
}
