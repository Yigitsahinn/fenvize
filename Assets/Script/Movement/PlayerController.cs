using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform model;
    [SerializeField] private float turnSpeed = 360f;

    private Vector3 input;
    PlayerStats stats;
    PlayerAttackScript attackScript;
    private void Awake()
    {
        stats = GetComponent<PlayerStats>();
        attackScript = GetComponent<PlayerAttackScript>();
    }
    private void Update()
    {
        if (attackScript.canMove == true)
        {
            GatherInput();
            Look();
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void GatherInput()
    {
        input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    }

    private void Look()
    {
        if (input == Vector3.zero) return;

        Quaternion rot = Quaternion.LookRotation(input.ToIso(), Vector3.up);
        model.rotation = Quaternion.RotateTowards(model.rotation, rot, turnSpeed * Time.deltaTime);
    }

    private void Move()
    {
        if(attackScript.canMove == true)
        {
            rb.MovePosition(transform.position + input.ToIso() * input.normalized.magnitude * stats.speed * Time.deltaTime);
        }
    }
}

public static class Helpers
{
    private static Matrix4x4 _isoMatrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));
    public static Vector3 ToIso(this Vector3 input) => _isoMatrix.MultiplyPoint3x4(input);
}

