using System.Collections.Generic;

public class AbilityUnlockService : IAbilityService
{
	private readonly Dictionary<string, bool> _abilities = new Dictionary<string, bool>();

	public void ActivateAbility(string abilityName)
	{
		if (!_abilities.ContainsKey(abilityName))
		{
			_abilities.Add(abilityName, true);
		}
	}

	public bool IsAbilityActive(string abilityName) => _abilities.ContainsKey(abilityName) && _abilities[abilityName];
}