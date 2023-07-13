using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float flySpeed = 5f;        // 飞行速度
    public float sprintSpeed = 10f;    // 冲刺速度
    public float sprintDuration = 2f;  // 冲刺持续时间
    public float flapForce = 5f;       // 上升力度

    private bool isSprinting = false;  // 是否正在冲刺
    private float sprintTimer = 0f;    // 冲刺计时器

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // 获取玩家输入
        float moveHorizontal = Input.GetAxis("Horizontal");
        bool sprintInput = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        bool flapInput = Input.GetKey(KeyCode.Space);

        // 设置移动速度
        float speed = isSprinting ? sprintSpeed : flySpeed;
        Vector2 movement = new Vector2(moveHorizontal * speed, rb.velocity.y);
        rb.velocity = movement;

        // 上升逻辑
        if (flapInput)
        {
            rb.AddForce(Vector2.up * flapForce, ForceMode2D.Impulse);
        }

        // 冲刺逻辑
        if (sprintInput && !isSprinting)
        {
            StartSprint();
        }

        // 冲刺计时
        if (isSprinting)
        {
            sprintTimer += Time.deltaTime;
            if (sprintTimer >= sprintDuration)
            {
                EndSprint();
            }
        }
    }

    private void StartSprint()
    {
        isSprinting = true;
        sprintTimer = 0f;
        // 在这里可以添加冲刺时的特效或音效等
    }

    private void EndSprint()
    {
        isSprinting = false;
        // 在这里可以添加冲刺结束时的处理逻辑
    }
}
