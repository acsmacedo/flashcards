using FlashCards.Api.Core.NotificationSettings;
using FlashCards.Api.Service.DTO.NotificationSettings;

namespace FlashCards.Api.Service.Services
{
    public class NotificationSettingService : INotificationSettingService
    {
        private readonly ApplicationDbContext _context;

        public NotificationSettingService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<NotificationSettingDto>> GetAllAsync()
        {
            var settings = await _context.NotificationSettings.ToListAsync();
            var result = settings.Select(x => new NotificationSettingDto(x));

            return result;
        }

        public async Task<IEnumerable<NotificationSettingByUserDto>> GetAllByUserAsync(int userID)
        {
            var settings = await _context.NotificationSettings.ToListAsync();

            var user = _context.Users
                .Include(x => x.NotiicationSettings)
                .FirstOrDefault(x => x.ID == userID);

            if (user == null)
                throw new Exception("Usuário não encontrado.");

            var result = settings.Select(x => new NotificationSettingByUserDto(x, user));

            return result;
        }

        public async Task CreateAsync(CreateNotificationSettingDto data)
        {
            var entity = new NotificationSetting(data.Name, data.Description);

            _context.Add(entity);

            await SaveChangesAsync();
        }

        public async Task EditAsync(EditNotificationSettingDto data)
        {
            var entity = GetByID(data.ID);

            entity.Edit(data.Name, data.Description);

            _context.Update(entity);

            await SaveChangesAsync();
        }

        public async Task DeleteAsync(DeleteNotificationSettingDto data)
        {
            var entity = GetByID(data.ID);

            _context.Remove(entity);

            await SaveChangesAsync();
        }

        private NotificationSetting GetByID(int id)
        {
            var entity = _context.NotificationSettings
                .FirstOrDefault(x => x.ID == id);

            if (entity != null)
                return entity;

            throw new Exception("Tipo de notificação não encontrada.");
        }

        private async Task SaveChangesAsync()
        {
            var result = await _context.SaveChangesAsync();

            if (result <= 0)
                throw new Exception("Ocorreu um erro ao salvar os dados. Tente novamente.");
        }
    }
}
