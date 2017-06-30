using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    [SerializeField] FXManager m_fxManager;
    [SerializeField] Rigidbody m_rigidbody;
    public bool m_grounded = false;

    // Jumping
    bool m_jump = false;
    float m_jumpForce = 6f;

    // Movement
    float m_speed;
    float m_lookSpeed = 1f;
    Vector3 m_velocity = Vector3.zero;
    Vector3 m_rotation = Vector3.zero;

    // Gravity Beam    
    public bool m_fireBeam = false;
    RaycastHit m_myhit;
    float m_beamForce;
    float m_moveSpeed = 5;
    float m_range = 32;
    public bool m_beamPush = false;
    [SerializeField] GameObject m_anchorPoint;
    bool m_hasSetAnchorPoint = false;
    
    //Camera
    Vector3 m_cameraRotation = Vector3.zero;
    [SerializeField] Camera m_cam;

    // Cursor
    public bool m_inputAllowed;

    public float GetRange(){ return m_range; }
	
    void Start() {
        m_inputAllowed = true;
        if(m_rigidbody == null) {
            m_rigidbody = GetComponent<Rigidbody>();
        }
        if(m_fxManager == null) {
            m_fxManager = GetComponent<FXManager>();
        }
    }

    void Update() {
        if (m_inputAllowed) {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            if (Input.GetButtonDown("Cancel")) {
                Time.timeScale = 0;
                m_inputAllowed = false;
            }             
            InputHandler();
            PlayerMovement();
            MouseAiming();
            HandleJumping();
        } else {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            if (Input.GetButtonDown("Cancel")) {
                Time.timeScale = 1;
                m_inputAllowed = true;
            }
        }
    }

    void FixedUpdate() {
        if (m_inputAllowed) {
            PerformMovement();
            PerformRotation();
        }
        if(m_fireBeam) {
            FireBeam();
        }
    }
    
    void OnCollisionEnter(Collision other) {
        if (other.collider.tag == "Ground" || other.collider.tag == "PushPull" || other.collider.tag == "Foldable" || other.collider.tag == "Trigger") {
            m_grounded = true;
        }
    }

    void InputHandler() {
        if(Input.GetKey(KeyCode.LeftShift)) {
            m_speed = 8f;
        } else {
            m_speed = 5f;
        }
        if(Input.GetKeyDown(KeyCode.Space) && m_grounded) {
            m_jump = true;
        }
        if (Input.GetButton("Fire1")) {
            m_beamPush = true;
            m_fireBeam = true;
        } else if(Input.GetButton("Fire2")) {
            m_beamPush = false;
            m_fireBeam = true;
        } else {
            m_fireBeam = false;
        }
    }

    void PlayerMovement() {
        float xMove = Input.GetAxisRaw("Horizontal");
        float zMove = Input.GetAxisRaw("Vertical");

        Vector3 moveHorizontal = transform.right * xMove;
        Vector3 moveVertical = transform.forward * zMove;
        Vector3 velocity = (moveHorizontal + moveVertical).normalized * m_speed;
        Move(velocity);
                
        float yRotation = Input.GetAxisRaw("Mouse X") * 2f;
        Vector3 rotation = new Vector3(0f, yRotation * m_lookSpeed, 0f);
        Rotate(rotation);
    }

    void HandleJumping() {
        if(m_jump) {
            Jump();
            m_jump = false;
        }
    }

    void FireBeam() {
        // Cast Ray
        Vector3 spawnPosition = new Vector3();
        Vector3 direction = new Vector3();
        spawnPosition = m_cam.transform.position;
        direction = m_cam.transform.forward;
        Ray myRay = new Ray(spawnPosition, direction);
        Physics.Raycast(myRay, out m_myhit, m_range);

        // Collision Check
        if(m_myhit.collider != null) {
            if(m_myhit.collider.CompareTag("PushPull")) {
                
                // Push/Pull Object Functionality
                if(m_beamPush) {
                    m_beamForce = 1f;
                } else {
                    m_beamForce = -1f;
                }

                float move = m_moveSpeed * m_beamForce;
                
                if (m_myhit.rigidbody != null) {
                    m_myhit.rigidbody.rotation = m_rigidbody.rotation;
                    m_myhit.rigidbody.position += (m_myhit.transform.forward * move) * Time.fixedDeltaTime;
                }
                
                // Add force to object
                // if (m_myhit.rigidbody != null) {
                //     m_myhit.rigidbody.AddForceAtPosition(myRay.direction * 700, m_myhit.point);
                // }
            } 
            if(m_myhit.collider.CompareTag("Trigger")) {

                m_anchorPoint = m_myhit.transform.gameObject;

                // Push/Pull Object Functionality
                if(m_beamPush) {
                    m_beamForce = 1f;
                } else {
                    m_beamForce = -1f;
                }

                WallMover wallMover = m_anchorPoint.GetComponentInParent<WallMover>();
                wallMover.m_moveForce = m_beamForce;
                wallMover.m_triggerActive = true;
            }
            if(m_myhit.collider.CompareTag("Foldable")) {

                m_anchorPoint = m_myhit.transform.gameObject;
            
                // Push/Pull Object Functionality
                if(m_beamPush) {
                    m_beamForce = 1f;
                } else {
                    m_beamForce = -1f;
                }
                m_myhit.transform.gameObject.GetComponent<Folding>().m_targeting = true;
                m_myhit.transform.gameObject.GetComponent<Folding>().SetBeamForce(m_beamForce);
            }         
        } 
    }

    // Player movement

    void Move(Vector3 velocity) {
        m_velocity = velocity;
    }

    void Jump() {
        m_grounded = false;
		m_rigidbody.velocity = new Vector3(0, m_jumpForce, 0);
	}

    void PerformMovement() {
        if (m_velocity != Vector3.zero) {
            m_rigidbody.MovePosition(transform.position + m_velocity * Time.fixedDeltaTime);
        }
    }

    void Rotate(Vector3 rotation) {
        m_rotation = rotation;
    }

    void PerformRotation() {
        m_rigidbody.MoveRotation(m_rigidbody.rotation * Quaternion.Euler(m_rotation));
        if (m_cam != null) {
            m_cam.transform.Rotate(m_cameraRotation * Time.fixedDeltaTime);
        }
    }

    void MouseAiming() {        
        float xRotation = Input.GetAxisRaw("Mouse Y") * 2f;
        Vector3 rotation = new Vector3(-xRotation * m_lookSpeed, 0f, 0f);
        m_cam.transform.Rotate(rotation);
    } 
}

