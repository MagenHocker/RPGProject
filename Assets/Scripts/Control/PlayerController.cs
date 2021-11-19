using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;

namespace RPG.Control
{
    public class PlayerController : MonoBehaviour
    {
        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButton(0))
            {
                MoveToCursor();
            }
        }

        // Move Player to the 3D space where the player has clicked in 2D space with a ray  
        private void MoveToCursor()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            bool hasHit = Physics.Raycast(ray, out hit);

            if (hasHit)
            {
                GetComponent<Mover>().MoveTo(hit.point);
            }
        }
    }
}
