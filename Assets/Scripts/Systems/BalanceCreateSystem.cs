using Leopotam.Ecs;

public class BalanceCreateSystem : IEcsInitSystem
{
    private readonly EcsWorld _world;
    private readonly SceneData _sceneData;
    private readonly IBalanceProvider _balanceProvider;

    public void Init()
    {
        CreateBalanaceEntity();
    }

    private void CreateBalanaceEntity()
    {
        EcsEntity balanceEntity = _world.NewEntity();
        _balanceProvider.Provide(balanceEntity);

        ref BalanceComponent bComponent = ref balanceEntity.Get<BalanceComponent>();
        bComponent.value = 0;
        bComponent.tmpBalance = _sceneData.tmpBalance;
        balanceEntity.Get<BalanceChangeComponent>();
    }
}

public interface IBalanceProvider
{
    public void Provide(EcsEntity balanceEntity);
}