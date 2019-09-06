using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

  Rigidbody2D rigid2D;
  float jumpForce = 680.0f;
  float walkForce = 30.0f;
  float maxWalkSpeed = 2.0f;
  // Start is called before the first frame update
  void Start()
  {
    this.rigid2D = GetComponent<Rigidbody2D>();
  }

  // Update is called once per frame
  void Update()
  {
    //   jump
    if (Input.GetKeyDown(KeyCode.Space))
    {
      this.rigid2D.AddForce(transform.up * this.jumpForce);
    }
    // move right or left
    int key = 0;
    if (Input.GetKey(KeyCode.RightArrow)) key = 1;
    if (Input.GetKey(KeyCode.LeftArrow)) key = -1;

    // speed
    float speedx = Mathf.Abs(this.rigid2D.velocity.x);

    // limit speed
    if (speedx < this.maxWalkSpeed)
    {
      this.rigid2D.AddForce(transform.right * key * this.walkForce);
    }

    // change direction
    if (key != 0)
    {
      transform.localScale = new Vector3(key, 1, 1);
    }

  }
}
