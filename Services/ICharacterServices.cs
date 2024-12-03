using Demo19305.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo19305.Services;

public interface ICharacterServices
{
    // 1. Lấy danh sách tất cả player
    Task<List<Character>> GetAllChar();

// 2. Lấy danh sách tất cả player có Coin > 100
    Task<List<Character>> GetAllCharByCoin();

// 3. Lấy tất cả player có level < 10
    Task<List<Character>> GetAllCharByLevelLess10();

// 4. Lấy tất cả player có HP > 50 và MP > 100
    Task<List<Character>> GetAllCharByHPMP();

// 5. Lấy tất cả player có defense > 100 hoặc attack < 50
    Task<List<Character>> GetAllCharByDefAtk();

// 6. Thêm mới 1 player
    Task<Character> AddChar(string name, int level, int exp, int coin, int hp, int mp, int atk, int def);

// 7. Cập nhật chỉ số HP = 100 cho tất cả player có level > 10
    Task<List<Character>> UpdateCharHP();

// 8. Xóa các player có attack < 100
    Task<List<Character>> DeleteCharByAtk();

    // Lab02

    // lấy danh sách các character của account
    Task<List<Character>> GetAllCharByAccount(int account_id);


// lấy danh sách các character có level > 10
    Task<List<Character>> GetAllCharByLevel(int level);


// lấy danh sách các character có level > 10 và tên bắt đầu bằng 'A'
    Task<List<Character>> GetAllCharByLevelAndName(int level, string name);

// lấy danh sách các character có level > 10 và tên có chứa 'A'
    Task<List<Character>> GetAllCharByLevelAndNameContainA(int level, string name);

// lấy danh sách các character có level > 10 và tên có chứa 'A' hoặc 'B'
    Task<List<Character>> GetAllCharByLevelAndNameContainAOrB(int level, string name);

// lấy danh sách các character có level > 10 và tên có chứa 'A' hoặc 'B' và sắp xếp theo level giảm dần
    Task<List<Character>> GetAllCharByLevelAndNameContainAOrBOrderByLevelDesc(int level, string name);

// lấy danh sách các character có level > 10 và tên có chứa 'A' hoặc 'B' và điểm kinh nghiệm > 1000 và sắp xếp theo level giảm dần
    Task<List<Character>> GetAllCharByLevelAndNameContainAOrBAndExpOrderByLevelDesc(int level, string name);

    // thêm mới 1 character
    Task<Character> AddCharacter(Character character);

    // cập nhật thông tin character theo id
    Task<Character> UpdateCharacter(Character character);

    // cập nhật exp cho các character có level > '...'
    Task<List<Character>> UpdateExpByLevel(Character character);

    // cập nhật level cho các character có account_id = '...'
    Task<List<Character>> UpdateLevelByAccountId(Character character);

    // Lab 3 + 4:
// Trên 2 bảng Accounts và Characters
// 1. Thêm mới 1 character vào bảng Characters
// 2. Cập nhật thông tin character (name, level, exp) theo id
// 3. Cập nhật exp = '...' cho các character có level > '...'
// 4. Cập nhật level = '...' cho các character có account_id = '...'
// 5. Thực hiện bắt lỗi các API trên
// - Name không được rỗng
// - Level phải lớn hơn 0 và nhỏ hơn 1000
// - Exp phải lớn hơn 0

}
