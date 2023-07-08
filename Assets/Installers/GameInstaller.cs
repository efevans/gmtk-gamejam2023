using FrugalTime.Game;
using FrugalTime.Tick;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public VideoSelection VideoSelection;
    public Smartphone Smartphone;
    public Attention Attention;
    public GameInfo GameInfo;

    public AudioSource AudioSource;

    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<AudioSource>()
            .FromInstance(AudioSource);

        Container.BindInterfacesAndSelfTo<AudioManager>()
            .FromNew()
            .AsSingle()
            .NonLazy();

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

        Container.BindInterfacesAndSelfTo<Attention>()
            .FromInstance(Attention)
            .AsSingle();

        Container.BindInterfacesAndSelfTo<GameInfo>()
            .FromInstance(GameInfo)
            .AsSingle();
    }
}