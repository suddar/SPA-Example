using Microsoft.EntityFrameworkCore;

namespace SPA_Example.Architecture.Application.Services
{
    public class TokenService
    {
        private readonly AppDbContext _context;
        public TokenService(AppDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task Create(JWToken token)
        {
            _context.JWTokens.Add(token);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            JWToken refreshToken = await _context.JWTokens.FindAsync(id);
            if (refreshToken == null) return;

            _context.JWTokens.Remove(refreshToken);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAll(Guid userId)
        {
            IEnumerable<JWToken> refreshTokens = await _context.JWTokens
                .Where(t => t.UserId == userId)
                .ToListAsync();

            _context.JWTokens.RemoveRange(refreshTokens);
            await _context.SaveChangesAsync();
        }

        public async Task<JWToken> GetByToken(string token)
        {
            return await _context.JWTokens.FirstOrDefaultAsync(t => t.Token == token);
        }

    }
}
