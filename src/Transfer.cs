using System;
using System.IO;
using System.Collections.Generic;

namespace Hazel
{
	class Transfer
	// tokens left).
	{
		public List<TokenTransfer> GetTokenTransfers(List<string> logs)
		{
			List<TokenTransfer> transferLogs = new List<TokenTransfer>();
			//List<string> transferLogs = new List<string>();
			string currentLine = string.Empty;

			foreach (string logFile in logs)
			{
				System.IO.StreamReader log = new System.IO.StreamReader(logFile);

				while ((currentLine = log.ReadLine()) != null)
				{
					if (currentLine.Contains("tokens left)."))
					{
						string fileName = Path.GetFileNameWithoutExtension(logFile);
						currentLine = currentLine.Insert(1, $"{fileName} ");

						TokenTransfer newTransfer = new TokenTransfer(
							this.GetContainerID(currentLine), // Container
							this.GetContainerCharacter(currentLine), // Character
							this.GetContainerDate(currentLine), // Date
							currentLine, // Log
							this.GetSteamName(this.GetContainerCharacter(currentLine), logFile), // Steam
							this.GetSteamID(this.GetSteamName(this.GetContainerCharacter(currentLine), logFile), logFile), // SteamID
							this.GetTokenAmount(currentLine) // Amount
						);
						transferLogs.Add(newTransfer);
					}
					
				}
			}

			return transferLogs;
		}

		public List<TokenTransfer> GetPotentialTransfers(List<TokenTransfer> logs)
		{
			List<TokenTransfer> potential = new List<TokenTransfer>();

			for (int i = 0; i < logs.Count; i++)
			{
				for (int j = i + 1; j < logs.Count; j++)
				{
					if (logs[i].steamID == logs[j].steamID && logs[i].character != logs[j].character) {
						potential.Add(logs[i]);
						potential.Add(logs[j]);
					}
				}

			}

			return potential;
		}

		public string GetContainerID(string log)
		{
			Int32 containerIDPattern = log.IndexOf("#");
			string[] sectionedLog = log.Split("' #");
			string containerID = sectionedLog[1].Substring(0, 5);
			return "#" + containerID;
		}

		public string GetContainerCharacter(string log)
		{
			bool isGiven = log.Contains(" given ");
			string giveOrTake = string.Empty;
			if (log.Contains(" given ")) giveOrTake = "given";
			else giveOrTake = "taken";
			string[] sectionedLog = log.Split($" has {giveOrTake} ");
			string character = sectionedLog[0].Substring(22);
			return character;
		}

		public string GetContainerDate(string log)
		{
			return log.Substring(1, 10);
		}

		public string GetSteamName(string character, string file)
		{
			string currentLine = string.Empty;
			string steamName = "ERROR";
			System.IO.StreamReader log = new System.IO.StreamReader(file);

			while ((currentLine = log.ReadLine()) != null)
			{
				if (currentLine.Contains($"loaded the character '{character}'"))
				{
					string[] sectionedLog = currentLine.Split(" loaded the character");
					steamName = sectionedLog[0].Substring(11);
					return steamName;
				}
			}

			return steamName;
		}

		public string GetSteamID(string steam, string file)
		{
			string currentLine = string.Empty;
			string steamID = "ERROR";
			System.IO.StreamReader log = new System.IO.StreamReader(file);

			while ((currentLine = log.ReadLine()) != null)
			{
				if (currentLine.Contains("has disconnected.") && currentLine.Contains(steam))
				{
					string[] sectionedLog = currentLine.Split(" (STEAM_");
					steamID = sectionedLog[1].Substring(0, 12);
					return "STEAM_" + steamID;
				}
			}

			return "STEAM_" + steamID;
		}

		public Int32 GetTokenAmount(string line)
		{
			bool isGiven = line.Contains(" given ");
			string giveOrTake = string.Empty;
			if (line.Contains(" given ")) giveOrTake = "given";
			else giveOrTake = "taken";
			string[] sectionedLog = line.Split($" has {giveOrTake} ");
			string amount = sectionedLog[1].Split(" tokens ")[0];
			return Int32.Parse(amount);
		}
	}
}
