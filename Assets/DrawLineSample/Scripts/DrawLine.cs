using UnityEngine;
/// <summary>
/// 線を引くためのスクリプト
/// マウスやタッチの判定(シングルタッチ)を用いて線を描画する
/// シーン上のゲームオブジェクトにアタッチして使用する
/// </summary>
public class DrawLine : MonoBehaviour
{
    [SerializeField,Tooltip("線のプレハブ")] 
    GameObject lineObject;

    [SerializeField, Tooltip("線の色のマテリアル")] 
    Material[] marerials;
    
    [SerializeField, Tooltip("線の太さ"),Min(0.05f)] 
    float lineWidth = 0.5f;

    [SerializeField, Tooltip("当たり判定")]
    bool _collisionDetect;

    [SerializeField, Tooltip("重力適用")]
    bool _useGravity;
    
    [SerializeField, Tooltip("書いた線を自動的に消去するか")]
    bool _deleteLine;
    
    public bool DeleteLine => _deleteLine;
    
    [HideInInspector] //線を引いてから消滅するまでの時間
    public float DeleteTime;
    
    int _mIndex = 0;
    Line _line;
    float _pointTime;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _pointTime = 0;
            CreateLine();
        }
        else if (Input.GetMouseButton(0))
        {
            _pointTime += Time.deltaTime;
            var point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            point.z = 0f;
            if (_line) _line.AddPoints(point, _pointTime);
            else CreateLine();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _mIndex++;
            _line.RB2D.bodyType = _useGravity ?  RigidbodyType2D.Dynamic : RigidbodyType2D.Static;
        }
    }

    /// <summary>
    /// クリック時にLineRendererとEdgeColliderを含むゲームオブジェクトを作成する
    /// </summary>
    void CreateLine()
    {
        var obj = Instantiate(lineObject, transform);
        _line = obj.GetComponent<Line>();
        _line.DeleteTime = DeleteTime;
        _line.DeleteLine = _deleteLine;
        var _lr = obj.GetComponent<LineRenderer>();
        _lr.startWidth = lineWidth;
        _lr.material = marerials[_mIndex % marerials.Length];
        var _ec2d = obj.GetComponent<EdgeCollider2D>();
        _ec2d.enabled = _collisionDetect;
        _ec2d.edgeRadius = lineWidth / 2;
    }
}
