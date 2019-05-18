using System;
using UnityEngine;

public class TargetPlayer : MonoBehaviour {

    public float speed;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D body;
    private GameObject player;

    private void Start() {
        this.spriteRenderer = this.GetComponentInChildren<SpriteRenderer>();
        this.body = this.GetComponent<Rigidbody2D>();
        this.player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update() {
        var trans = this.transform;
        var myPos = trans.position;
        var playerPos = this.player.transform.position;

        var dist = new Vector3(playerPos.x - myPos.x, playerPos.y - myPos.y);
        this.spriteRenderer.flipY = dist.x < 0;
        trans.right = dist;
    }

    private void FixedUpdate() {
        this.body.AddRelativeForce(new Vector2(this.speed, 0));
    }

}