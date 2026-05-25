using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TopDownRace
{
    public class InputControl : MonoBehaviour
    {

        //--inputs
        [HideInInspector]
        public Vector3 m_Movement;

        public static InputControl m_Main;

        void Awake()
        {
            m_Main = this;
        }
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            m_Movement = Vector3.zero;


            m_Movement.x = Input.GetAxis("Horizontal");
            m_Movement.y = Input.GetAxis("Vertical");



            m_Movement = Vector3.ClampMagnitude(m_Movement, 1.0f);
        }
    }
}