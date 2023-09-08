using Coursat.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coursat.Models
{
    public class UserLinks
    {
        public int Id { get; set; }
        [StringLength(250)]
        [Url]
        public string Website { get; set; }
        [StringLength(250)]
        [Url]
        public string Github { get; set; }
        [StringLength(250)]
        [Url]
        public string LinkedIn { get; set; }
        [StringLength(250)]
        [Url]
        public string Facebook { get; set; }
        [StringLength(250)]
        [Url]
        public string Twitter { get; set; }
        [StringLength(250)]
        [Url]
        public string StackoverFlow { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
