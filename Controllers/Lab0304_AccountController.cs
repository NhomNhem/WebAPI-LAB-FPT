using Demo19305.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo19305.Controllers;

public partial class CharacterController : ControllerBase
{
    // thêm mới 1 character
    [HttpPost]
    [Route("/api/add-character-v2")]
    public async Task<IActionResult> AddCharacter([FromBody] Character character)
    {
        try
        {
            if (string.IsNullOrEmpty(character.name))
                return StatusCode(500, "Name is required");
            if (character.level <= 0 || character.level >= 1000)
                return StatusCode(500, "Level must be greater than 0 and less than 1000");
            if (character.exp <= 0)
                return StatusCode(500, "Exp must be greater than 0");

            character = await _characterServices.AddCharacter(character);
            return Ok(new { status = true, data = character });
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    // cập nhật thông tin character theo id
    [HttpPut]
    [Route("/api/update-character/")]
    public async Task<IActionResult> UpdateCharacter([FromBody] Character character)
    {
        try
        {
            if (string.IsNullOrEmpty(character.name))
                return StatusCode(500, "Name is required");
            if (character.level <= 0 || character.level >= 1000)
                return StatusCode(500, "Level must be greater than 0 and less than 1000");
            if (character.exp <= 0)
                return StatusCode(500, "Exp must be greater than 0");

            character = await _characterServices.UpdateCharacter(character);
            return Ok(new { status = true, data = character });
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    // cập nhật exp cho các character có level > '...'
    [HttpPut]
    [Route("/api/update-exp-by-level/")]
    public async Task<IActionResult> UpdateExpByLevel([FromBody] Character character)
    {
        try
        {
            if (character.level <= 0 || character.level >= 1000)
                return StatusCode(500, "Level must be greater than 0 and less than 1000");
            if (character.exp <= 0)
                return StatusCode(500, "Exp must be greater than 0");

            var characters = await _characterServices.UpdateExpByLevel(character);
            return Ok(new { status = true, data = characters });
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    // cập nhật level cho các character có account_id = '...'
    [HttpPut]
    [Route("/api/update-level-by-account-id/")]
    public async Task<IActionResult> UpdateLevelByAccountId([FromBody] Character character)
    {
        try
        {
            if (character.level <= 0 || character.level >= 1000)
                return StatusCode(500, "Level must be greater than 0 and less than 1000");

            var characters = await _characterServices.UpdateLevelByAccountId(character);
            return Ok(new { status = true, data = characters });
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

}
