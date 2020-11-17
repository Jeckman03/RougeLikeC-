/* --This is a Rougelike console game created by: Jeff Eckman Date: 10/22/20-- */
using System;
using Models;

namespace ConsoleUI
{

	class MainClass {
  public static void Main (string[] args) {

		bool playGame = false;
		CharacterModel player;

		playGame = TitleScreen();

		player = CreateCharacter();

		// Main game loop
		while (playGame == true)
		{

			GamePlay(player);

			Console.ReadLine();

		} 

		Console.WriteLine("You don't want to play the game. :(");

    Console.ReadLine();
  }

	// Methods
	private static bool TitleScreen() 
	{
		bool output = false;

		GameTitle();
		output = StartGame();

		return output;
	}

	private static void GameTitle()
	{
		Console.WriteLine("----------------------------");
		Console.WriteLine("\tRouge Like Console");
		Console.WriteLine("----------------------------");
		Console.WriteLine();
	}

	private static bool StartGame() 
	{
		bool output = false;
		Console.WriteLine("Get ready to fight your way to victory!");
		Console.WriteLine();
		Console.Write("Start new game (Y/N): ");
		string playGame = Console.ReadLine();

		if (playGame.ToLower() == "y")
		{
			output = true;
			return output;
		}
		else
		{
			return output;
		}
	}

	private static CharacterModel CreateCharacter()
	{
		Console.Clear();
		GameTitle();

		CharacterModel output = new CharacterModel();
		Console.Write("What is your name: ");
		output.Name = Console.ReadLine();
		output.Level = 1;
		output.Health = 100;
		output.AttackDmg = 10;
		output.Defense = 5;

		return output;
	}

	private static void CharacterUI(CharacterModel character)
	{
		Console.WriteLine("------------------------------------------------------");
		Console.WriteLine($"Name: { character.Name }  HP: { character.Health }  Atk: { character.AttackDmg }  Def: { character.Defense }");
		Console.WriteLine("------------------------------------------------------");		
	}

	private static EnemyModel EncounterDialog()
	{
		EnemyModel enemy = new EnemyModel();
		enemy.Name = "Gbolin";
		enemy.Level = 1;
		enemy.Health = 5;
		enemy.AttackDmg = 2;
		enemy.Defense = 1;
		Console.ForegroundColor = ConsoleColor.Cyan;
		Console.WriteLine();
		Console.WriteLine($"You have encountered a { enemy.Name }!");
		Console.ResetColor();
		Console.WriteLine();
		Console.WriteLine("What will you do?");

		return enemy;
	}

	private static FloorModel NewFloor()
	{
		FloorModel floor = new FloorModel();
		floor.Level = 1;
		Console.WriteLine();
		Console.WriteLine($"Floor Level: { floor.Level }");

		return floor;		
	}

	// User actions/choices
	private static int FightOptions()
	{
		int output = 1;

		Console.WriteLine("1. Attack");
		Console.WriteLine("2. Defend");
		Console.WriteLine("3. Use Potion");
		Console.WriteLine();
		Console.Write("Choice: ");
		string userChoice = Console.ReadLine();

		if (userChoice.ToLower() == "1")
		{
			Console.WriteLine("You have decieded to attack the enemy");
			return output;
		}
		else if (userChoice.ToLower() == "2")
		{
			Console.WriteLine("You have decided to Defend");
			return output;
		}
		else 
		{
			Console.WriteLine("You have used a potion");
			return output;
		}
	}

	private static void GamePlay(CharacterModel character) 
	{
		bool stillAlive = true;

		do{
			// clear the screen
			Console.Clear();

			// refresh and display the characters stats
			CharacterUI(character);

			// show the floor current level
			NewFloor();

			// display the encounter dialog
			EnemyModel enemy = EncounterDialog();

			// give player options on what to do
			int userSelection = FightOptions();

			if (userSelection == 1) 
			{
				int enemyHealth = enemy.Health;
				bool isDead = false;
				// play out the actions
				(isDead, enemyHealth) = GameLogic.PlayerAttack(character, enemy);

				if (isDead == true)
				{
					Console.WriteLine($"Your have killed the { enemy.Name }!");
				}
				else
				{
					Console.WriteLine($"The goblin now has { enemyHealth } health left!");
				}
				
			}
			else
			{
				Console.WriteLine("You didn't attack the enemy");
			}


			// see if the player is still alive or not

			Console.ReadLine();

		} while (stillAlive == true);

	}
}
}

