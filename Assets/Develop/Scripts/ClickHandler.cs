using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    private Camera _mainCamera;
    private const int LeftMouseButton = 0;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(LeftMouseButton)) 
        {
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                IClickKillable killable = hit.collider.GetComponent<IClickKillable>();
                killable?.OnClickKill();
            }
        }
    }
}

