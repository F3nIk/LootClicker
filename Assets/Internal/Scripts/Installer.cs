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
    [Header("Instances")]
    [SerializeField] private CashRewardFacade _cashRewardSystemFacade;
    [SerializeField] private DetailItemPresenter _detailItemPresenter;
    [SerializeField] private MonoBehaviourMessages _monoBehaviourMessages;

    [Space(10f)]
    [Header("Scriptables")]
    [SerializeField] private LootBoxDataBundle _lootBoxDataBundle;
    [SerializeField] private CashRewardDataBundle _cashRewardDataBundle;

    [Space(10f)]
    [Header("Factories")]
    [SerializeField] private FusePresenterFactory _fusePresenterFactory;
    [SerializeField] private InventoryItemPresenterFactory _inventoryItemPresenterFactory;

    public override void InstallBindings()
    {
        InstallMonoOptimization();
        InstallDataManagment();
        InstallInput();
        InstallScriptables();
        InstallNonMonoBehaviours();
        InstallInstances();
    }

    private void InstallMonoOptimization()
    {
        Container.Bind<MonoBehaviourMessages>().FromInstance(_monoBehaviourMessages).AsSingle();
    }

    private void InstallDataManagment()
    {
        Container.BindInterfacesAndSelfTo<JsonSaver>().FromNew().AsSingle();
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

    private void InstallScriptables()
    {
        Container.BindInstance(_cashRewardDataBundle).AsSingle();
        Container.BindInstance(_lootBoxDataBundle).AsSingle();
    }

    private void InstallNonMonoBehaviours()
    {
        Container.Bind<LootItemDataFactory>().FromNew().AsSingle();
        Container.Bind<Inventory>().FromNew().AsSingle();

        Container.BindInterfacesAndSelfTo<ManualCashRewarder>().AsSingle();
        Container.BindInterfacesAndSelfTo<AutoCashRewarder>().AsSingle();

        Container.Bind<LootBox>().FromNew().AsSingle();
        Container.Bind<Fuse>().FromNew().AsSingle();
    }

    private void InstallInstances()
    {
        Container.Bind<CashRewardFacade>().FromInstance(_cashRewardSystemFacade).AsSingle();
        Container.Bind<FusePresenterFactory>().FromInstance(_fusePresenterFactory).AsSingle();
        Container.Bind<DetailItemPresenter>().FromInstance(_detailItemPresenter).AsSingle();
    }




}
