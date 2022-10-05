using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    // Dto'larımızı, amaçımız sadece istenilen verilerin katmanlar arası transferi olduğu için class değil de record tipinde tanımlayabiliriz.
    // Böylelikle sadece veriye odaklanmış oluruz, ayrıca record tipinde gerekli alanları parametre şeklinde tanımlayarak
    // kodlarımız MSIL kod'a çevrildiğinde immutable (değişmez) olmasını sağlarız, yani set method'ları oluşturulmaz.
    public record ProjectDto(Guid Id, string Name, string Description, string Field);
}
