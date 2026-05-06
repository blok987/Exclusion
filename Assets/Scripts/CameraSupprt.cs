using UnityEngine;

public class CameraSupprt : MonoBehaviour
{
   public Camera _camera;

    // Update is called once per frame
    void Update()
    {
        if (_camera.transform.eulerAngles != Vector3.zero)
        {
                _camera.Render();
        }
    }
}
