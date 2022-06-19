using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    [SerializeField] float lineWidth = 0.5f;
    LineRenderer _lr;
    EdgeCollider2D _edge;
    int _posCount;
    Camera mainCamera;
    List<Vector2> edgeVec = new List<Vector2>();

    void Start()
    {
        _lr = GetComponent<LineRenderer>();
        _lr.useWorldSpace = false;
        _edge = GetComponent<EdgeCollider2D>();
        _posCount = 0;
        mainCamera = Camera.main;
        _edge.edgeRadius = _lr.startWidth/2;
    }

    void Update()
    {
        transform.position = mainCamera.transform.position + mainCamera.transform.forward * 10;
        transform.rotation = mainCamera.transform.rotation;

        if (Input.GetMouseButton(0))
        {
            Vector3 pos = Input.mousePosition;
            pos.z = 10.0f;

            pos = mainCamera.ScreenToWorldPoint(pos);

            pos = transform.InverseTransformPoint(pos);

            _posCount++;
            _lr.positionCount = _posCount;
            _lr.SetPosition(_posCount - 1, pos);
            edgeVec.Add(pos);
            _edge.SetPoints(edgeVec);
        }
        if (!(Input.GetMouseButton(0)))
        {
            _posCount = 0;
            edgeVec.Clear();
        }
    }

}
