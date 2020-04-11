using System;

namespace Hazel
{
	class TokenTransfer
	{
		public string character, steam, steamID, container, date, log = string.Empty;
		public Int32 amount = 0;

		public TokenTransfer(string pContainer, string pCharacter, string pDate, string pLog, string pSteam, string pSteamID, Int32 pAmount)
		{
			character = pCharacter;
			container = pContainer; // Works
			steam = pSteam;
			steamID = pSteamID;
			amount = pAmount;
			log = pLog;
			date = pDate;
		}
	}
}
