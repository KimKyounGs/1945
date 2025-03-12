using UnityEngine;

public class Player : MonoBehaviour
{   
    public float speed = 5f;
    private Vector2 minBounds;
    private Vector2 maxBounds;

    Animator ani; //애니메이터를 가져올 변수

    void Start()
    {
        ani = GetComponent<Animator>();
        // 화면의 경계를 설정
        Camera cam = Camera.main;
        Vector3 bottomLeft = cam.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector3 topRight = cam.ViewportToWorldPoint(new Vector3(1, 1, 0));

        minBounds = new Vector2(bottomLeft.x, bottomLeft.y);
        maxBounds = new Vector2(topRight.x, topRight.y);
        
    }

    void Update()
    {
        // 플레이어 이동
        float moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float moveY = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        // -1   0   1
        if (Input.GetAxis("Horizontal") <= -0.05f)
            ani.SetBool("left", true);
        else
            ani.SetBool("left", false);


        if (Input.GetAxis("Horizontal") >= 0.05f)
            ani.SetBool("right", true);
        else
            ani.SetBool("right", false);


        if(Input.GetAxis("Vertical")>=0.5f)
        {
            ani.SetBool("up", true);
        }
        else
        {
            ani.SetBool("up", false);
        }



        Vector3 newPosition = transform.position + new Vector3(moveX, moveY, 0);

        // 경계를 벗어나지 않도록 위치 제한
        newPosition.x = Mathf.Clamp(newPosition.x, minBounds.x, maxBounds.x);
        newPosition.y = Mathf.Clamp(newPosition.y, minBounds.y, maxBounds.y);

        transform.position = newPosition;
    }
}
