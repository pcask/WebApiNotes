using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using Shared.DataTransferObjects;
using System.Text;

namespace ProjectManagement.Utilities.OutPutFormatters
{
    // Kendi OutPutFormatter'ımızı yazmak için TextOutputFormatter'dan Custom nesnemizi kalıtıyoruz.
    public class CsvOutputFormatter : TextOutputFormatter
    {
        public CsvOutputFormatter()
        {
            // Client'dan gelen text/csv Accept Header' ı destekleyeceğimizi bildiriyoruz.
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/csv"));
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }

        // Belirtilen tipin Serialize edilip edilemeceğinin kontrolü yapıyoruz.
        protected override bool CanWriteType(Type type)
        {
            if (typeof(ProjectDto).IsAssignableFrom(type)
                || typeof(IEnumerable<ProjectDto>).IsAssignableFrom(type))
            {
                return base.CanWriteType(type);
            }

            return false;
        }

        // Belirtilen nesnenin property'lerini virgülle ayrılacak şekilde oluşturuyor ve asenkron olarak response'a basıyoruz. 
        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context,
            Encoding selectedEncoding)
        {
            var response = context.HttpContext.Response;
            var stringBuilder = new StringBuilder();

            if (context.Object is IEnumerable<ProjectDto> projectList)
            {
                foreach (var project in projectList)
                {
                    FormatCsv(stringBuilder, project);
                }
            }
            else
            {
                FormatCsv(stringBuilder, (ProjectDto)context.Object);
            }

            await response.WriteAsync(stringBuilder.ToString());
        }

        private static void FormatCsv(StringBuilder sBuilder, ProjectDto project)
        {
            sBuilder.AppendLine($"{project.Id},\"{project.Name},\"{project.Description},\"{project.Field}");
        }
    }
}
