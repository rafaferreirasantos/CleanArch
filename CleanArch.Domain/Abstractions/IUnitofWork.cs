using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Abstractions
{
  public interface IUnitOfWork
  {
    IMemberRepository MemberRepository { get; }
    Task CommitAsync();
  }
}
