using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    // Post işleminde yeni bir project yaratmak için dto'muzu record olarak tanımlayabilriz. Ayrıca bu nesnemizi return
    // etmiyeceğimiz için (yani serialize işlemine ihtiyacımız yok) property'leri parametre şeklinde tanımlayarak otomatik olarak immutable (değişmez)
    // olmasını sağlayabiliriz. Yani bu tanımla property'lerin set method'larının yerine init method'larıyla tanımlanmasını sağlıyoruz.
    public record ProjectDtoForCreation(string Name, string Description, string Field);
}
