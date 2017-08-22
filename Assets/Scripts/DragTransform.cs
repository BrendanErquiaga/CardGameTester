using System.Collections;
using UnityEngine;

class DragTransform : MonoBehaviour
{
    [SerializeField]
    private Color mouseOverColor = Color.blue;
    [SerializeField]
    private Color originalColor = Color.yellow;
    private bool dragging = false;
    private float distance;

    private Renderer selfRenderer;

    private void Awake()
    {
        selfRenderer = this.gameObject.GetComponent<Renderer>();
    }

    void OnMouseEnter()
    {
        Debug.Log("Halp: " + this.gameObject.name, gameObject);
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