using UnityEngine;

public class Rotate : MonoBehaviour
{
    public Transform target;   // Zielobjekt, um das die Kamera rotieren soll
    public float distance = 5f; // Abstand zur Kamera
    public float rotationSpeed = 20f; // Drehgeschwindigkeit in Grad pro Sekunde
    public float height = 1f;
    private float currentAngle = 0f;

    void Update()
    {
        if (target == null)
            return;

        // Winkel erhöhen
        currentAngle += rotationSpeed * Time.deltaTime;
        if (currentAngle > 360f)
            currentAngle -= 360f;

        // Neue Kameraposition berechnen
        float rad = currentAngle * Mathf.Deg2Rad;
        Vector3 offset = new Vector3(Mathf.Sin(rad), height, Mathf.Cos(rad)) * distance;

        transform.position = target.position + offset;
        transform.LookAt(target);
    }
}
