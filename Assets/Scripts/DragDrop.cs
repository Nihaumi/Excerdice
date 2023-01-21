using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    [SerializeField] private float dist;
    [SerializeField] private bool dragging = false;
    [SerializeField] private Vector3 offset;
    [SerializeField] private Transform ToDrag;
    [SerializeField] Camera ARcam;


    // Update is called once per frame
    [SerializeField]
    private void Update()
    {
        Vector3 vector3;
        if (Input.touchCount != 1)
        {
            dragging = false;
            return;
        }
        Touch touch = Input.touches[0];
        Vector3 pos = touch.position;

        if(touch.phase == TouchPhase.Began)
        {
            Ray ray = Camera.current.ScreenPointToRay(pos);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                ToDrag = hit.transform;
                dist = hit.transform.position.z - Camera.current.transform.position.z;
                vector3 = new Vector3(pos.x, pos.y, dist);
                vector3 = Camera.current.ScreenToWorldPoint(vector3);
                offset = ToDrag.position - vector3;
                dragging = true;
            }
        }

        if (dragging & touch.phase == TouchPhase.Moved) 
        {
            vector3 = new Vector3(Input.mousePosition.x, Input.mousePosition.y, dist);
            vector3 = Camera.current.ScreenToWorldPoint(vector3);
            ToDrag.position = vector3 + offset;
        }

        if(dragging && (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled))
        {
            dragging = false;
        }
    }
}
