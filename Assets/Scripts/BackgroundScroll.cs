
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private Vector2 _offset;
    private Material _backgroundMaterial;
    private void Awake()
    {
        _backgroundMaterial = GetComponent<SpriteRenderer>().material;
        _offset = new Vector2(0, 0);
        _backgroundMaterial.mainTextureOffset = _offset;
    }

    private void Update()
    {
        _offset.y += moveSpeed * Time.deltaTime;
        _backgroundMaterial.mainTextureOffset = _offset;
    }
}
