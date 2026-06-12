using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float runSpeed = 5f;
    public float sideSpeed = 4f;
    public float sideLimit = 10.762f;
    public float planeCenterZ = 8.9f;
    public Animator animator;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    void FixedUpdate()
    {
        float moveZ = Input.GetAxis("Horizontal");
        rb.velocity = new Vector3(-runSpeed, rb.velocity.y, moveZ * sideSpeed);

        Vector3 pos = rb.position;
        pos.z = Mathf.Clamp(pos.z, planeCenterZ - sideLimit, planeCenterZ + sideLimit);
        rb.MovePosition(pos);

        if (animator != null)
            animator.SetBool("isRunning", true);
    }
}
