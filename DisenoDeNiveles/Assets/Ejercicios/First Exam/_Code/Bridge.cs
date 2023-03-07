using UnityEngine;

public class Bridge : MonoBehaviour
{
    [Header("Pivot Point")]
    [SerializeField] private GameObject _pivot;

    [Header("TargetRotation")]
    [SerializeField] private Vector3 _lowerRotation;
    [SerializeField] private Vector3 _raiseRotation;

    [Header("ActionSpeed")]
    [SerializeField] private float _actionSpeed;

    public void Raise()
    {
        iTween.RotateTo(_pivot.gameObject, _raiseRotation, _actionSpeed);
    }

    public void Lower()
    {
        iTween.RotateTo(_pivot.gameObject, _lowerRotation, _actionSpeed);
    }
}
