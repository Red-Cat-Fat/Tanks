using UnityEngine;
using UnityEngine.AI;

public class MoveToPoint : MonoBehaviour {
    public float speed = 1f;
    public Vector3 moveEnd;
    public bool CanMove = false;
    public bool fixedPositionY = true;

    private Vector3 _moveStart;
    private Rigidbody _rigidbody;
    private float _lifeTime = 0;
    private float _flyTime = 1f;

    public void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _moveStart = transform.position;
        if (CanMove && moveEnd != null)
        {
            MoveTo(_moveStart, moveEnd);
        }
        if (_rigidbody == null)
        {
            Debug.LogError("Rigidbody is null");
        }
    }

    public void OnEnable()
    {
        _moveStart = transform.position;
        CanMove = true;
    }

    public void FixedUpdate()
    {
        _lifeTime += Time.fixedDeltaTime;
        if (CanMove && _moveStart != null && moveEnd != null)
        {
            float posY = _rigidbody.transform.position.y;
            _rigidbody.transform.position = Vector3.Lerp(_moveStart, moveEnd, _lifeTime / _flyTime);
            if (fixedPositionY)
            {
                _rigidbody.transform.position = new Vector3(_rigidbody.transform.position.x, posY, _rigidbody.transform.position.z);
            }
            if (_lifeTime > _flyTime)
            {
                CanMove = false;
            }
        }
    }

    public void MoveTo(Vector3 moveStart, GameObject moveEnd)
    {
        MoveTo(moveStart, moveEnd.transform.position);
    }
    public void MoveTo(Vector3 moveEnd)
    {
        MoveTo(gameObject.transform.position, moveEnd);
    }

    public void MoveTo(Vector3 moveStart, Vector3 moveEnd)
    {
        _lifeTime = 0;
        _moveStart = moveStart;
        this.moveEnd = moveEnd;
        transform.LookAt(moveEnd);
        float dist = Vector3.Distance(_moveStart, moveEnd);
        _flyTime = dist / speed;
        CanMove = true;
    }
}
