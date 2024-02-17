using Microsoft.AspNetCore.Identity;

namespace ProgrammersBlog.Entities.Concrete
{
    // idenity yapisi sedece mvc projelerimiz icin kullanilabilir yoksa sikinti yaratabilir 
    // idenity yapisinin yararlarindan idenity ile ilgili kodlar barindirir o yuzden cok zaman teserruf etmis oluyoruz 
    public class UserClaim : IdentityUserClaim<int>
    {
    }
}
