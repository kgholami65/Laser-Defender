using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float movementSpeed;

    [Header("Ship Bounds")] [SerializeField]
    private Transform head;

    [SerializeField] private Transform tale;
    [SerializeField] private Transform left;
    [SerializeField] private Transform right;
    private Rigidbody2D _rigidBody;
    private Vector2 _moveValue;
    private Camera _camera;
    private Vector2 _minBounds;
    private Vector2 _maxBounds;
    private LevelManager _levelManager;
    private bool _isMouseInput;

    void Start()
    {
        InitializeFields();
        InitializeBounds();
    }

    private void InitializeFields()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        if (PlayerPrefs.HasKey("MouseInput"))
            _isMouseInput = PlayerPrefs.GetInt("MouseInput") == 1;
        else
            PlayerPrefs.SetInt("MouseInput", 1);
        _camera = Camera.main;
        _levelManager = FindObjectOfType<LevelManager>();
    }

    private void InitializeBounds()
    {
        _minBounds = _camera.ViewportToWorldPoint(new Vector2(0, 0));
        _maxBounds = _camera.ViewportToWorldPoint(new Vector2(1, 1));
    }
    

    void Update()
    {
        Move();
    }

    void OnMove(InputValue inputValue)
    {
        _moveValue = inputValue.Get<Vector2>();
        Debug.Log(_moveValue);
    }

    private void Move()
    {
        if (_isMouseInput)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos = _camera.ScreenToWorldPoint(mousePos);
            mousePos.z = 0;
            if (!CheckMouseBounds(mousePos))
                transform.position = Vector3.Lerp(transform.position, mousePos, movementSpeed * Time.deltaTime);
        }
        else
        {
            CheckBounds();
            _rigidBody.velocity = new Vector2(_moveValue.x * movementSpeed, _moveValue.y * movementSpeed);
        }

    }

    private void CheckBounds()
    {
        if (head.transform.position.y >= _maxBounds.y)
            _moveValue.y = _moveValue.y > 0 ? 0 : _moveValue.y;
        else if (tale.transform.position.y <= _minBounds.y)
            _moveValue.y = _moveValue.y < 0 ? 0 : _moveValue.y;
        if (right.transform.position.x >= _maxBounds.x)
            _moveValue.x = _moveValue.x > 0 ? 0 : _moveValue.x;
        else if (left.transform.position.x <= _minBounds.x)
            _moveValue.x = _moveValue.x < 0 ? 0 : _moveValue.x;
    }

    private void OnPause(InputValue inputValue)
    {
        if (inputValue.isPressed)
            _levelManager.PauseGame();
    }

    private bool CheckMouseBounds(Vector2 value)
    {
        return value.y > _maxBounds.y || value.y < _minBounds.y || value.x > _maxBounds.x || value.x < _minBounds.x;
    }
    
}
