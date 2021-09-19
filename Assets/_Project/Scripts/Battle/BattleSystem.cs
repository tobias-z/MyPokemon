using System.Linq;
using Battle.Pokemon;
using Battle.State;
using Codice.Client.BaseCommands.BranchExplorer.ExplorerData;
using Core;
using Unity.Plastic.Newtonsoft.Json.Bson;

namespace Battle
{
    public class BattleSystem : BattleStateMachine
    {
        public IBattleUIManager UI { get; private set; }
        public IPokemonManager Player { get; private set; }
        public IPokemonManager Enemy { get; private set; }

        private void Awake()
        {
            UI = GetComponent<IBattleUIManager>();
            var managers = GetPokemonManagers();
            Player = managers[0];
            Enemy = managers[1];
        }

        private IPokemonManager[] GetPokemonManagers()
        {
            return GetComponents<IPokemonManager>().Select(manager =>
            {
                manager.Init(this);
                return manager;
            }).ToArray();
        }

        private void Start()
        {
            SetState(new BeginBattle(this));
        }

        private void Update()
        {
            StartCoroutine(State.Update());
        }
    }
}