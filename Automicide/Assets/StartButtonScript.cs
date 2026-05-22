using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class StartButtonScript : MonoBehaviour
{
    private Camera mainCamera;
    private bool currentlyOver;
    private void Awake()
    {        if (mainCamera == null)
            mainCamera = Camera.main;
    }
    void Start()
    {
    }
    void Update()
    {
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            DetectClick();
        }
        Vector2 mouseWorldPos = mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        RaycastHit2D hit = Physics2D.Raycast(mouseWorldPos, Vector2.zero);
        currentlyOver = hit.collider != null && hit.collider.gameObject == gameObject;
        if (currentlyOver)
        {
            GearScript.isOver = true;
        }
        else
        {
            GearScript.isOver = false;
        }
    }
    private void DetectClick()
    {
        // Convert mouse position to a ray
        Vector2 mousePos = Mouse.current.position.ReadValue();
        Vector2 worldPos = mainCamera.ScreenToWorldPoint(mousePos);

        RaycastHit2D hit = Physics2D.Raycast(worldPos, Vector2.zero);
        if (hit.collider != null && hit.collider.gameObject == gameObject)
        {
            GearScript.isPressed = true;
        }
    }
}
