using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLocations
{
    public class GameLocations
    {
        public int[] PitLocations { get; set; } = new int[2];
        public int PlayerLocation { get; set; }
        public int[] BatLocations { get; set; } = new int[2];
        public int WumpusLocation { get; set; }
        public int StartingLocation { get; set; }
        public bool WumpusIsAwake { get; set; } = false;
        public int TurnsUntilWumpusIsAsleep { get; set; } = 0;
        public int TotalCaves { get; set; }
        Random random = new Random();
        //all the locations are the insteger numbers refering to the number of the cave which should coordinate to the position of the cave in the list of caves
        public GameLocations(int totalCaves)
        {
            TotalCaves = totalCaves;
            MakeHazardLocations();
            SetPlayerStartingLocation();
            SetWumpusLocation();
        }
        public void MakeHazardLocations()
        {
            //use this method to set the locations of the pits and bats at the start of the game
         
            PitLocations = new int[2];
            BatLocations = new int[2];
            while (true)
            {
                PitLocations[0] = random.Next(1, TotalCaves + 1);
                PitLocations[1] = random.Next(1, TotalCaves + 1);
                BatLocations[0] = random.Next(1, TotalCaves + 1);
                BatLocations[1] = random.Next(1, TotalCaves + 1);
                if (PitLocations[0] != PitLocations[1] && BatLocations[0] != BatLocations[1] && PitLocations[0] != BatLocations[0] && PitLocations[0] != BatLocations[1] && PitLocations[1] != BatLocations[0] && PitLocations[1] != BatLocations[1])
                {
                    break;
                }
            }
        }
        public void SetPlayerStartingLocation()
        {

            //YOU MUST SET THIS AFTER THE HAZARD LOCATIONS HAVE BEEN SET TO AVOID THE PLAYER STARTING IN THE SAME LOCATION AS A HAZARD but before the wumpus location is set to avoid the player starting in the same location as the wumpus
            while (true)
            {
                int startingLocation = random.Next(1, TotalCaves + 1);
                if (startingLocation != PitLocations[0] && startingLocation != PitLocations[1] && startingLocation != BatLocations[0] && startingLocation != BatLocations[1])
                {
                    PlayerLocation = startingLocation;
                    StartingLocation = startingLocation;
                    break;
                }
            }
        }

        public bool IsPitLocation(int location)
        {
            foreach (int pitLocation in PitLocations)
            {
                if (location == pitLocation)
                {
                    return true;
                }
            }
            return false;
        }
        public bool IsBatLocation(int location)
        {
            //checks whether or not there is bats in that room
            foreach (int batLocation in BatLocations)
            {
                if (location == batLocation)
                {
                    return true;
                }
            }
            return false;
        }
        public void MovePlayer(int chosenCave)
        {
            //moves the player to the cave chosen by the player
            int newLocation = chosenCave;

            PlayerLocation = newLocation;
        }

        public void MovePlayerToRandomLocation()
        {
            //use this after is bat location is true to move the player to a random location

            while (true)
            {
                int newLocation = random.Next(1, TotalCaves + 1);
                if (newLocation != PlayerLocation)
                {
                    PlayerLocation = newLocation;
                    break;
                }
            }

        }
        public void SetWumpusLocation()
        {


            //use this methodto set the wumpus location at the start of the game   
            while (true)
            {
                int newLocation = random.Next(1, TotalCaves + 1);
                if (newLocation != PlayerLocation)
                {
                    WumpusLocation = newLocation;
                    break;
                }
            }

        }
        public string GetHazardWarning(List<int> adjacentCaves)
        {
            //checks if the positions of bats pits or wumpus are equal to the adjacent caves and if they are it adds the appropriate warning to the string that is returned
            //returns a string that tells the player what hazards are nearby
            string warning = "";
            if (adjacentCaves.Contains(WumpusLocation))
            {
                warning += "You smell a terrible stench. ";
            }
            if (adjacentCaves.Contains(PitLocations[0]) || adjacentCaves.Contains(PitLocations[1]))
            {
                warning += "You feel a cold wind blowing from a nearby cavern. ";
            }
            if (adjacentCaves.Contains(BatLocations[0]) || adjacentCaves.Contains(BatLocations[1]))
            {
                warning += "You hear rustling of bat wings. ";
            }

            return warning;
        }
        public string BuySecret()
        {

            //returns a string that gives the player a secret about the location of the wumpus or pits or bats or also useless ones like what room number you are in and the answer to an already answered trivia question
            //create chance
            int chance = random.Next(1, 11);
            if (chance <= 3)
            {
                return $"The Wumpus is in cave {WumpusLocation}.";
            }
            else if (chance <= 6)
            {
                return $"There is a pit in cave {PitLocations[0]} and cave {PitLocations[1]}.";
            }
            else if (chance <= 8)
            {
                return $"There are bats in cave {BatLocations[0]} and cave {BatLocations[1]}.";
            }
            else

            {
                int randomUselessInfo = random.Next(1, 4);
                if (randomUselessInfo == 1) { return $"Did you know? The dolphin is the most intelligent marine animal."; }
                else if (randomUselessInfo == 2) { return $"Did you know? The honeybee can recognize human faces."; }
                else { return $"Did you know? The ostrich's eye is bigger than its brain."; }
            }

        }
        public bool ShootArrow(int chosenCave)
        {
            bool hit = false;

            //checks if the chosen cave is the same as the wumpus location and returns whether or not there is a hit
            //MAKE SURE TO DECREMENT ARROW COUNT AFTER CALLING THIS METHOD
            //If it returns false, call the MoveWumpusAfterArrowMiss method to move the wumpus to a new location 
            if (chosenCave == WumpusLocation)
            {
                hit = true;
            }
            return hit;
        }
        public void MoveWumpusAfterArrowMiss(List<int> connectedCaves)
        {
            //moves the wumpus to a new location if the player misses and there is a 75% chance that the wumpus will move
            //wakes wumpus up if it is asleep and sets the turns until it is asleep to 3
            
            int chance = random.Next(1, 5);
            int newLocation = random.Next(0, connectedCaves.Count);
            WumpusIsAwake = true;
            ResetWumpusAsleepTimer();
            if (chance <= 3)
            {
                WumpusLocation = connectedCaves[newLocation];
            }

        }
        public void MoveWumpusToRandomConnectedRoom(List<int> connectedCaves)
        {

            //make sure to call the reset wumpus asleep timer if it is a trivia win
            //the game control object should call this method 2 -4 times (only do this for a trivia win) after the player wins while calling the GetTunnels to find the available caves for each move to make the wumpus move a random number of times between 2 and 4 caves away from its current location after the player wins a trivia question against the wumpus
            //or if the wumpus is awake call this every turn it is awake for (just do like while(GameLocations.WumpusIsAwake) { MoveWumpusToRandomConnectedRoom(GetTunnels(GameLocations.WumpusLocation)); } in the game control object)
            int newLocation = random.Next(0, connectedCaves.Count);
            WumpusLocation = connectedCaves[newLocation];
        }
        public void ClimbOutOfPit()
        {
            //call this after the player falls into a pit and wins the trivia questions to climb out of the pit
            //moves the player to the starting location after climbing out of a pit
            PlayerLocation = StartingLocation;
        }
        public void ResetWumpusAsleepTimer()
        {
            //call this after the player wins a trivia question against the wumpus to reset the timer for how long the wumpus isn't asleep for
            TurnsUntilWumpusIsAsleep = 3;
            WumpusIsAwake = true;
        }
        public void OneTurnPasses()
        {
            //call this method after every turn to decrement the turns until the wumpus is asleep and to set the wumpus asleep if the timer reaches 0
            if (WumpusIsAwake)
            {
                TurnsUntilWumpusIsAsleep--;
                if (TurnsUntilWumpusIsAsleep <= 0)
                {
                    WumpusIsAwake = false;
                }
            }
        }
        public (bool[] hazards, string[] hazardNames) CheckHazards()
        {
            string[] hazardNames = { "Pit", "Bat", "Wumpus" };
            //the first one is if there is a pit in the room, the second one is if there are bats in the room and the third one is if the wumpus is in the room
            bool[] hazards = new bool[3];
            hazards[0] = IsPitLocation(PlayerLocation);
            hazards[1] = IsBatLocation(PlayerLocation);
            hazards[2] = PlayerLocation == WumpusLocation;
            return (hazards, hazardNames);
        }
    }
}