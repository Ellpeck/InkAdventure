using JetBrains.Annotations;
using UnityEngine;

public class Pufferfish : MonoBehaviour {

    private static readonly int AnimatorPuff = Animator.StringToHash("Puff");
    private static readonly int AnimatorUnpuff = Animator.StringToHash("Unpuff");

    public float transformDistance;
    public Collider2D normalCollider;
    public Collider2D puffedCollider;
    public Sprite puffedSprite;
    public Sprite unpuffedSprite;

    private new SpriteRenderer renderer;
    private Animator animator;
    private GameObject player;
    private bool isPuffed;

    private float waitTime;

    private void Start() {
        this.renderer = this.GetComponentInChildren<SpriteRenderer>();
        this.animator = this.GetComponent<Animator>();
        this.player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update() {
        if (this.waitTime <= 0) {
            var close = Vector2.Distance(this.player.transform.position, this.transform.position) <= this.transformDistance;
            if (close != this.isPuffed) {
                this.isPuffed = close;
                this.waitTime = 1F;

                this.normalCollider.enabled = !close;
                this.puffedCollider.enabled = close;
                this.animator.SetTrigger(close ? AnimatorPuff : AnimatorUnpuff);
            }
        } else {
            this.waitTime -= Time.deltaTime;
        }
    }

    [UsedImplicitly]
    public void ChangeSprite() {
        this.renderer.sprite = this.isPuffed ? this.puffedSprite : this.unpuffedSprite;
    }

}