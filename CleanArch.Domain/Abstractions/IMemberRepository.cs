using CleanArch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Abstractions
{
  internal interface IMemberRepository
  {
    Task<IEnumerable<Member>> GetAll();
    Task<Member> GetById(int idMember);
    Task<Member> Add(Member member);
    Task<Member> Update(Member member);
    Task Delete(int idMember);
  }
}
