using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;

    private float cameraPositionY = 0f;
    private float cameraPositionZ = -10f;
    
    private void LateUpdate()
    {
        _camera.transform.position = new Vector3(gameObject.transform.position.x, cameraPositionY, cameraPositionZ);
    }
}
