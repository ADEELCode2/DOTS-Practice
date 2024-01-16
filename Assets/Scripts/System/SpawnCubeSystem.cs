using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

public partial class SpawnCubeSystem : SystemBase
{

    protected override void OnCreate()
    {
        RequireForUpdate<SpawnCubeConfig>();
    }

    protected override void OnUpdate()
    {
        this.Enabled = false;

        SpawnCubeConfig spawnCubeConfig = SystemAPI.GetSingleton<SpawnCubeConfig>();

        for (int i = 0; i < spawnCubeConfig.amount; i++)
        {
            Entity spawnedEntity = EntityManager.Instantiate(spawnCubeConfig.cubePrefabEntity);
            EntityManager.SetComponentData(spawnedEntity, new LocalTransform
            {
                Position = new Unity.Mathematics.float3(UnityEngine.Random.Range(-5, 5), .5f, UnityEngine.Random.Range(-5, 5)),
                Rotation = Quaternion.identity,
                Scale = 1f
            });//
        }
    }
}
