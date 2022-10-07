using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    // Dto'larımızı, amaçımız sadece istenilen verilerin katmanlar arası transferi olduğu için class değil de record tipinde tanımlayabiliriz.
    // Böylelikle sadece veriye odaklanmış oluruz, ayrıca property'lerimizi tanımlarken set method'ı yerine init method'ı ile tanımlayabilir ve
    // değerlerinin sadece ilk tanımlanma anlarında veya sadece constructor method'da tanımlanmasını sağlayabiliriz, buradaki amacımız Dto'lar
    // üzerinden veri manipülasyonunu engellemektir.
    // init method'ı ile kodlarımız MSIL kod'a çevrildiğinde immutable (değişmez) olacaktır.
    public record ProjectDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public string Field { get; init; }
    }
}
