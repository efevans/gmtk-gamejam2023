using FrugalTime.Tick;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "GameSettingsInstaller", menuName = "Installers/GameSettingsInstaller")]
public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
{
    public Attention.Settings AttentionSettings;

    public override void InstallBindings()
    {
        Container.BindInstance(AttentionSettings);
    }
}