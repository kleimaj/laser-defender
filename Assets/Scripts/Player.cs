using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] float moveSpeed = 10f;

    float xMin;
    float xMax;
    float yMin;
    float yMax;
    // Start is called before the first frame update
    void Start() {
        SetUpMoveBoundaries();
    }

    private void SetUpMoveBoundaries() {
        Camera gameCamera = Camera.main;
        // get minimum x world space value
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        // get maximum x world space 
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        // get minimum y world space value
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
        // get maximum y world space 
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;

    }

    // Update is called once per frame
    void Update() {
        Move();
    }

    private void Move() {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        var newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);
        transform.position = new Vector2(newXPos, newYPos);
    }
}
