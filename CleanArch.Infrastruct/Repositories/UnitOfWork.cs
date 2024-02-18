using CleanArch.Domain.Abstractions;
using CleanArch.Infrastruct.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Infrastruct.Repositories
{
  public class UnitOfWork : IUnitofWork, IDisposable
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
