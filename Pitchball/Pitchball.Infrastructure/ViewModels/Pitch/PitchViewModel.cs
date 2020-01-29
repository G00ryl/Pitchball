using Pitchball.Infrastructure.Commands.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Pitchball.Infrastructure.ViewModels.Pitch
{
    public class PitchViewModel
    {
        public Domain.Models.Pitch Pitch { get; set; }
        public IEnumerable<Domain.Models.Reservation> Reservations { get; set; }
        public Domain.Models.Captain captain { get; set; }
        public CreateCommentCommand NewComment { get; set; }
        public PitchViewModel() { }

        public PitchViewModel(Domain.Models.Pitch pitch)
        {
            Pitch = pitch;        
        }
    }
    
}
