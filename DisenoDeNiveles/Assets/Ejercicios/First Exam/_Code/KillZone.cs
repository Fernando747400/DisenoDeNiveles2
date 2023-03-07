using UnityEngine;
using UnityEngine.InputSystem;

public class KillZone : MonoBehaviour
{
    private GameObject _player;
    private Vector3 _initialPosition;
    private Vector3 _initialRotation;

    private void Awake()
    {
        FindPlayer();
    }

    private void FindPlayer()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _initialPosition = _player.transform.position;
        _initialRotation = _player.transform.eulerAngles;
    }

    private void ResetPlayer()
    {
        _player.GetComponent<PlayerInput>().DeactivateInput();
        _player.GetComponent<CharacterController>().enabled = false;
        _player.transform.position = _initialPosition;
        _player.transform.eulerAngles = _initialRotation;
        _player.GetComponent<PlayerInput>().ActivateInput();
        _player.GetComponent<CharacterController>().enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ResetPlayer();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ResetPlayer();
        }
    }

}
