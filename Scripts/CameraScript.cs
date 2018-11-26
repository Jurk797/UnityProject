using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraScript : MonoBehaviour
{
    [SerializeField] float m_scrollSpeed = 10;
    [SerializeField] float m_MinFov = 3;
    [SerializeField] float m_MaxFov = 10;
    int sizeMap;
    Camera cam;
    Vector3 startPos;
    Transform _transform;
    public EventSystem eventSystem;

    private void Awake()
    {
        sizeMap = MapManager.instance.Size;
        cam = GetComponent<Camera>();
        _transform = GetComponent<Transform>();
        _transform.position = new Vector3(sizeMap / 2, sizeMap / 2, _transform.position.z);
    }

    bool movingCamera = false;

    private void LateUpdate()
    {
        float ScrollWheel = Input.GetAxis("Mouse ScrollWheel");

        if (ScrollWheel != 0)
        {
            Scrolling(ScrollWheel);
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (!eventSystem.IsPointerOverGameObject(-1))
            {
                startPos = cam.ScreenToWorldPoint(Input.mousePosition);
                movingCamera = true;
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            startPos = cam.ScreenToWorldPoint(Input.mousePosition);
            movingCamera = false;
        }
        if (movingCamera)
        {
            Vector3 newPos = cam.ScreenToWorldPoint(Input.mousePosition) - startPos;
            _transform.position -= newPos;
        }
    }

    public void Scrolling(float scroll)
    {
        float fov = cam.orthographicSize;

        fov -= scroll * m_scrollSpeed;
        fov = Mathf.Clamp(fov, m_MinFov, m_MaxFov);

        cam.orthographicSize = fov;
    }
}
