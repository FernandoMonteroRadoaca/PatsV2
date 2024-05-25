using UnityEngine;

public class PettingScript : MonoBehaviour
{
    //Provisional
    public GameObject targetObject; // El objeto que será acariciado
    public float requiredDistance = 100f; // La distancia que debe recorrer el ratón para activar el booleano

    private Vector3 lastMousePosition;
    private float totalDistance = 0f;
    private bool isDragging = false;
    public bool isPetted = false;

    void Update()
    {
        if (targetObject == null)
        {
            Debug.LogWarning("No se ha asignado un objeto de destino en el Inspector.");
            return;
        }

        if (isDragging)
        {
            if (Input.GetMouseButton(0))
            {
                Vector3 currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                currentMousePosition.z = 0; // Asegurarse de que la posición z es cero ya que es 2D

                // Calcular la distancia recorrida
                totalDistance += Vector3.Distance(currentMousePosition, lastMousePosition);
                lastMousePosition = currentMousePosition;

                // Verificar si la distancia recorrida es suficiente
                if (totalDistance >= requiredDistance)
                {
                    isPetted = true;
                    isDragging = false;
                }
            }
            else
            {
                isDragging = false;
            }
        }
    }

    void OnMouseDown()
    {
        if (targetObject == null) return;

        if (IsMouseOverTarget())
        {
            isDragging = true;
            lastMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            lastMousePosition.z = 0; // Asegurarse de que la posición z es cero ya que es 2D
            totalDistance = 0f;
        }
    }

    void OnMouseUp()
    {
        isDragging = false;
    }

    bool IsMouseOverTarget()
    {
        if (targetObject == null) return false;

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // Asegurarse de que la posición z es cero ya que es 2D

        Collider2D targetCollider = targetObject.GetComponent<Collider2D>();
        if (targetCollider == null) return false;

        return targetCollider.OverlapPoint(mousePosition);
    }
}
