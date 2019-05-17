using System;
using UnityEngine;

public class Inky : MonoBehaviour {

    private static readonly int AnimatorSwim = Animator.StringToHash("Swim");

    public float moveSpeed;

    private Animator animator;
    private Rigidbody2D body;
    private Camera mainCamera;

    private bool swim;

    private void Start() {
        this.animator = this.GetComponent<Animator>();
        this.body = this.GetComponent<Rigidbody2D>();
        this.mainCamera = Camera.main;
    }

    private void Update() {
        var mouse = this.mainCamera.ScreenToWorldPoint(Input.mousePosition);
        var trans = this.transform;
        var position = trans.position;
        trans.up = new Vector3(mouse.x - position.x, mouse.y - position.y);

        if (Input.GetMouseButton(0))
            this.animator.SetTrigger(AnimatorSwim);
    }

    public void Swim() {
        this.body.AddRelativeForce(new Vector2(0, this.moveSpeed));
    }

}