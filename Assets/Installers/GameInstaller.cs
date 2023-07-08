using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<GameController>()
            .FromNew()
            .AsSingle()
            .NonLazy();
    }
}