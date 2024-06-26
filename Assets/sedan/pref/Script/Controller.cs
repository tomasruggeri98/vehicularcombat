using UnityEngine;

public class CarController : MonoBehaviour
{
    public WheelCollider frontLeftWheel;
    public WheelCollider frontRightWheel;
    public WheelCollider rearLeftWheel;
    public WheelCollider rearRightWheel;

    public float maxMotorTorque = 1500f;
    public float maxSteeringAngle = 30f;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Ajustar el centro de masa para mejorar la estabilidad
        rb.centerOfMass = new Vector3(0, -0.9f, 0);
    }

    private void FixedUpdate()
    {
        // Obtener entrada del jugador y ajustar la dirección de los controles
        float motor = -maxMotorTorque * Input.GetAxis("Vertical"); // Invertir el eje vertical
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal"); // Mantener el eje horizontal como está

        // Aplicar fuerzas a las ruedas delanteras
        frontLeftWheel.steerAngle = steering;
        frontRightWheel.steerAngle = steering;

        frontLeftWheel.motorTorque = motor;
        frontRightWheel.motorTorque = motor;

        // Aplicar fuerza de frenado
        ApplyBrakes();
    }

    private void ApplyBrakes()
    {
        float brakeTorque = Input.GetKey(KeyCode.Space) ? 3000f : 0f;

        frontLeftWheel.brakeTorque = brakeTorque;
        frontRightWheel.brakeTorque = brakeTorque;
        rearLeftWheel.brakeTorque = brakeTorque;
        rearRightWheel.brakeTorque = brakeTorque;
    }
}
