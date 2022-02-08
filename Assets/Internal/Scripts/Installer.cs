using Core;
using Core.CashRewardSystem;
using Core.InventorySystem;
using Core.IO;
using Core.ItemSystem;
using Core.UI;

using UnityEngine;
using Zenject;

public class Installer : MonoInstaller
{
    [SerializeField] private Inventory _inventoryPrefab;
    [SerializeField] private CashRewardFacade _cashRewardSystemFacadePrefab;
    [SerializeField] private CashRewardDataBundle _cashRewardDataBundle;
    [SerializeField] private LootBoxDataBundle _lootBoxDataBundle;
    [SerializeField] private DetailItemPresenter _detailItemPresenter;

    [Space(20f)]
    [Header("Factories")]
    [SerializeField] private FusePresenterFactory _fusePresenterFactory;
    [SerializeField] private InventoryItemPresenterFactory _inventoryItemPresenterFactory;

    public override void InstallBindings()
    {
        InstallInput();
        InstallNonMonoBehaviours();
        InstallInstances();
        InstallDataManagment();
        InstallCores();
        InstallUI();
        InstallFactories();
    }

    private void InstallInstances()
    {
        //Container.Bind<Inventory>().FromInstance(_inventoryPrefab).AsSingle();
        Container.Bind<CashRewardFacade>().FromInstance(_cashRewardSystemFacadePrefab).AsSingle();
    }

    private void InstallInput()
    {
        if(SystemInfo.deviceType == DeviceType.Handheld)
        {
            Container.BindInterfacesAndSelfTo<MobileInput>().AsSingle();
        }
        else if(SystemInfo.deviceType == DeviceType.Desktop)
        {
            Container.BindInterfacesAndSelfTo<DesktopInput>().AsSingle();
        }
        else
        {
            throw new System.InvalidOperationException("There is no input module for this device");
        }
    }

    private void InstallNonMonoBehaviours()
    {
        Container.BindInstance(_cashRewardDataBundle);
        Container.BindInstance(_lootBoxDataBundle);
        Container.BindInterfacesAndSelfTo<ManualCashRewarder>().AsSingle();
        Container.BindInterfacesAndSelfTo<AutoCashRewarder>().AsSingle();

        Container.Bind<Inventory>().FromNew().AsSingle();
        Container.Bind<LootItemDataFactory>().FromNew().AsSingle();
        Container.Bind<Fuse>().FromNew().AsSingle();
    }

    private void InstallDataManagment()
    {
        Container.BindInterfacesAndSelfTo<JsonSaver>().FromNew().AsSingle();
    }

    private void InstallCores()
    {
        Container.Bind<LootBox>().FromNew().AsSingle();
    }

    private void InstallUI()
    {
        Container.Bind<DetailItemPresenter>().FromInstance(_detailItemPresenter).AsSingle();
    }

    private void InstallFactories()
    {
        Container.Bind<FusePresenterFactory>().FromInstance(_fusePresenterFactory).AsSingle();
    }
}
