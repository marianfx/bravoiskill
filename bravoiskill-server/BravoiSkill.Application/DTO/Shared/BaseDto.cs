using System.Collections.Generic;
using System.Linq;

namespace BravoiSkill.Application.DTO.Shared
{
    public class BaseDto
    {
        public IList<string> Errors { get; set; } = new List<string>();

        public BaseDto()
        {

        }

        public virtual IList<string> Validate()
        {
            return Errors;
        }
        public bool HasErrors => Errors.Any();

    }
}
