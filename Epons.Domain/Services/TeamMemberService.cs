using Epons.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epons.Domain.Services
{
    public class TeamMemberService
    {
        private readonly TeamMemberRepository _teamMemberRepository;

        public TeamMemberService(TeamMemberRepository teamMemberRepository)
        {
            _teamMemberRepository = teamMemberRepository;
        }

        public IList<EntityViews.TeamMember> List(Guid patientId, DateTime startDate, DateTime endDate)
        {
            return _teamMemberRepository.List(patientId, startDate, endDate).OrderByDescending((x) => x.DeallocationTimestamp).ToList();
        }
    }
}
