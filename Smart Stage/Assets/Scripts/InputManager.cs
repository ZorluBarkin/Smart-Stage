using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{

    [SerializeField] private Camera arCam;
    [SerializeField] private ARRaycastManager _raycastManger;

    private List<ARRaycastHit> _hits = new List<ARRaycastHit>();

    private Touch touch;

    // Update is called once per frame
    void Update()
    {

        touch = Input.GetTouch(0);
        if (Input.touchCount < 0 || touch.phase != TouchPhase.Began)
            return;

        if (IsPointerOverUI(touch)) return;

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = arCam.ScreenPointToRay(touch.position);
            if(_raycastManger.Raycast(ray, _hits))
            {
                Pose pose = _hits[0].pose;
                Instantiate(DataHandler.Instance.furniture, pose.position, pose.rotation);
            }
        }

    }

    private bool IsPointerOverUI(Touch touch)
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = new Vector2(touch.position.x, touch.position.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        return results.Count > 0;
    }

}
