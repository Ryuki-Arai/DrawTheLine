using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField, Tooltip("���������������I�ɏ������邩")] 
    bool _deleteLine;
    public bool DeleteLine => _deleteLine;
    [HideInInspector,Min(0.1f)] 
    public float DeleteTime;
    LineRenderer _lr;
    EdgeCollider2D _ec2d;
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
        if(_deleteLine)StartCoroutine(DeletePoint());
    }

    /// <summary>
    /// �w��o�ߎ��Ԍ�ɁA���̊J�n�_��������Ă���
    /// </summary>
    private IEnumerator DeletePoint()
    {
        yield return new WaitForSeconds(DeleteTime);

        float t = 0f;

        while (pointTime.Count > 1)
        {
            yield return new WaitForEndOfFrame();

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
    /// <summary>
    /// ���̍��W����1�ȉ��ɂȂ����������
    /// </summary>
    void Destroy()
    {
        if (_lr.positionCount <= 1)
        {
            Destroy(gameObject);
        }
    }
}
