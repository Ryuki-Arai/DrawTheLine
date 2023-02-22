using UnityEngine;
/// <summary>
/// �����������߂̃X�N���v�g
/// �}�E�X��^�b�`�̔���(�V���O���^�b�`)��p���Đ���`�悷��
/// �V�[����̃Q�[���I�u�W�F�N�g�ɃA�^�b�`���Ďg�p����
/// </summary>
public class DrawLine : MonoBehaviour
{
    [SerializeField,Tooltip("���̃v���n�u")] 
    GameObject lineObject;

    [SerializeField, Tooltip("���̐F�̃}�e���A��")] 
    Material[] marerials;
    
    [SerializeField, Tooltip("���̑���"),Min(0.05f)] 
    float lineWidth = 0.5f;

    [SerializeField, Tooltip("�����蔻��")]
    bool _collisionDetect;

    [SerializeField, Tooltip("�d�͓K�p")]
    bool _useGravity;
    
    [SerializeField, Tooltip("���������������I�ɏ������邩")]
    bool _deleteLine;
    
    public bool DeleteLine => _deleteLine;
    
    [HideInInspector] //���������Ă�����ł���܂ł̎���
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
    /// �N���b�N����LineRenderer��EdgeCollider���܂ރQ�[���I�u�W�F�N�g���쐬����
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
