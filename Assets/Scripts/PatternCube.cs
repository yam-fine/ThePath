using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternCube : MonoBehaviour
{
    private Animator m_animator;
    // Start is called before the first frame update
    void Start()
    {
        m_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void StopCube()
    {
        m_animator.enabled = false;
    }
    public void StartCube()
    {
        m_animator.enabled = true;
    }
}
