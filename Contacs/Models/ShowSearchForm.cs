using System;
namespace Contacs.Models
{
	public class ShowSearchForm
	{
        public int Id { get; set; }
        public string UUID { get; set; } = string.Empty;
        public string date { get; set; } = string.Empty;
        
        public string status { get; set; } = string.Empty;
        
        public ShowSearchForm()
		{
		}
	}
}

