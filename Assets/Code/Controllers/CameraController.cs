using Models;
using UnityEngine;
using UnityEngine.Serialization;
using Views;

namespace Controllers
{
    [RequireComponent(typeof(Camera))]
    public class CameraController : MonoBehaviour
    {
        private Camera _camera;

        public void Init(Vector2Int mazeSize)
        {
            var cameraTransform = GetComponent<Camera>().transform;
            var cameraPosition = cameraTransform.position;
            cameraPosition.x = mazeSize.x / 2f;
            cameraPosition.y = mazeSize.y / 2f;

            cameraTransform.position = cameraPosition;
            GetComponent<Camera>().orthographicSize = Mathf.CeilToInt(mazeSize.y / 2f);
        }
    }
}