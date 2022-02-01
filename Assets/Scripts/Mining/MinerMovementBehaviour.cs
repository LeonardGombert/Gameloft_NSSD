using System.Collections;
using UnityEngine;

public class MinerMovementBehaviour : MonoBehaviour
{
    private InputManager _inputManager;
    [SerializeField] private float _moveSpeed = 60.0f;

    private void Awake() => _inputManager = InputManager.Instance;

    private void OnEnable() => _inputManager.OnStartTouch += SetTargetPosition;

    private void OnDisable() => _inputManager.OnStartTouch -= SetTargetPosition;

    private void SetTargetPosition(Vector2 position)
    {
        StopAllCoroutines();

        Vector3 screenCoordinates = new Vector3(position.x, position.y, -Camera.main.transform.position.z);
        Vector3 targetPosition = Camera.main.ScreenToWorldPoint(screenCoordinates);
        targetPosition.z = 0;

        StartCoroutine(MoveToPosition(transform.position, targetPosition));
    }

    private IEnumerator MoveToPosition(Vector3 origin, Vector3 destination)
    {
        float step = (_moveSpeed / (origin - destination).magnitude) * Time.deltaTime;

        float alpha = 0;
        
        while (alpha <= 1.0f)
        {
            alpha += step;
            transform.position = Vector3.Lerp(origin, destination, alpha);
            yield return null;
        }

        transform.position = destination;
    }
}
