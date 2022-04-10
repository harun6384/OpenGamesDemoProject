using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;
    
    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        float strafeMovement = Input.GetAxis("Horizontal");
        float forwardMovement = Input.GetAxis("Vertical");

        // Karakter hareketi ve yönü
        Vector3 movementDirection = new Vector3(strafeMovement, 0, forwardMovement);
        movementDirection.Normalize();
        
        transform.Translate(movementSpeed * Time.deltaTime * movementDirection, Space.World);

        // Dönüþ hýzýný yumuþatma
        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        // Karakter animasyon kontrolü
        if (strafeMovement != 0 || forwardMovement != 0 )
        {
            _animator.SetFloat("movementSpeed", 0.3f);
        }
        else
        {
            _animator.SetFloat("movementSpeed", 0f);
        }
    }
}
