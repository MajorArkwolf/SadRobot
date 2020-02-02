using UnityEngine;
using System.Collections;
using Prime31;


public class PlayerPhysics : MonoBehaviour {
	// movement config
	public float gravity = -25f;
	public float runSpeed = 8f;
	public float pushSpeed = 4f;
	public float groundDamping = 20f; // how fast do we change direction? higher means faster
	public float inAirDamping = 5f;
	public float jumpHeight = 3f;
	public float pickupReset = 0.50f;


	[HideInInspector]
	private float normalizedHorizontalSpeed = 0;

	private CharacterController2D _controller;
	private Animator _animator;
	private RaycastHit2D _lastControllerColliderHit;
	private Vector3 _velocity;
	private GameObject block;
	private float blockPickupTime;
	private float blockGap = 2.25f;
	private Rigidbody2D _rb2d;


	void Awake() {
		_animator = GetComponent<Animator>();
		_controller = GetComponent<CharacterController2D>();
		_rb2d = GetComponent<Rigidbody2D>();

		// listen to some events for illustration purposes
		_controller.onControllerCollidedEvent += onControllerCollider;
		_controller.onTriggerEnterEvent += onTriggerEnterEvent;
		_controller.onTriggerExitEvent += onTriggerExitEvent;
		_controller.onTriggerStayEvent += onTriggerStayEvent;
	}


	#region Event Listeners

	void onControllerCollider(RaycastHit2D hit) {
		// bail out on plain old ground hits cause they arent very interesting
		if (hit.normal.y == 1f)
			return;

		// logs any collider hits if uncommented. it gets noisy so it is commented out for the demo
		//Debug.Log( "flags: " + _controller.collisionState + ", hit.normal: " + hit.normal );
	}


	void onTriggerEnterEvent(Collider2D col) {
		//Debug.Log("onTriggerEnterEvent: " + col.gameObject.name);
	}


	void onTriggerExitEvent(Collider2D col) {
		//Debug.Log("onTriggerExitEvent: " + col.gameObject.name);
	}

    void onTriggerStayEvent(Collider2D col) {
		if (col.tag == "Pushable") {
			if (Input.GetKey(KeyCode.RightArrow)) {
				col.GetComponent<InteractivePhysics>()._velocity +=
	                new Vector3(pushSpeed, 0, 0);
			} else if (Input.GetKey(KeyCode.LeftArrow)) {
				col.GetComponent<InteractivePhysics>()._velocity -=
	                new Vector3(pushSpeed, 0, 0);
			}

            if (Input.GetKey(KeyCode.Space) && Time.time > blockPickupTime + pickupReset) {
				block = col.gameObject;
				blockPickupTime = Time.time;
            }
		}
	}

	#endregion


	// the Update loop contains a very simple example of moving the character around and controlling the animation
	void Update() {
        if (block != null) {
			var pos = transform.position;
			pos.y += blockGap;
			block.transform.position = pos;
			block.GetComponent<InteractivePhysics>()._velocity = Vector3.zero;
		}

        if (block != null && Time.time > blockPickupTime + pickupReset &&
			Input.GetKey(KeyCode.Space)) {
			var isLeft = this.transform.lossyScale.x > 0 ? true : false;
			var xOffset = isLeft ? 2.0f : -2.0f;

			block.transform.position = transform.position + new Vector3(xOffset, blockGap, 0.0f);
			block = null;
        }

		if (_controller.isGrounded)
			_velocity.y = 0;

		if (Input.GetKey(KeyCode.RightArrow)) {
			normalizedHorizontalSpeed = 1;


			if (transform.localScale.x < 0f)
				//transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);

			if (_controller.isGrounded) {
				//_animator.Play(Animator.StringToHash("Run"));
			}
		} else if (Input.GetKey(KeyCode.LeftArrow)) {
			normalizedHorizontalSpeed = -1;


			if (transform.localScale.x > 0f)
				//transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);

			if (_controller.isGrounded) {
				//_animator.Play(Animator.StringToHash("Run"));
			}
		} else {
			normalizedHorizontalSpeed = 0;

			// Might be idle, no input

			if (_controller.isGrounded) {
				//_animator.Play(Animator.StringToHash("Idle"));
			}
		}


		// we can only jump whilst grounded
		if (_controller.isGrounded && Input.GetKeyDown(KeyCode.UpArrow)) {
			_velocity.y = Mathf.Sqrt(2f * jumpHeight * -gravity);
			transform.SetParent(null);
			//_animator.Play(Animator.StringToHash("Jump"));
		}

		// apply horizontal speed smoothing it. dont really do this with Lerp. Use SmoothDamp or something that provides more control
		var smoothedMovementFactor = _controller.isGrounded ? groundDamping : inAirDamping; // how fast do we change direction?
		_velocity.x = Mathf.Lerp(_velocity.x, normalizedHorizontalSpeed * runSpeed, Time.deltaTime * smoothedMovementFactor);

		// apply gravity before moving
		_velocity.y += gravity * Time.deltaTime;

		// if holding down bump up our movement amount and turn off one way platform detection for a frame.
		// this lets us jump down through one way platforms
		if (_controller.isGrounded && Input.GetKey(KeyCode.DownArrow)) {
			_velocity.y *= 3f;
			_controller.ignoreOneWayPlatformsThisFrame = true;
		}

		_controller.move(_velocity * Time.deltaTime);


		if (Mathf.Abs(_velocity.x) > 0.01f)
		{
			_animator.SetBool("idle", false);
			if (_velocity.x > 0f)
			{
				_animator.SetBool("right", true);
			}
			else if (_velocity.x < 0f)
			{
				_animator.SetBool("right", false);
			}
		}
		else
		{
			//Debug.Log("idled");
			_animator.SetBool("idle", true);
		}

		// grab our current _velocity to use as a base for all calculations
		_velocity = _controller.velocity;
	}

}
