using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField, Tooltip("書いた線を自動的に消去するか")] 
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
    /// 指定経過時間後に、線の開始点から消していく
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
