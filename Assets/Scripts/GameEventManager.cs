using System;

namespace Anecdotes
{
    public class GameEventManager
    {
        public static GameEventManager Instance { get; private set; }
        
        public Action DataChanged { get; set; }
        public Action Reaction { get; set; }
        
        static GameEventManager()
        {
            Instance = new GameEventManager();
        }

        private GameEventManager()
        {
            
        }
    }
}