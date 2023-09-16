using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private float shakeRadius;
    [SerializeField] private float shakeDuration;
    private Vector3 _firstPosition;
    private bool _isShaking;
    void Start()
    {
        _firstPosition = transform.position;
    }

    public void StartShaking()
    {
        _isShaking = true;
        StartCoroutine(Shake());
        StartCoroutine(StopShake());
    }

    private IEnumerator Shake()
    {
        while (_isShaking)
        {
            var newPosition = Random.insideUnitCircle * shakeRadius;
            transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
            yield return new WaitForNextFrameUnit();
        }

        transform.position = _firstPosition;
    }

    private IEnumerator StopShake()
    {
        yield return new WaitForSecondsRealtime(shakeDuration);
        _isShaking = false;
    }
}
