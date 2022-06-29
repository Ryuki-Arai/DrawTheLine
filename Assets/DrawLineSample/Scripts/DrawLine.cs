using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    [SerializeField] GameObject lineObject;
    [SerializeField] float lineWidth = 0.5f;
    [SerializeField] Material[] marerials;
    int _mIndex = 0;
    Line _line;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CreateLine();
        }
        if (Input.GetMouseButton(0))
        {
            var point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            point.z = 0f;
            _line.AddPoints(point);
        }
        if (Input.GetMouseButtonUp(0))
        {
            _mIndex++;
        }
    }

    /// <summary>
    /// クリック時にLineRendererとEdgeColliderを含むゲームオブジェクトを作成する
    /// </summary>
    void CreateLine()
    {
        var obj = Instantiate(lineObject, transform);
        _line = obj.GetComponent<Line>();
        var _lr = obj.GetComponent<LineRenderer>();
        _lr.startWidth = lineWidth;
        _lr.material = marerials[_mIndex % marerials.Length];
        var _ec2d = obj.GetComponent<EdgeCollider2D>();
        _ec2d.edgeRadius = lineWidth / 2;
    }
}
