using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    bool _deleteLine;
    public bool DeleteLine { set => _deleteLine = value; } 
    float _deleteTime;
    public float DeleteTime { set => _deleteTime = value; }
    LineRenderer _lr;
    EdgeCollider2D _ec2d;
    Rigidbody2D _rb2d;
    public Rigidbody2D RB2D { get { return _rb2d; }  set { _rb2d = value; } } 
    List<Vector3> lineVec = new List<Vector3>();
    List<Vector2> edgeVec = new List<Vector2>();
    List<float> pointTime = new List<float>();

    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _lr = GetComponent<LineRenderer>();
        _lr.positionCount = lineVec.Count;
        _lr.SetPositions(lineVec.ToArray());
        _ec2d = GetComponent<EdgeCollider2D>();
        _ec2d.SetPoints(edgeVec);
        if(_deleteLine)StartCoroutine(DeletePoint());
    }

    /// <summary>
    /// �w��o�ߎ��Ԍ�ɁA���̊J�n�_��������Ă���
    /// </summary>
    private IEnumerator DeletePoint()
    {
        yield return new WaitForSeconds(_deleteTime);

        float t = 0f;

        while (pointTime.Count > 1)
        {
            yield return null;

            t+=Time.deltaTime;

            if(t >= pointTime[0])
            {
                lineVec.RemoveAt(0);
                _lr.positionCount = lineVec.Count;
                edgeVec.RemoveAt(0);
                _lr.SetPositions(lineVec.ToArray());
                _ec2d.SetPoints(edgeVec);
                pointTime.RemoveAt(0);
            }

        }

        Destroy(gameObject);
    }

    /// <summary>
    /// �󂯎�������W��������W���X�g�Ɋi�[���ALineRenderer ��EdgeCollider2D�ɃZ�b�g����
    /// </summary>
    /// <param name="Point">�^�b�`���ꂽ��ʏ�̍��W</param>
    /// <param name="_pointTime">���̕`��J�n����(�n�_)����A���̓_���`�悳���܂ł̌o�ߎ���</param>
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
}
