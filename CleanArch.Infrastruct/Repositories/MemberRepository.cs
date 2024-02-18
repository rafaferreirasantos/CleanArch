using CleanArch.Domain.Abstractions;
using CleanArch.Domain.Entities;
using CleanArch.Infrastruct.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Infrastruct.Repositories
{
  public class MemberRepository : IMemberRepository
  {
    protected readonly AppDBContext db;
    public MemberRepository(AppDBContext context) {
      db = context;
    }

    public async Task<Member> GetMemberById(int idMember)
    {
      var member = await db.Members.FindAsync(idMember);
      if (member is null)
        throw new InvalidOperationException("Member not found");

      return member;
    }

    public async Task<IEnumerable<Member>> GetMembers()
    {
      var members = await db.Members.ToListAsync();
      return members ?? Enumerable.Empty<Member>();
    }

    public async Task<Member> Add(Member member)
    {
      if (member is null)
        throw new ArgumentNullException(nameof(member));
      
      await db.Members.AddAsync(member);
      return member;
    }
    public void Update(Member member)
    {
      if (member is null)
        throw new ArgumentNullException(nameof(member));

      db.Members.Update(member);
    }

    public async Task<Member> Delete(int idMember)
    {
      var member = await GetMemberById(idMember);
      if (member is null)
        throw new InvalidOperationException("Member not found");

      db.Members.Remove(member);
      return member;
    }
  }
}
