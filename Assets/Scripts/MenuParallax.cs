using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuParallax : MonoBehaviour
{
  // referenced Raycastly's parallax
  public float offsetMultiplier = 1f;
  public float smoothTime = 0.3f;

  private Vector2 startPosition;
  private Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
      startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
      Vector2 offset = Camera.main.ScreenToViewportPoint(Input.mousePosition);
    transform.position = Vector3.SmoothDamp(transform.position, startPosition + (offset * offsetMultiplier), ref velocity, smoothTime);
    }
}
