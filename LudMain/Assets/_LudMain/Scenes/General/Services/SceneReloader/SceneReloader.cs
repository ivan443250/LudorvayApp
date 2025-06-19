using LudMain.DataHolding;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace LudMain.General
{
    public class SceneReloader : MonoBehaviour, ISceneReloader
    {
        [SerializeField] private BaseDataInserter[] _dataInserters;

        private IMainDataLoader _mainDataLoader;

        [Inject]
        public void Construct(IMainDataLoader mainDataLoader)
        {
            _mainDataLoader = mainDataLoader;
        }

        public void ReloadSceneData()
        {
            _mainDataLoader.UpdateData(new HashSet<Type>(_dataInserters.SelectMany(inserter => inserter.GetDataLoaders())));

            foreach (BaseDataInserter inserter in _dataInserters)
                inserter.StartInsertion();
        }
    }
}
