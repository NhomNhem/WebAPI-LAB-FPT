using Demo19305.Models;

namespace Demo19305.Services;

public partial class CharacterServices : ICharacterServices
{
    private AppDataContext.AppDataContext _context;

    public CharacterServices(AppDataContext.AppDataContext context) => _context = context;

    public Task<List<Character>> GetAllChar() {
        // lấy danh sách tất cả character
        try {
            var allChar = _context.Characters.ToList();
            return Task.FromResult(allChar);
        }
        catch (Exception e) {
            Console.WriteLine(e);
            throw;
        }
    }

    public Task<List<Character>> GetAllCharByCoin() {
        // 2. Lấy danh sách tất cả player có Coin > 100
        try {
            var allChar = _context.Characters.Where(x => x.Coin > 100).ToList();
            return Task.FromResult(allChar);
        }
        catch (Exception e) {
            Console.WriteLine(e);
            throw;
        }
    }

    public Task<List<Character>> GetAllCharByLevelLess10() {
        //3. Lấy tất cả player có level < 10
        try {
            var allChar = _context.Characters.Where(x => x.level < 10).ToList();
            return Task.FromResult(allChar);
        }
        catch (Exception e) {
            Console.WriteLine(e);
            throw;
        }

    }

    public Task<List<Character>> GetAllCharByHPMP() {
        // 4. Lấy tất cả player có HP > 50 và MP > 100
        try {
            var allChar = _context.Characters.Where(x => x.HP > 50 && x.MP > 100).ToList();
            return Task.FromResult(allChar);
        }
        catch (Exception e) {
            Console.WriteLine(e);
            throw;
        }
    }

    public Task<List<Character>> GetAllCharByDefAtk() {
        // 5. Lấy tất cả player có defense > 100 hoặc attack < 50

        try {
            var allChar = _context.Characters.Where(x => x.def > 100 || x.atk < 50).ToList();
            return Task.FromResult(allChar);
        }
        catch (Exception e) {
            Console.WriteLine(e);
            throw;
        }
    }

    public Task<Character> AddChar(string name, int level, int exp, int coin, int hp, int mp, int atk, int def) {
        // 6. Thêm mới 1 player

        try {
            var newChar = new Character() {
                name = name,
                level = level,
                exp = exp,
                created_at = DateTime.Now,
                updated_at = DateTime.Now,
                Coin = coin,
                HP = hp,
                MP = mp,
                atk = atk,
                def = def

            };
            _context.Characters.Add(newChar);
            _context.SaveChanges();
            return Task.FromResult(newChar);
        }
        catch (Exception e) {
            Console.WriteLine(e);
            throw;
        }
    }

    public Task<List<Character>> UpdateCharHP() {
        // 7. Cập nhật chỉ số HP = 100 cho tất cả player có level > 10
        try {
            var allChar = _context.Characters.Where(x => x.level > 10).ToList();
            foreach (var item in allChar) {
                item.HP = 100;
            }
            _context.SaveChanges();
            return Task.FromResult(allChar);
        }
        catch (Exception e) {
            Console.WriteLine(e);
            throw;
        }
    }

    public Task<List<Character>> DeleteCharByAtk() {
        // 8. Xóa các player có attack < 100
        try {
            var allChar = _context.Characters.Where(x => x.atk < 100).ToList();
            _context.Characters.RemoveRange(allChar);
            _context.SaveChanges();
            return Task.FromResult(allChar);
        }
        catch (Exception e) {
            Console.WriteLine(e);
            throw;
        }
    }

    public Task<List<Character>> GetAllCharByAccount(int account_id) {
        // lấy danh sách các character của user
        try {
            var allChar = _context.Characters.Where(x => x.account_id == account_id).ToList();
            return Task.FromResult(allChar);
        }
        catch (Exception e) {
            Console.WriteLine(e);
            throw;
        }
    }

    public Task<List<Character>> GetAllCharByLevel(int level) {
        // lấy danh sách các character có level > 10
        try {
            var allChar = _context.Characters.Where(x => x.level > level).ToList();
            return Task.FromResult(allChar);
        }
        catch (Exception e) {
            Console.WriteLine(e);
            throw;
        }
    }

    public Task<List<Character>> GetAllCharByLevelAndName(int level, string name) {
        // lấy danh sách các character có level > 10 và tên bắt đầu bằng 'A'
        try {
            var allChar = _context.Characters.Where(x => x.level > level && x.name.StartsWith(name)).ToList();
            return Task.FromResult(allChar);
        }
        catch (Exception e) {
            Console.WriteLine(e);
            throw;
        }
    }

    public Task<List<Character>> GetAllCharByLevelAndNameContainA(int level, string name) {
        // lấy danh sách các character có level > 10 và tên có chứa 'A'
        try {
            var allChar = _context.Characters.Where(x => x.level > level && x.name.Contains(name)).ToList();
            return Task.FromResult(allChar);
        }
        catch (Exception e) {
            Console.WriteLine(e);
            throw;
        }
    }

    public Task<List<Character>> GetAllCharByLevelAndNameContainAOrB(int level, string name) {
        // lấy danh sách các character có level > 10 và tên có chứa 'A' hoặc 'B'
        try {
            var allChar = _context.Characters.Where(x => x.level > level && (x.name.Contains(name) )).ToList();
            return Task.FromResult(allChar);
        }
        catch (Exception e) {
            Console.WriteLine(e);
            throw;
        }
    }

    public Task<List<Character>> GetAllCharByLevelAndNameContainAOrBOrderByLevelDesc(int level, string name) {
        // lấy danh sách các character có level > 10 và tên có chứa 'A' hoặc 'B' và sắp xếp theo level giảm dần
        try {
            var allChar = _context.Characters.Where(x => x.level > level && ( x.name.Contains(name))).OrderByDescending(x => x.level).ToList();
            return Task.FromResult(allChar);
        }
        catch (Exception e) {
            Console.WriteLine(e);
            throw;
        }
    }

    public Task<List<Character>> GetAllCharByLevelAndNameContainAOrBAndExpOrderByLevelDesc(int level, string name) {
        // lấy danh sách các character có level > 10 và tên có chứa 'A' hoặc 'B' và điểm kinh nghiệm > 1000 và sắp xếp theo level giảm dần
        try {
            var allChar = _context.Characters.Where(x => x.level > level && (x.name.Contains(name)) && x.exp > 1000).OrderByDescending(x => x.level).ToList();
            return Task.FromResult(allChar);
        }
        catch (Exception e) {
            Console.WriteLine(e);
            throw;
        }
    }



}
