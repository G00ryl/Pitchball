using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Pitchball.Infrastructure.ViewModels.Pitch
{
    public class PitchViewModel
    {
        public Domain.Models.Pitch Pitch { get; set; }
        public PitchViewModel(Domain.Models.Pitch pitch)
        {
            Pitch = pitch;        
        }
    }
    
}
