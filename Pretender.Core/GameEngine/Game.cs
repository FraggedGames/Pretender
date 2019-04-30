using Microsoft.Extensions.Hosting;
using Pretender.Database;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Pretender.GameEngine
{
    public class Game : BackgroundService, IGame
    {
        private readonly IList<IPlayer> _players = new List<IPlayer>();
        private readonly GameOptions _options;
        private readonly IDatabase _database;

        public ICollection<IPlayer> Players => _players;

        public Game(GameOptions options, IDatabase database)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
            this._database = database ?? throw new ArgumentNullException(nameof(database));
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var previous = Timestamp();

            while (!stoppingToken.IsCancellationRequested)
            {
                var current = Timestamp();
                var elapsed = current - previous;

                await ProcessInput();
                await Update(elapsed);
                await Render();

                previous = current;
            }
        }

        private Double Timestamp() => Stopwatch.GetTimestamp() * 10000.0d;

        private Task ProcessInput() => Task.CompletedTask;
        private Task Update(Double elapsed)
        {
            foreach (var player in _players)
            {
                player.Character.Update(elapsed);
            }
            return Task.CompletedTask;
        }

        private Task Render() => Task.CompletedTask;

        public async Task<Int32> AddPlayerAsync(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentNullException(nameof(player));
            }

            var sessionID = await _database.BeginSessionAsync(player);
            _players.Add(player);
            return sessionID;
        }

        public override void Dispose()
        {
            base.Dispose();

            _players.Each(p => p.Dispose());
            _players.Clear();
        }
    }
}
