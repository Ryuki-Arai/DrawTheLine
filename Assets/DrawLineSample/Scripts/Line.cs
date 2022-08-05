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

    /// <summary>
    /// 指定経過時間後に、線の開始点から消していく
    /// </summary>
    void Update()
    {
        if(pointTime.Count < 1) return;
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

    /// <summary>
    /// 受け取った座標情報を線座標リストに格納し、LineRenderer とEdgeCollider2Dにセットする
    /// </summary>
    /// <param name="Point">タッチされた画面上の座標</param>
    /// <param name="_pointTime">線の描画開始時間(始点)から、その点が描画されるまでの経過時間</param>
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
    /// 線の座標数が1以下になったら消える
    /// </summary>
    void Destroy()
    {
        if (_lr.positionCount <= 1)
        {
            Destroy(gameObject);
        }
    }
}
