using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class MovementAuthoring : MonoBehaviour
{
    public class Baker : Baker<MovementAuthoring>
    {
        public override void Bake(MovementAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new Movement
            {
                movementVector = new float3(UnityEngine.Random.Range(-1, 1), 0, UnityEngine.Random.Range(-1, 1))
            });
        }
    }
}

public struct Movement : IComponentData
{
    public float3 movementVector;
}