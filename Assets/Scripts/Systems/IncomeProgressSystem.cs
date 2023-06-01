using Leopotam.Ecs;
using UnityEngine;

public class IncomeProgressSystem : IEcsRunSystem
{
    private readonly EcsFilter<IncomeProgressComponent>.Exclude<DisabledBusinessTag> _filter;

    public void Run()
    {
        UpdateProgressBar();
    }

    private void UpdateProgressBar()
    {
        foreach (var i in _filter)
        {
            ref IncomeProgressComponent component = ref _filter.Get1(i);
            component.incomeProgress += component.incomeProgressIncreaseSpeed * Time.deltaTime;
            component.incomeProgress = Mathf.Clamp01(component.incomeProgress);

            if (component.incomeProgress == 1f)
            {
                SetIncomeInvokeTagToEntity(ref _filter.GetEntity(i));
                component.incomeProgress = 0f;
            }

            component.progressFill.fillAmount = component.incomeProgress;
        }
    }

    private void SetIncomeInvokeTagToEntity(ref EcsEntity entity)
    {
        entity.Get<IncomeValueChangeTag>();
    }
}