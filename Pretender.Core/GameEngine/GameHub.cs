using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Pretender.Messages;

namespace Pretender.GameEngine
{
    public interface IGameHub
    {
        Task SessionCreated(SessionCreated sessionCreated);
        Task CreateSessionFailed(CreateSessionFailed createSessionFailed);
    }

    public class GameHub : Hub<IGameHub>
    {
        private readonly IGame _game;
        private readonly IPlayerStore _playerStore;

        public GameHub(IGame game, IPlayerStore playerStore)
        {
            _game = game ?? throw new ArgumentNullException(nameof(game));
            _playerStore = playerStore ?? throw new ArgumentNullException(nameof(playerStore));
        }

        public async Task CreateSession(CreateSession message)
        {
            var player = await _playerStore.LoadPlayerAsync(message.PlayerId).ConfigureAwait(false);
            if (player == null)
            {
                await Clients.Caller.CreateSessionFailed(new CreateSessionFailed()).ConfigureAwait(false);
            }
            else
            {
                var sessionId = await _game.AddPlayerAsync(player);
                await Clients.Caller.SessionCreated(new SessionCreated()
                {
                    ConnectionId = Context.ConnectionId,
                    SessionId = sessionId
                });
            }
        }
    }
}
