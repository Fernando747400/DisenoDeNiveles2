using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] private Vector3 _rotationSpeed;

    private GameObject _thisObject;
    private Vector3 _currentRotation;

    private void Awake()
    {
        _thisObject = this.gameObject;
    }

    public void FixedUpdate()
    {
        _currentRotation = _thisObject.transform.rotation.eulerAngles;
        _thisObject.transform.rotation = Quaternion.Euler(_currentRotation.x + _rotationSpeed.x, _currentRotation.y + _rotationSpeed.y, _currentRotation.z + _rotationSpeed.z);
    }
}
