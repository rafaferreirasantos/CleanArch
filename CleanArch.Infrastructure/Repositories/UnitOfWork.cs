using CleanArch.Domain.Abstractions;
using CleanArch.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Infrastructure.Repositories
{
  public class UnitOfWork : IUnitOfWork, IDisposable
  {

    private IMemberRepository? _memberRepository;
    private readonly AppDBContext _context;

    public UnitOfWork(AppDBContext context)
    {
      _context = context;
    }

    public IMemberRepository MemberRepository
    {
      get
      {
        return _memberRepository = _memberRepository ?? new MemberRepository(_context);
      }
    }

    public async Task CommitAsync()
    {
      await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
      _context.Dispose();
    }
  }
}
