using System.Collections;
using System.Collections.Generic;
using TileSystem;
using UnityEngine;
using Zenject;

public class PlayersComponentsInstallers : MonoInstaller
{
    [SerializeField] private HexPool HexPool;
    [SerializeField] private TileCreator TileCreator;

    public override void InstallBindings()
    {
        Container.Bind<HexPool>().FromInstance(HexPool).AsSingle();
        Container.Bind<TileCreator>().FromInstance(TileCreator).AsSingle();        
    }
}
