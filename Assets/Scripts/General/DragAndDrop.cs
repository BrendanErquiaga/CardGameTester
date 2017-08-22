using System.Collections;
using UnityEngine;

class DragAndDrop : MonoBehaviour
{
    [SerializeField]
    private Color mouseOverColor = Color.blue;
    private Color originalColor;
    private bool dragging = false;
    private float distance;

    private Renderer selfRenderer;

    private void Awake()
    {
        selfRenderer = this.gameObject.GetComponent<Renderer>();
        this.originalColor = selfRenderer.material.color;
    }

    void OnMouseEnter()
    {
        selfRenderer.material.color = mouseOverColor;
    }

    void OnMouseExit()
    {
        selfRenderer.material.color = originalColor;
    }

    void OnMouseDown()
    {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        dragging = true;
    }

    void OnMouseUp()
    {
        dragging = false;
    }

    void Update()
    {
        if (dragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            transform.position = rayPoint;
        }
    }
}