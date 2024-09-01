using System.ComponentModel.DataAnnotations;

namespace AtendoCloudSystem.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}