using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Entities.ErrorModel
{
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }

        public override string ToString()
        {
            // sınıfın tüm property'lerini json'a dönüştürüyoruz.
            return JsonSerializer.Serialize(this);
        }
    }
}
