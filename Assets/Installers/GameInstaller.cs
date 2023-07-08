using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public VideoSelection VideoSelection;
    public Smartphone Smartphone;

    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<GameController>()
            .FromNew()
            .AsSingle()
            .NonLazy();

        Container.BindInterfacesAndSelfTo<VideoSelection>()
            .FromInstance(VideoSelection)
            .AsSingle();

        Container.BindInterfacesAndSelfTo<Smartphone>()
            .FromInstance(Smartphone)
            .AsSingle();
    }
}