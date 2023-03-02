using System;
namespace Contacs.Models
{
	public class ContactData
	{
        public int Id { get; set; } 
        public string UUID { get; set; } = string.Empty;
        public string name { get; set; } = string.Empty;
        public string lastname { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
        public string location { get; set; } = string.Empty;
        public string company { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;

        public ContactData()
		{
		}
	}
}

