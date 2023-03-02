using System;
namespace Contacs.Models
{
	public class ContactData
	{
        public int Id { get; set; }
        public string UUID { get; set; }
        public string name { get; set; }
        public string lastname { get; set; }
        public string Number { get; set; }
        public string location { get; set; }
        public string company { get; set; }
        public string email { get; set; }
        public ContactData()
		{
		}
	}
}

