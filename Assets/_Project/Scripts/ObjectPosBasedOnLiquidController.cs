using Unity.Mathematics;
using UnityEngine;

namespace LiquidSimulation.Core
{


    [ExecuteAlways]
    public class ObjectPosBasedOnLiquidController : MonoBehaviour
    {
        //this component is added to a Cup in order to control the position of one of the gameobjects,
        //it ensures their position is relatively correct to the cup currnt filled amount.

        //it is mainly used for the foam and collider positions.
        [SerializeField] Transform objectToControl;
        [SerializeField] LiquidBeaker liquidBeaker;

        [SerializeField] bool AlwaysLookUp = true;

        [SerializeField] float minHeight = -0.35f;
        [SerializeField] float maxHeight = 0.35f;

        [SerializeField] float xOffset = 0f;
        [SerializeField] float zOffset = 0f;

        void Update()
        {
            UpdateFoamVisuals();
        }

        void UpdateFoamVisuals()
        {

            if (objectToControl && liquidBeaker)
            {
                objectToControl.localPosition = new Vector3(xOffset, (float)math.remap(0, 1, minHeight, maxHeight, liquidBeaker.FilledAmount), zOffset);

                if (AlwaysLookUp)
                    objectToControl.transform.up = Vector3.up;


            }
        }
    }
}