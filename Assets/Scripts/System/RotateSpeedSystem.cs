using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;

public partial struct RotateSpeedSystem : ISystem
{
    public void onCreate(ref SystemState state) => state.RequireForUpdate<RotateSpeed>();

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        state.Enabled = false;

        return;

        /*foreach ((RefRW<LocalTransform> localTransform, RefRO<RotateSpeed> rotateSpeed)
            in SystemAPI.Query<RefRW<LocalTransform>, RefRO<RotateSpeed>>())
        {
            float power = 1f;
            for (int i = 0; i < 100000; i++)
            {
                power *= 2;
                power /= 2;

            }

            localTransform.ValueRW = localTransform.ValueRO.RotateY(rotateSpeed.ValueRO.value * SystemAPI.Time.DeltaTime * power);
        }*/

        RotatingCubeJob rotatingCubeJob = new RotatingCubeJob
        {
            deltaTime = SystemAPI.Time.DeltaTime
        };

        rotatingCubeJob.ScheduleParallel();
    }
}

[BurstCompile]
[WithAll(typeof(RotatingCube))]
public partial struct RotatingCubeJob : IJobEntity
{
    public float deltaTime;

    public void Execute(ref LocalTransform localTransform, in RotateSpeed rotateSpeed)
    {
        float power = 1f;
        for (int i = 0; i < 100000; i++)
        {
            power *= 2;
            power /= 2;

        }

        localTransform = localTransform.RotateY(rotateSpeed.value * deltaTime * power);
    }
}


