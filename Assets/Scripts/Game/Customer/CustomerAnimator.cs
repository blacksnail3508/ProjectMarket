using UnityEngine;

public class CustomerAnimator : MonoBehaviour
{
    [SerializeField] Animator animator;
    float rotationSpeed = 10f;
    Vector3 moveDirection;
    private void FixedUpdate()
    {
        RotateTowardsMovementDirection(moveDirection);
    }
    public void SetDirection(Vector3 direction)
    {
        this.moveDirection=direction;
    }
    void RotateTowardsMovementDirection(Vector3 moveDirection)
    {
        if (moveDirection!=Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation=Quaternion.Slerp(transform.rotation , targetRotation , rotationSpeed*Time.fixedDeltaTime);
        }
    }
    public void SetEmty(bool isEmty)
    {
        animator.SetBool("IsEmpty" , isEmty);
    }
    public void PlayMove()
    {
        animator.SetBool("IsMove" , true);
    }
    public void StopMove()
    {
        animator.SetBool("IsMove" , false);
    }
    public void PlayCarry()
    {
        animator.SetBool("IsEmpty" , false);
    }
    public void StopCarry()
    {
        animator.SetBool("IsEmpty" , true);
    }
    public void PlayIdle()
    {
        animator.SetBool("IsEmpty" , true);
        animator.SetBool("IsMove" , false);
    }
}
