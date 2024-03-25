using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    [SerializeField] GameConfig gameConfig;
    [SerializeField] Rigidbody rb;
    [SerializeField] Animator animator;
    Vector3 moveDirection;
    float rotationSpeed = 10f;
    private void Update()
    {
        RotateTowardsMovementDirection(moveDirection);
    }
    void FixedUpdate()
    {
        Move(moveDirection);
        animator.SetBool("IsMove" , rb.velocity.magnitude!=0);
    }

    void Move(Vector3 moveDirection)
    {
        rb.velocity=moveDirection*gameConfig.CharacterMovementSpeed;
    }

    void RotateTowardsMovementDirection(Vector3 moveDirection)
    {
        if (moveDirection!=Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation=Quaternion.Slerp(transform.rotation , targetRotation , rotationSpeed*Time.fixedDeltaTime);
        }
    }

    public void SetDirection(Vector3 direction)
    {
        this.moveDirection=direction;
    }
    public void SetEmty(bool isEmty)
    {
        animator.SetBool("IsEmpty" , isEmty);
    }
}
