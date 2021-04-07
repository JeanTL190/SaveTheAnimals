using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairController : MonoBehaviour
{
    [SerializeField] private Canvas parentCanvas;

    private RectTransform rt;
    private Vector2 oldPosition, currentPosition, newPosition;

    private Vector2 lastInputEvent;
    private float inputLagTimer;

    [SerializeField] private float inputLagPeriod;
    [Range(0f, 100.0f)]
    [SerializeField] float sensitivity = 70f;

    private void Awake ()
    {
        rt = gameObject.GetComponent<RectTransform>();
        lastInputEvent = Vector2.zero;
    }

    private Vector2 GetMousePos ()
    {
        return Input.mousePosition;
    }

    private void Update ()
    {

        Vector2 movePos;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(parentCanvas.transform as RectTransform, Input.mousePosition, parentCanvas.worldCamera, out movePos);

        Vector3 mousePos = gameObject.transform.TransformPoint(movePos);

        //Move the Object/Panel
        transform.position = mousePos;


    }
}
