using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterMovement : MonoBehaviour
{

    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = 0.05f;
	Rigidbody2D m_Rigidbody2D;
	Vector3 m_Velocity = Vector3.zero;

    //Used to setup components from current object (here player), 
    //start is used for other components from other objects
	void Awake()
	{
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
	}

	public void Move(float move)
	{
        // Move the character by finding the target velocity
        Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
		// And then smoothing it out and applying it to the character
        m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
	}
}
