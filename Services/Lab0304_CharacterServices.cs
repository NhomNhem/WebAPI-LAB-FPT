using Demo19305.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo19305.Services;

public partial class CharacterServices : ICharacterServices
{
    // Lab03 + lab04

public Task<Character> AddCharacter(Character character) {
    // Validate character data
    ValidData(character.name, character.level, character.exp);
    try {
        // Check if the account_id exists in the accounts table
        var accountExists = _context.Accounts.Any(a => a.Id == character.account_id);
        if (!accountExists) throw new ArgumentException("Account ID does not exist");

        // Set the id to 0 to avoid explicit value insertion
        character.id = 0;

        // Set timestamps
        character.created_at = DateTime.Now;
        character.updated_at = DateTime.Now;

        // Add character to the Characters table
        _context.Characters.Add(character);
        _context.SaveChanges();

        // Return the added character
        return Task.FromResult(character);
    }
    catch (Exception e) {
        Console.WriteLine(e);
        throw;
    }
}    private static void ValidData(string name, int level, int exp) {
        // valid data
        if (string.IsNullOrEmpty(name)) throw new ArgumentException("Name could not empty");
        if (level <= 0 || level >= 1000) throw new ArgumentException("Level must be greater than 0 and less than 1000");
        if (exp <= 0) throw new ArgumentException("Exp must be greater than 0");
    }

    private static void ValidData(int id, string name, int level, int exp) {
        // valid data
        if (string.IsNullOrEmpty(name)) throw new ArgumentException("Name could not empty");
        if (level <= 0 || level >= 1000) throw new ArgumentException("Level must be greater than 0 and less than 1000");
        if (exp <= 0) throw new ArgumentException("Exp must be greater than 0");
    }



    public Task<Character> UpdateCharacter(Character character) {
    ValidData(character.id, character.name, character.level, character.exp);
    try {
        // Retrieve the existing character from the database
        var charUpdate = _context.Characters.FirstOrDefault(x => x.id == character.id);
        if (charUpdate == null) throw new ArgumentException("Character not found");

        // Update the properties of the retrieved character
        charUpdate.name = character.name;
        charUpdate.level = character.level;
        charUpdate.exp = character.exp;
        charUpdate.updated_at = DateTime.Now;

        // Save the changes to the database
        _context.SaveChanges();
        return Task.FromResult(charUpdate);
    }
    catch (Exception e) {
        Console.WriteLine(e);
        throw;
    }
}




    public Task<List<Character>> UpdateExpByLevel(Character character) {
        if (character.exp <= 0) throw new ArgumentException("Exp must be greater than 0");

        // cập nhật exp cho các character có level > '...'
        try {
            var allChar = _context.Characters.Where(x => x.level == character.level).ToList();
            foreach (var item in allChar) {
                item.exp = character.exp;
            }

            _context.SaveChanges();
            return Task.FromResult(allChar);
        }
        catch (Exception e) {
            Console.WriteLine(e);
            throw;
        }
    }

    public Task<List<Character>> UpdateLevelByAccountId(Character character) {
        if (character.level <= 0 || character.level >= 1000)
            throw new ArgumentException("Level must be greater than 0 and less than 1000");
        // cập nhật level cho các character có account_id = '...'
        try {
            var allChar = _context.Characters.Where(x => x.account_id == character.account_id).ToList();
            foreach (var item in allChar) {
                item.level = character.level;
            }

            _context.SaveChanges();
            return Task.FromResult(allChar);
        }
        catch (Exception e) {
            Console.WriteLine(e);
            throw;
        }
    }
}