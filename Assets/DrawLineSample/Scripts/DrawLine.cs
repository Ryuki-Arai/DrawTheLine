using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    [SerializeField] GameObject lineObject;
    [SerializeField] float lineWidth = 0.5f;
    [SerializeField] Material[] marerials;
    int _matIndex = 0;
    LineRenderer _lr;
    EdgeCollider2D _ec2d;
    List<Vector3> lineVec = new List<Vector3>(); 
    List<Vector2> edgeVec = new List<Vector2>();

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
            Drawing(point);
        }
        if (Input.GetMouseButtonUp(0))
        {
            _matIndex++;
            lineVec.Clear();
            edgeVec.Clear();
        }
    }

    /// <summary>
    /// �N���b�N����LineRenderer��EdgeCollider���܂ރQ�[���I�u�W�F�N�g���쐬����
    /// </summary>
    void CreateLine()
    {
        var obj = new GameObject($"LineObject");
        obj.transform.parent = transform;
        obj.AddComponent<LineRenderer>();
        obj.AddComponent<EdgeCollider2D>();
        _lr = obj.GetComponent<LineRenderer>();
        _lr.startWidth = lineWidth;
        _lr.positionCount = lineVec.Count;
        _lr.material = marerials[_matIndex % marerials.Length];
        _lr.SetPositions(lineVec.ToArray());
        _ec2d = obj.GetComponent<EdgeCollider2D>();
        _ec2d.edgeRadius = lineWidth / 2;
        _ec2d.SetPoints(edgeVec);
    }

    /// <summary>
    /// �N���b�N����Ă���Ԃ̃V�[����̃|�C���^�̍��W���Q�[���I�u�W�F�N�g�ɒǉ�����
    /// </summary>
    /// <param name="drawPoint">Z���W��0�ɒ������|�C���^��Vector���W3</param>
    void Drawing(Vector3 drawPoint)
    {
        if (lineVec.Count > 0 && drawPoint == lineVec[lineVec.Count - 1])
        {
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
