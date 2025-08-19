using UnityEngine;

namespace Cerebra Menu V1
{
    public static class KickManager
    {
        // Example function: kicks all players
        public static void KickAllPlayers()
        {
            // You need to implement logic to find all player objects, move them to kick box, and crash them
            Debug.Log("Kick All triggered (implement actual logic here)");
        }

        // Kicks a specific player
        public static void KickPlayer(GameObject player)
        {
            // Move player to kick box, crash their game
            Debug.Log($"Kick triggered for {player.name} (implement actual logic here)");
        }
    }
}