using DecentralizedErp.Infrastructure;

namespace DecentralizedErp.APIs;

public class UsersService : UsersServiceBase
{
    public UsersService(DecentralizedErpDbContext context)
        : base(context) { }
}
