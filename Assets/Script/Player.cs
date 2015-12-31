using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    [SerializeField]
    float speed = 1;

    [SerializeField]
    float jumpPower = 1;

    Rigidbody2D _rigid2D;
    bool isGround;
    BoxCollider2D _col2D;
	// Use this for initialization
	void Start () {
        _rigid2D = gameObject.GetComponent<Rigidbody2D>();
        _col2D = gameObject.GetComponent<BoxCollider2D>();
	}

	// Update is called once per frame
	void FixedUpdate () {
        Vector2 groundCheck = new Vector2(transform.position.x, transform.position.y - (1.5f * transform.lossyScale.y));
        Vector2 groundArea = new Vector2(_col2D.size.x / 2.2f, 0.05f);
        isGround = Physics2D.OverlapArea(groundCheck + groundArea, groundCheck - groundArea, 1 << LayerMask.NameToLayer("Stage"));
        Move(Input.GetAxis("Horizontal"), Input.GetButtonDown("Jump"));
	}

    void Move(float moveDir, bool jump)
    {
        _rigid2D.velocity = new Vector2(moveDir * speed, _rigid2D.velocity.y);
        if (jump && isGround)
        {
            _rigid2D.AddForce(Vector2.up * jumpPower);
        }
    }
}
