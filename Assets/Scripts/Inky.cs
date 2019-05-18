using System;
using JetBrains.Annotations;
using UnityEngine;

public class Inky : MonoBehaviour {

    private static readonly int AnimatorSwim = Animator.StringToHash("Swim");
    private static readonly int AnimatorShoot = Animator.StringToHash("Shoot");

    public float moveSpeed;
    public ParticleSystem ink;

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

        if (Input.GetMouseButtonDown(0))
            this.animator.SetTrigger(AnimatorSwim);
        else if (Input.GetMouseButtonDown(1))
            this.animator.SetTrigger(AnimatorShoot);
    }

    [UsedImplicitly]
    public void Swim() {
        this.body.AddRelativeForce(new Vector2(0, this.moveSpeed));
    }

    [UsedImplicitly]
    public void Shoot() {
        var trans = this.transform;
        Instantiate(this.ink, trans.position, trans.rotation);
    }

}