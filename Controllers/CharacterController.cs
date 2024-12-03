using Demo19305.Models;
using Demo19305.Services;
using Microsoft.AspNetCore.Mvc;

namespace Demo19305.Controllers;

[ApiController]
public partial class CharacterController : ControllerBase
{
    private readonly ICharacterServices _characterServices;

    public CharacterController(ICharacterServices characterServices) => _characterServices = characterServices;

    // lấy toàn bộ character
    [HttpGet]
    [Route("/api/get-all-characters")]
    public async Task<IActionResult> GetAllCharacters()
    {
        try
        {
            var allCharacters = await _characterServices.GetAllChar();
            return Ok(new { status = true, data = allCharacters });
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    // lấy thông tin character theo level
    [HttpGet]
    [Route("/api/get-character-by-level-100")]
    public async Task<IActionResult> GetCharacterByLevel()
    {
        try
        {
            var character = await _characterServices.GetAllCharByLevelLess10();
            return Ok(new { status = true, data = character });
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    // lấy thông tin character theo HP và MP
    [HttpGet]
    [Route("/api/get-character-by-hp-mp")]
    public async Task<IActionResult> GetCharacterByHPMP()
    {
        try
        {
            var character = await _characterServices.GetAllCharByHPMP();
            return Ok(new { status = true, data = character });
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    // lấy thông tin character theo def và atk
    [HttpGet]
    [Route("/api/get-character-by-def-atk")]
    public async Task<IActionResult> GetCharacterByDefAtk()
    {
        try
        {
            var character = await _characterServices.GetAllCharByDefAtk();
            return Ok(new { status = true, data = character });
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }



    // cập nhật chỉ số HP = 100 cho tất cả character có level > 10
    [HttpPut]
    [Route("/api/update-character-hp")]
    public async Task<IActionResult> UpdateCharacterHP()
    {
        try
        {
            var characters = await _characterServices.UpdateCharHP();
            return Ok(new { status = true, data = characters });
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    // xóa các character có attack < 100
    [HttpDelete]
    [Route("/api/delete-character-by-atk")]
    public async Task<IActionResult> DeleteCharacterByAtk()
    {
        try
        {
            var characters = await _characterServices.DeleteCharByAtk();
            return Ok(new { status = true, data = characters });
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    // lấy thông tin character theo coin
    [HttpGet]
    [Route("/api/get-character-by-coin")]
    public async Task<IActionResult> GetCharacterByCoin()
    {
        try
        {
            var character = await _characterServices.GetAllCharByCoin();
            return Ok(new { status = true, data = character });
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    // lấy danh sách các character của user
    [HttpGet]
    [Route("/api/get-character-by-account")]
    public async Task<IActionResult> GetCharacterByAccount(int account_id)
    {
        try
        {
            var character = await _characterServices.GetAllCharByAccount(account_id);
            return Ok(new { status = true, data = character });
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    // lấy danh sách các character có level > 10
    [HttpGet]
    [Route("/api/get-character-by-level")]
    public async Task<IActionResult> GetCharacterByLevel(int level)
    {
        try
        {
            var character = await _characterServices.GetAllCharByLevel(level);
            return Ok(new { status = true, data = character });
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    // lấy danh sách các character có level > 10 và tên bắt đầu bằng 'A'
    [HttpGet]
    [Route("/api/get-character-by-level-name")]
    public async Task<IActionResult> GetCharacterByLevelAndName(int level, string name)
    {
        try
        {
            var character = await _characterServices.GetAllCharByLevelAndName(level, name);
            return Ok(new { status = true, data = character });
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    // lấy danh sách các character có level > 10 và tên có chứa 'A'
    [HttpGet]
    [Route("/api/get-character-by-level-name-contain-a")]
    public async Task<IActionResult> GetCharacterByLevelAndNameContainA(int level, string name)
    {
        try
        {
            var character = await _characterServices.GetAllCharByLevelAndNameContainA(level, name);
            return Ok(new { status = true, data = character });
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    // lấy danh sách các character có level > 10 và tên có chứa 'A' hoặc 'B'
    [HttpGet]
    [Route("/api/get-character-by-level-name-contain-a-or-b")]
    public async Task<IActionResult> GetCharacterByLevelAndNameContainAOrB(int level, string name)
    {
        try
        {
            var character = await _characterServices.GetAllCharByLevelAndNameContainAOrB(level, name);
            return Ok(new { status = true, data = character });
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    // lấy danh sách các character có level > 10 và tên có chứa 'A' hoặc 'B' và sắp xếp theo level giảm dần
    [HttpGet]
    [Route("/api/get-character-by-level-name-contain-a-or-b-order-by-level-desc")]
    public async Task<IActionResult> GetCharacterByLevelAndNameContainAOrBOrderByLevelDesc(int level, string name)
    {
        try
        {
            var character = await _characterServices.GetAllCharByLevelAndNameContainAOrBOrderByLevelDesc(level, name);
            return Ok(new { status = true, data = character });
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    // lấy danh sách các character có level > 10 và tên có chứa 'A' hoặc 'B' và điểm kinh nghiệm > 1000 và sắp xếp theo level giảm dần
    [HttpGet]
    [Route("/api/get-character-by-level-name-contain-a-or-b-and-exp-order-by-level-desc")]
    public async Task<IActionResult> GetCharacterByLevelAndNameContainAOrBAndExpOrderByLevelDesc(int level, string name)
    {
        try
        {
            var character = await _characterServices.GetAllCharByLevelAndNameContainAOrBAndExpOrderByLevelDesc(level, name);
            return Ok(new { status = true, data = character });
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }


}