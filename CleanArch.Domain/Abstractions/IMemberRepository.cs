using CleanArch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Abstractions
{
  public interface IMemberRepository
  {
    Task<IEnumerable<Member>> GetMembers();
    Task<Member> GetMemberById(int idMember);
    Task<Member> Add(Member member);
    void Update(Member member);
    Task<Member> Delete(int idMember);
  }
}
